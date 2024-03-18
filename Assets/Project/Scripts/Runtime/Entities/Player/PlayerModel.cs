using UnityEngine;
using Project.WeaponSystem;
using FishNet.Object;
using FishNet.Object.Synchronizing;

namespace Project.Entities.Player
{
    public sealed class PlayerModel : NetworkBehaviour
    {
        [field: SyncVar] public PlayerNetwork PlayerOwner {  get; private set; }

        [field: SerializeField] public float Speed {  get; private set; }
        [field: SerializeField] public float MaxHealth {  get; private set; }
        public float CurrentHealth {  get; set; }

        [field: SerializeField] public Rigidbody Rigidbody {  get; private set; }
        [field: SerializeField] public Weapon Weapon {  get; private set; }

        public bool IsBlocking {  get; set; }
    }
}
