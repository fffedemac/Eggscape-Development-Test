using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Project.SteamworksIntegrations;
using FishNet.Object;

namespace Project.Menu
{
    public sealed class LobbyMenu : NetworkBehaviour
    {
        [SerializeField] private TMP_Text _playersText;
        [SerializeField] private TMP_Text _copiedRoomIDText;
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _copyIDButton;

        private void Awake()
        {
            _backButton.onClick.AddListener(() => SteamworksManager.LeaveLobby());
            _copyIDButton.onClick.AddListener(() => CopyRoomID());
        }

        public override void OnStartClient()
        {
            base.OnStartClient();
            if (IsHost)
                _startButton.gameObject.SetActive(true);
            else
                _playersText.text = "Waiting for Host to start...";
        }

        private void CopyRoomID()
        {
            GUIUtility.systemCopyBuffer = SteamworksManager.CurrentLobbyID.ToString();
            _copiedRoomIDText.text = "Room ID Copied!";
        }
    }
}
