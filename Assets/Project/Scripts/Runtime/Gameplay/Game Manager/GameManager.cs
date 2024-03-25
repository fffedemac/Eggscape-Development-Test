using FishNet.Object;
using FishNet.Object.Synchronizing;
using Project.Entities.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Project
{
    public sealed class GameManager : NetworkBehaviour
    {
        public static GameManager Instance;

        [SyncObject] public readonly SyncList<PlayerController> Players = new SyncList<PlayerController>();
        [SerializeField] private Button _startGameButton;
        [SerializeField] private GameObject _lobbyPanel;

        private void Awake()
        {
            Instance = this;

            _startGameButton.onClick.AddListener(() => RPC_StartGame());
        }

        public void PlayerConnected(PlayerController player)
        {
            if (!Players.Contains(player))
                Players.Add(player);

            if (Players.Count > 1)
            {
                if (IsHost)
                    _startGameButton.gameObject.SetActive(true);
            }
        }

        [ServerRpc(RequireOwnership = false)]
        private void RPC_StartGame() => StartGame();

        [ObserversRpc]
        private void StartGame()
        {
            foreach (PlayerController player in Players)
                player.PausePlayer(false);

            _lobbyPanel.SetActive(false);
        }
    }
}
