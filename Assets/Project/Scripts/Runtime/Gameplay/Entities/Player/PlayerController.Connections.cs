using FishNet.Object;
using Project.Entities.Player.Actions;
using Cinemachine;

namespace Project.Entities.Player
{
    public sealed partial class PlayerController : NetworkBehaviour
    {
        private PlayerActions _inputs;

        public override void OnStartClient()
        {
            base.OnStartClient();

            if (IsOwner)
            {
                _inputs = new PlayerActions(this);
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
