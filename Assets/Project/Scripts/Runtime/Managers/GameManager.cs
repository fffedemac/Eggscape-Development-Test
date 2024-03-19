using UnityEngine;
using Project.Entities.Player;
using FishNet.Object;
using FishNet.Object.Synchronizing;

namespace Project.Managers
{
    public sealed class GameManager : NetworkBehaviour
    {
        public static GameManager Instance { get; private set; }

        [SyncObject] private readonly SyncList<PlayerNetwork> _players = new SyncList<PlayerNetwork>();
        [SyncVar] public bool canStart;

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            if (!IsServer) return;

            canStart = true;
            foreach (PlayerNetwork player in _players)
            {
                if (!player.IsReady)
                {
                    canStart = false;
                    break;
                }
            }
        }

        public SyncList<PlayerNetwork> Players => _players;
    }
}
