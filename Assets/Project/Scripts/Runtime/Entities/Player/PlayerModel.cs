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

        [field: SyncVar] public bool IsBlocking {  get; set; }

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
    }
}
