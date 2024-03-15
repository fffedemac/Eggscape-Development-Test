using UnityEngine;

namespace Project.WeaponSystem
{
    public abstract class Weapon : MonoBehaviour
    {
        [field: SerializeField] public int Damage {  get; private set; }
        public bool IsAttacking { get; set; }
        public abstract void PerformAttack();
    }
}
