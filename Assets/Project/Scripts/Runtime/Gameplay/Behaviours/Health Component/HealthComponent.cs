using UnityEngine;
using FishNet.Object;
using System.Collections.Generic;

namespace Project.Behaviours.HealthComponent
{
    public sealed partial class HealthComponent : NetworkBehaviour
    {
        [SerializeField] private int _maxHealth;
        private int _currentHealth;
        private List<IHealthObservable> _healthObservables = new List<IHealthObservable>();

        public override void OnStartClient()
        {
            _currentHealth = _maxHealth;

            if (!IsOwner) 
                enabled = false;
        }

        #region Handle Damage
        // This RPC should require ownership since being called through another component
        // prevents it from being executed x number of times per user/player.
        [ServerRpc]
        public void RPC_TakeDamage(int damage) => TakeDamage(damage);

        [ObserversRpc]
        private void TakeDamage(int damage)
        {
            _currentHealth -= damage;

            if (_healthSlider != null)
                RPC_UpdateHealthSlider();

            if (_currentHealth <= 0)
            {
                foreach (IHealthObservable item in _healthObservables)
                    item.OnHealthNotify();
            }
        }
        #endregion

        #region Reset Values
        // Returns the original values.
        // Used for when the entity respawns.
        [ServerRpc(RequireOwnership = false)]
        public void RPC_ResetValues() => ResetValues();

        [ObserversRpc]
        private void ResetValues()
        {
            _currentHealth = _maxHealth;

            if (_healthSlider != null)
                RPC_UpdateHealthSlider();
        }
        #endregion

        public void RegisterObservable(IHealthObservable observable)
        {
            if (!_healthObservables.Contains(observable))
                _healthObservables.Add(observable);
        }
    }
}
