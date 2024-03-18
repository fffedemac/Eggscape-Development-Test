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
        private PlayerActions _inputs;

        public override void OnStartClient()
        {
            base.OnStartClient();
            if (!IsOwner) return;

            _inputs = new PlayerActions(this);
            CinemachineVirtualCamera playerCamera = FindObjectOfType<CinemachineVirtualCamera>();
            playerCamera.Follow = transform;
        }

        private void FixedUpdate()
        {
            if (!IsOwner) return;
            _inputs.OnUpdate();
        }

        public void TakeDamage(int damage)
        {
            if (!IsOwner) return;

            if (Model.IsBlocking)
                damage = damage / 3;

            Model.CurrentHealth -= damage;
            if (Model.CurrentHealth <= 0)
                Die();
        }

        public void Die()
        {
            if (!IsOwner) return;

            Debug.Log("Player Death");
        }
    }
}
