using UnityEngine;
using System.Collections.Generic;
using Project.Entities.Player;
using Project.Behaviours.HealthComponent;

namespace Project.WeaponSystem
{
    public partial class MeleeWeapon : Weapon
    {
        private List<HealthComponent> _damagedObjects = new List<HealthComponent>();

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (!IsAttacking) return;
            if (other.gameObject.layer != 6) return;

            if (other.TryGetComponent(out HealthComponent damageableObject))
            {
                if (!_damagedObjects.Contains(damageableObject))
                    DoDamage(damageableObject);
            }
        }

        private void DoDamage(HealthComponent damageableObject)
        {
            int tempDamage = Damage;

            if ((bool)damageableObject.GetComponent<PlayerModel>()?.IsBlocking)
                tempDamage = Damage / 3;

            damageableObject.RPC_TakeDamage(tempDamage);

            _damagedObjects.Add(damageableObject);
        }
    }
}
