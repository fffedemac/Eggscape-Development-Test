using UnityEngine;
using System.Collections;
using FishNet.Object;
using Project.Entities.Player;
using Project.Behaviours.HealthComponent;

namespace Project.WeaponSystem
{
    public class MeleeWeapon : Weapon
    {
        [field: SerializeField] public float TimeAttacking {  get; private set; }

        private Coroutine AttackCoroutine;

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
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (!IsAttacking) return;

            if (other.gameObject.layer == 6)
            {
                int tempDamage = Damage;
                if ((bool)other.GetComponent<PlayerModel>()?.IsBlocking)
                    tempDamage = Damage / 3;

                other.GetComponent<HealthComponent>()?.RPC_TakeDamage(tempDamage);
            }
                
        }
    }
}
