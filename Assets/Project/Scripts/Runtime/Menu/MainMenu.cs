using UnityEngine;
using UnityEngine.UI;
using FishNet;
using TMPro;
using System.Text;
using Project.SteamworksIntegrations;

namespace Project.Menu
{
    public sealed class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _createLobbyButton;
        [SerializeField] private Button _connectButton;

        private void Awake()
        {
            _createLobbyButton.onClick.AddListener(() => SteamworksManager.CreateLobby());
        }
    }
}
