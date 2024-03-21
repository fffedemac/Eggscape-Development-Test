using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Project.SteamworksIntegrations;
using Project.Entities.Player;
using FishNet.Object;
using FishNet.Managing.Server;

namespace Project.Menu
{
    public sealed class LobbyMenu : NetworkBehaviour
    {
        private static LobbyMenu Instance;

        [SerializeField] private TMP_Text _playersText;
        [SerializeField] private TMP_Text _copiedRoomIDText;
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _copyIDButton;
        [SerializeField] private GameObject _playersPanel;
        [SerializeField] private GameObject _playerLobbyData;

        private void Awake()
        {
            Instance = this;

            _backButton.onClick.AddListener(() => SteamworksManager.LeaveLobby());
            _copyIDButton.onClick.AddListener(() => CopyRoomID());
        }

        public override void OnStartClient()
        {
            base.OnStartClient();
            if (IsHost)
                _startButton.gameObject.SetActive(true);
        }

        private void CopyRoomID()
        {
            GUIUtility.systemCopyBuffer = SteamworksManager.CurrentLobbyID.ToString();
            _copiedRoomIDText.text = "Room ID Copied!";
        }

        public static void RPC_CreatePlayerData(PlayerModel playerOwner)
        {
            Instance.CreatePlayerData(playerOwner);
        }

        [ServerRpc(RequireOwnership = false)]
        private void CreatePlayerData(PlayerModel playerOwner)
        {
            GameObject playerData = Instantiate(_playerLobbyData, _playersPanel.transform);
            LobbyPlayerData data = playerData.GetComponent<LobbyPlayerData>();
            data.PlayerOwner = playerOwner;

            if (IsHost)
                data.PositionText.text = "1";
            else data.PositionText.text = "2";

            ServerManager.Spawn(playerData);
        }
    }
}
