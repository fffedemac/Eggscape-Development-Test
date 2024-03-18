using UnityEngine;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using Project.Managers;

namespace Project.Entities.Player
{
    public sealed class PlayerNetwork : NetworkBehaviour
    {
        [field: SyncVar] public string Nickname { get; set; }
        [field: SyncVar] public bool IsReady { get; set; }
        [field: SyncVar] public PlayerModel PlayerModel { get; set; }

        private void Update()
        {
            if (!IsOwner) return;


        }

        public override void OnStartServer()
        {
            base.OnStartServer();

            GameManager.Instance.Players.Add(this);
        }

        public override void OnStopServer()
        {
            base.OnStartServer();

            GameManager.Instance.Players.Remove(this);
        }

        [ServerRpc]
        public void ServerSetIsReady()
        {
            IsReady = !IsReady;
        }
    }
}
