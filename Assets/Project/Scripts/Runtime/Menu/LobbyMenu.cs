using UnityEngine;
using UnityEngine.UI;
using Project.SteamworksIntegrations;
using Steamworks;
using System;
using TMPro;

namespace Project.Menu
{
    public sealed class LobbyMenu : MonoBehaviour
    {
        [SerializeField] private TMP_Text _playersText;
        [SerializeField] private TMP_Text _matchStatusText;
        [SerializeField] private Button _readyButton;
        [SerializeField] private Button _startButton;
        [SerializeField] private GameObject _lobbyPlayerData;
    }
}
