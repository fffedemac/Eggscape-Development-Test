using UnityEngine;
using Project.Entities.Player.Actions;

namespace Project.Entities.Player
{
    public sealed class PlayerController : MonoBehaviour, IDamageable
    {
        [field: SerializeField] public PlayerModel Model {  get; private set; }
        [field: SerializeField] public PlayerView View { get; private set; }
        public bool IsBlocking { get; private set; }

        private PlayerActions _inputs;

        private void Awake()
        {
            _inputs = new PlayerActions(this);
        }

        private void FixedUpdate()
        {
            _inputs.OnUpdate();
        }

        public void TakeDamage(float damage)
        {
            Model.CurrentHealth -= damage;
            if (Model.CurrentHealth <= 0)
                Die();
        }

        public void Die()
        {
            Debug.Log("Player Death");
        }
    }
}
