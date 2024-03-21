using UnityEngine;
using UnityEngine.UI;
using FishNet.Object;

namespace Project.Entities.Player
{
    public sealed class PlayerUI : NetworkBehaviour
    {
        [SerializeField] private Slider _healthSlider;

        [ServerRpc(RequireOwnership = false)]
        public void RPC_UpdateHealthSlider(int currentHealth, int maxHealth)
        {
            UpdateHealthSlider(currentHealth, maxHealth);
        }

        [ObserversRpc]
        public void UpdateHealthSlider(int currentHealth, int maxHealth)
        {
            _healthSlider.value = (float)currentHealth / (float)maxHealth;
        }
    }
}
