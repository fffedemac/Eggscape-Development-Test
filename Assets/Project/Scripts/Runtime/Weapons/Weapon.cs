using FishNet.Object;
using UnityEngine;

namespace Project.WeaponSystem
{
    public abstract class Weapon : NetworkBehaviour
    {
        [field: SerializeField] public int Damage {  get; private set; }
        public bool IsAttacking { get; set; }
        public abstract void RPC_PerformAttack();
        public abstract void PerformAttack();
    }
}
