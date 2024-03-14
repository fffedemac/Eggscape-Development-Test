using UnityEngine;

namespace Project.Entities.Player
{
    public sealed class PlayerModel : MonoBehaviour
    {
        [field: SerializeField] public float Speed {  get; private set; }
    }
}
