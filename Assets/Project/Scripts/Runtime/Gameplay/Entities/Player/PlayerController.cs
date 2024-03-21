using UnityEngine;
using Project.Entities.Player.Actions;
using FishNet.Object;
using Cinemachine;

namespace Project.Entities.Player
{
    public sealed class PlayerController : NetworkBehaviour, IDamageable
    {
        [field: SerializeField] public PlayerModel Model {  get; private set; }
        [field: SerializeField] public PlayerView View { get; private set; }
        [field: SerializeField] public PlayerUI Interface { get; private set; }
        private PlayerActions _inputs;

        public override void OnStartClient()
        {
            base.OnStartClient();

            if (IsOwner)
            {
                _inputs = new PlayerActions(this);
                CinemachineVirtualCamera playerCamera = FindObjectOfType<CinemachineVirtualCamera>();
                playerCamera.Follow = transform;
            }
            else
                enabled = false;
        }

        private void FixedUpdate()
        {
            if (!Model.IsReady) return;
            _inputs?.OnUpdate();
        }

        [ServerRpc(RequireOwnership = false)]
        public void RPC_TakeDamage(int damage) => TakeDamage(damage);

        [ObserversRpc]
        public void TakeDamage(int damage)
        {
            if (Model.IsBlocking)
                damage = damage / 3;

            Model.CurrentHealth -= damage;
            Interface.RPC_UpdateHealthSlider(Model.CurrentHealth, Model.MaxHealth);

            if (Model.CurrentHealth <= 0)
                Die();
        }

        public void Die()
        {
            Debug.Log("Player Death");
        }

        public override void OnStopClient()
        {
            base.OnStopClient();
            if (IsOwner)
                _inputs.OnDisable();
        }
    }
}
