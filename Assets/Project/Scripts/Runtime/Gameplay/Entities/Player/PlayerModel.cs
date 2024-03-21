using UnityEngine;
using Project.WeaponSystem;
using FishNet.Object;
using FishNet.Object.Synchronizing;

namespace Project.Entities.Player
{
    public sealed class PlayerModel : NetworkBehaviour
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField, SyncVar] public int MaxHealth { get; private set; }
        [field: SerializeField, SyncVar] public int CurrentHealth {  get; set; }

        [field: SerializeField] public Rigidbody Rigidbody {  get; private set; }
        [field: SerializeField] public Weapon Weapon {  get; private set; }

        public bool IsBlocking {  get; set; }
        [field: SerializeField] public bool IsPaused { get; set; } = true;

        public override void OnStartClient()
        {
            base.OnStartClient();
            CurrentHealth = MaxHealth;

            if (!IsOwner)
            {
                enabled = false;
                return;
            }
        }

        [ServerRpc(RequireOwnership = false)]
        public void RPC_SetBlocking(bool value) => SetBlocking(value);

        [ObserversRpc]
        public void SetBlocking(bool value) => IsBlocking = value;
    }
}
