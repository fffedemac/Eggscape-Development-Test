using UnityEngine;
using UnityEngine.SceneManagement;
using FishNet.Managing;
using Steamworks;

namespace Project.SteamworksIntegrations
{
    public sealed class SteamworksManager : MonoBehaviour
    {
        private static SteamworksManager Instance;

        private const string _menuScene = "Menu";
        private const string _initScene = "SteamConnection";
        [SerializeField] private NetworkManager _networkManager;
        [SerializeField] FishySteamworks.FishySteamworks _fishySteamworks;

        private Callback<LobbyCreated_t> LobbyCreated;
        private Callback<GameLobbyJoinRequested_t> JoinRequest;
        private Callback<LobbyEnter_t> LobbyEntered;

        public static ulong CurrentLobbyID;

        private void Awake() => Instance = this;

        private void Start()
        {
            LobbyCreated = Callback<LobbyCreated_t>.Create(OnLobbyCreated);
            JoinRequest = Callback<GameLobbyJoinRequested_t>.Create(OnJoinRequest);
            LobbyEntered = Callback<LobbyEnter_t>.Create(OnLobbyEntered);
        }

        public void LoadMenu() => SceneManager.LoadScene(_menuScene, LoadSceneMode.Additive);
        public static void CreateLobby() => SteamMatchmaking.CreateLobby(ELobbyType.k_ELobbyTypePublic, 2);

        public static void JoinLobby(CSteamID steamID)
        {
            if (SteamMatchmaking.RequestLobbyData(steamID))
                SteamMatchmaking.JoinLobby(steamID);
        }

        public static void LeaveLobby()
        {
            SteamMatchmaking.LeaveLobby(new CSteamID(CurrentLobbyID));
            CurrentLobbyID = 0;

            Instance._fishySteamworks.StopConnection(false);
            if (Instance._networkManager.IsServer)
                Instance._fishySteamworks.StopConnection(true);
        }

        private void OnLobbyCreated(LobbyCreated_t callback)
        {
            if (callback.m_eResult != EResult.k_EResultOK) return;

            CurrentLobbyID = callback.m_ulSteamIDLobby;
            Debug.Log(SteamUser.GetSteamID().ToString());
            SteamMatchmaking.SetLobbyData(new CSteamID(CurrentLobbyID), "Host Address", SteamUser.GetSteamID().ToString());
            _fishySteamworks.SetClientAddress(SteamUser.GetSteamID().ToString());
            _fishySteamworks.StartConnection(true);
        }

        private void OnJoinRequest(GameLobbyJoinRequested_t callback)
        {
            SteamMatchmaking.JoinLobby(callback.m_steamIDLobby);
        }

        private void OnLobbyEntered(LobbyEnter_t callback)
        {
            CurrentLobbyID = callback.m_ulSteamIDLobby;
            _fishySteamworks.SetClientAddress(SteamMatchmaking.GetLobbyData(new CSteamID(CurrentLobbyID), "Host Address"));
            _fishySteamworks.StartConnection(false);
        }
    }
}