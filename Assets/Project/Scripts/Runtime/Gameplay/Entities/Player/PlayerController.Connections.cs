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
            GameManager.Instance.PlayerConnected(this);

            if (IsOwner)
            {
                _inputs = new PlayerActionsController(this);
                CinemachineVirtualCamera playerCamera = FindObjectOfType<CinemachineVirtualCamera>();
                playerCamera.Follow = transform;
            }
            else
                enabled = false;
        }

        public override void OnStopClient()
        {
            if (IsOwner)
                _inputs.OnDisable();
        }

        public override void OnStopServer() => GameManager.Instance.Players.Remove(this);
    }
}
