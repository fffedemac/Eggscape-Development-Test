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
            _meshRenderer = GetComponentInChildren<MeshRenderer>();
        }

        public override void OnStartClient()
        {
            if (!IsOwner)
            {
                enabled = false;
                return;
            }

            ChangeMeshColor();
        }

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
