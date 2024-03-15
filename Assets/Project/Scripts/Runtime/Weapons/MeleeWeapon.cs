using UnityEngine;
using System.Collections;

namespace Project.WeaponSystem
{
    public class MeleeWeapon : Weapon
    {
        [field: SerializeField] public float TimeAttacking {  get; private set; }

        private Coroutine AttackCoroutine;

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
            if (IsAttacking) return;

            if (other.gameObject.layer == 6)
                other.GetComponent<IDamageable>()?.TakeDamage(Damage);
        }
    }
}
