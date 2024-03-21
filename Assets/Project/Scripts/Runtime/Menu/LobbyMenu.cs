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
        [SerializeField] private GameObject _mainMenu;

        private void Awake()
        {
            _backButton.onClick.AddListener(() => LeaveLobby());
            _copyIDButton.onClick.AddListener(() => CopyRoomID());
        }

        private void LeaveLobby()
        {
            SteamworksManager.LeaveLobby();

            _mainMenu.SetActive(true);
            _backButton.gameObject.SetActive(false);
            _copiedRoomIDText.text = "";
            gameObject.SetActive(false);
        }

        private void CopyRoomID()
        {
            GUIUtility.systemCopyBuffer = SteamworksManager.CurrentLobbyID.ToString();
            _copiedRoomIDText.text = "Room ID Copied!";
        }
    }
}
