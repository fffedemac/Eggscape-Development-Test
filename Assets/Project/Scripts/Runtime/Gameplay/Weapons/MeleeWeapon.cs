using UnityEngine;
using System.Collections;
using FishNet.Object;

namespace Project.WeaponSystem
{
    public partial class MeleeWeapon : Weapon
    {
        [field: SerializeField] public float TimeAttacking {  get; private set; }
        private Coroutine AttackCoroutine;

        // Synchronizes the weapon state with the rest of the clients.
        [ServerRpc(RequireOwnership = false)]
        public override void RPC_PerformAttack() => PerformAttack();

        [ObserversRpc]
        public override void PerformAttack()
        {
            if (IsAttacking) return;

            if (AttackCoroutine == null)
                AttackCoroutine = StartCoroutine(Attack());
            else
            {
                StopCoroutine(AttackCoroutine);
                AttackCoroutine = StartCoroutine(Attack());
            }
        }

        private IEnumerator Attack()
        {
            IsAttacking = true;
            yield return new WaitForSeconds(TimeAttacking);
            IsAttacking = false;

            // Entities are cleared from the list each time the action ends.
            _damagedObjects.Clear();
        }
    }
}
