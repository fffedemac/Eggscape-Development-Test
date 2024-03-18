using UnityEngine;
using FishNet.Object;

namespace Project.Entities.Player
{
    public sealed class PlayerView : NetworkBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private Material _ownerMaterial;

        public override void OnStartClient()
        {
            base.OnStartClient();
            ChangeMeshColor();
        }

        [ObserversRpc]
        private void ChangeMeshColor()
        {
            if (IsOwner)
                _meshRenderer.material = _ownerMaterial;
        }

        public void PlayAnimation(string animationName)
        {
            if (!IsOwner) return;

            _animator.StopPlayback();
            _animator.Play(animationName);
        }
    }
}
