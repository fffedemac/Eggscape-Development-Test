using UnityEngine;
using FishNet.Object;

namespace Project.Entities.Player
{
    public sealed class PlayerView : NetworkBehaviour
    {
        private Animator _animator;
        private MeshRenderer _meshRenderer;
        [SerializeField] private Material _ownerMaterial;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        public override void OnStartClient()
        {
            ChangeMeshColor();

            if (!IsOwner)
                enabled = false;
        }

        [ObserversRpc]
        private void ChangeMeshColor() => _meshRenderer.material = _ownerMaterial;

        [ServerRpc(RequireOwnership = false)]
        public void RPC_PlayAnimation(string animationName) => PlayAnimation(animationName);

        [ObserversRpc]
        private void PlayAnimation(string animationName)
        {
            _animator.StopPlayback();
            _animator.Play(animationName);
        }
    }
}
