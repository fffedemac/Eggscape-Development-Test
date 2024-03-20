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
        [SerializeField] private Button _createLobbyButton;
        [SerializeField] private Button _connectButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private TMP_InputField _idInputField;

        private void Awake()
        {
            _createLobbyButton.onClick.AddListener(() => SteamworksManager.CreateLobby());
            _connectButton.onClick.AddListener(() => SteamworksManager.JoinLobby(new CSteamID(Convert.ToUInt64(_idInputField.text))));
            _exitButton.onClick.AddListener(() => Application.Quit());
        }
    }
}
