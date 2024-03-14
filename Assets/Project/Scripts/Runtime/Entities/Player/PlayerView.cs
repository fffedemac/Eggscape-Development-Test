using UnityEngine;

namespace Project.Entities.Player
{
    public sealed class PlayerView : MonoBehaviour
    {
        [field: SerializeField] public Animator Animator {  get; private set; }

        public void PlayAnimation(string animationName)
        {
            Animator.StopPlayback();
            Animator.Play(animationName);
        }
    }
}
