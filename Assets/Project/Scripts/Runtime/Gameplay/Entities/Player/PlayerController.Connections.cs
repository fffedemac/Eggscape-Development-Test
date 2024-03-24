using FishNet.Object;
using Project.Entities.Player.Actions;
using Cinemachine;

namespace Project.Entities.Player
{
    public sealed partial class PlayerController : NetworkBehaviour
    {
        private PlayerActionsController _inputs;

        public override void OnStartClient()
        {
            if (IsOwner)
            {
                _inputs = new PlayerActionsController(this);
                CinemachineVirtualCamera playerCamera = FindObjectOfType<CinemachineVirtualCamera>();
                playerCamera.Follow = transform;
            }
            else
                enabled = false;
        }

        public override void OnStopClient() => _inputs.OnDisable();
        public override void OnStartServer() => GameManager.Instance.Players.Add(this);
        public override void OnStopServer() => GameManager.Instance.Players.Remove(this);
    }
}
