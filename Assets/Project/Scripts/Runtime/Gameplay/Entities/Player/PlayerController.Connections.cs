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
            // Registers the player instance to notify the Host
            // about when the game can start.
            GameManager.Instance.PlayerConnected(this);

            // Assigns all necessary resources for the player's operation
            // only if the instance is the owner.
            // If the instance is not the owner, disables it to prevent operation execution on it.
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
