using UnityEngine;
using System.Collections.Generic;
using Project.Entities.Player;
using Project.Behaviours.HealthComponent;

namespace Project.WeaponSystem
{
    public partial class MeleeWeapon : Weapon
    {
        private List<HealthComponent> _damagedObjects = new List<HealthComponent>();

        // Locally checks if the hit entity was in the list.
        // This ensures not hitting more than once per action on the entity.
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

        // If the entity was not in the list, it deals damage
        // to it and synchronizes it with the rest of the clients.
        // Then adds the entity to the list to avoid dealing damage to it again.
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
