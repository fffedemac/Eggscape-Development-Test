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

        // Changes the color of the owner to identify their character.
        // Since this feature only affects the owner of the instance,
        // there is no need for the method to be executed as an RPC.
        private void ChangeMeshColor() => _meshRenderer.material = _ownerMaterial;

        // Synchronizes the execution of the animation with other clients
        // only when required.
        // This way, it becomes more efficient than using the Network Animator.
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
