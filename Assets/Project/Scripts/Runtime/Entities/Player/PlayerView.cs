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

            if (!IsOwner)
            {
                enabled = false;
                return;
            }
        }

        [ObserversRpc]
        private void ChangeMeshColor()
        {
            if (IsOwner)
                _meshRenderer.material = _ownerMaterial;
        }

        [ServerRpc(RequireOwnership = false)]
        public void PlayAnimationServer(string animationName)
        {
            PlayAnimation(animationName);
        }

        [ObserversRpc]
        public void PlayAnimation(string animationName)
        {
            _animator.StopPlayback();
            _animator.Play(animationName);
        }
    }
}
