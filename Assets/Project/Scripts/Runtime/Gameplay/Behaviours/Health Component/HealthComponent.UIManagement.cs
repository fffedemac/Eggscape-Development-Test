using UnityEngine;
using FishNet.Object;
using UnityEngine.UI;

namespace Project.Behaviours.HealthComponent
{
    public sealed partial class HealthComponent : NetworkBehaviour
    {
        [SerializeField] private Slider _healthSlider;

        [ServerRpc(RequireOwnership = false)]
        public void RPC_UpdateHealthSlider()
        {
            UpdateHealthSlider(_currentHealth, _maxHealth);
        }

        [ObserversRpc]
        public void UpdateHealthSlider(int currentHealth, int maxHealth)
        {
            _healthSlider.value = (float)currentHealth / (float)maxHealth;
        }
    }
}
