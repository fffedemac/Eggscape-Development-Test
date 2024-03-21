using UnityEngine;
using UnityEngine.UI;
using Project.SteamworksIntegrations;
using Steamworks;
using System;
using TMPro;

namespace Project.Menu
{
    public sealed class MainMenu : MonoBehaviour
    {
        private static MainMenu Instance;

        [SerializeField] private Button _createLobbyButton;
        [SerializeField] private Button _connectButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private TMP_InputField _idInputField;
        [SerializeField] private GameObject _lobbyPanel;
        [SerializeField] private GameObject _backButton;

        private void Awake()
        {
            Instance = this;

            _createLobbyButton.onClick.AddListener(() => SteamworksManager.CreateLobby());
            _connectButton.onClick.AddListener(() => SteamworksManager.JoinLobby(new CSteamID(Convert.ToUInt64(_idInputField.text))));
            _exitButton.onClick.AddListener(() => Application.Quit());
        }

        public static void LobbyEntered()
        {
            Instance._lobbyPanel.SetActive(true);
            Instance._backButton.SetActive(true);
            Instance.gameObject.SetActive(false);
        }
    }
}
