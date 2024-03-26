using UnityEngine;
using Project.WeaponSystem;
using FishNet.Object;

namespace Project.Entities.Player
{
    public sealed class PlayerModel : NetworkBehaviour
    {
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public Rigidbody Rigidbody {  get; private set; }
        [field: SerializeField] public GameObject Player_Root {  get; private set; }
        [field: SerializeField] public Weapon Weapon {  get; private set; }

        public bool IsBlocking {  get; set; }

        // This way, the state of the variable is synchronized
        // only when it is called.
        // It is a more efficient way than using [SyncVar].
        [ServerRpc(RequireOwnership = false)]
        public void RPC_SetBlocking(bool value) => SetBlocking(value);

        [ObserversRpc]
        public void SetBlocking(bool value) => IsBlocking = value;
    }
}
