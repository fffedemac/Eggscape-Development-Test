using UnityEngine;

namespace Project.Entities.Player
{
    public sealed class PlayerModel : MonoBehaviour
    {
        [field: SerializeField] public float Speed {  get; private set; }
        [field: SerializeField] public float MaxHealth {  get; private set; }
        public float CurrentHealth {  get; private set; }
        [field: SerializeField] public Rigidbody Rigidbody {  get; private set; }
        [field: SerializeField] public BoxCollider MeleeWeaponCollider {  get; private set; }
        public bool IsAttacking {  get; set; }
        public bool IsBlocking {  get; set; }
    }
}
