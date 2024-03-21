using UnityEngine;
using UnityEngine.UI;
using Project.SteamworksIntegrations;
using TMPro;

namespace Project.Menu
{
    public sealed class LobbyMenu : MonoBehaviour
    {
        [SerializeField] private TMP_Text _playersText;
        [SerializeField] private TMP_Text _matchStatusText;
        [SerializeField] private TMP_Text _copiedRoomIDText;
        [SerializeField] private Button _readyButton;
        [SerializeField] private Button _startButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _copyIDButton;
        [SerializeField] private GameObject _lobbyPlayerData;

        private void Awake()
        {
            _backButton.onClick.AddListener(() => SteamworksManager.LeaveLobby());
            _copyIDButton.onClick.AddListener(() => CopyRoomID());
        }

        private void CopyRoomID()
        {
            GUIUtility.systemCopyBuffer = SteamworksManager.CurrentLobbyID.ToString();
            _copiedRoomIDText.text = "Room ID Copied!";
        }
    }
}
