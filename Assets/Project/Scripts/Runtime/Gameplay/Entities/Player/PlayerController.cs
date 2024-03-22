using UnityEngine;
using FishNet.Object;

namespace Project.Entities.Player
{
    public sealed partial class PlayerController : NetworkBehaviour, IDamageable
    {
        public PlayerModel Model {  get; private set; }
        public PlayerView View { get; private set; }
        private PlayerUI _ui;

        private void Awake()
        {
            Model = GetComponent<PlayerModel>();
            View = GetComponent<PlayerView>();
            _ui = GetComponent<PlayerUI>();
        }

        private void FixedUpdate()
        {
            if (Model.IsPaused) return;
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
            _ui.RPC_UpdateHealthSlider(Model.CurrentHealth, Model.MaxHealth);

            if (Model.CurrentHealth <= 0)
                RPC_Die();
        }

        [ServerRpc(RequireOwnership = false)]
        public void RPC_Die() => Die();

        [ObserversRpc]
        public void Die()
        {
            Debug.Log("Player Death");
        }
    }
}
