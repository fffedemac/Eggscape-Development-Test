using UnityEngine.InputSystem;
using Project.WeaponSystem;

namespace Project.Entities.Player.Actions
{
    public sealed class ActionBlock
    {
        private PlayerInputActions.PlayerActions _playerActions;
        private PlayerController _controller;
        private Weapon _playerWeapon;

        public ActionBlock(PlayerInputActions.PlayerActions playerActions, PlayerController controller)
        {
            _controller = controller;
            _playerWeapon = _controller.Model.Weapon;

            _playerActions = playerActions;
            playerActions.Block.started += OnStartBlocking;
            playerActions.Block.performed += OnBlocking;
        }

        private void OnStartBlocking(InputAction.CallbackContext context)
        {
            if (_playerWeapon.IsAttacking)
            {
                _playerActions.Block.canceled -= OnReleaseBlocking;
                return;
            }

            _playerActions.Block.canceled += OnReleaseBlocking;
            _controller.View.RPC_PlayAnimation("StartBlocking");
        }

        private void OnBlocking(InputAction.CallbackContext context)
        {
            if (_playerWeapon.IsAttacking) return;

            _controller.View.RPC_PlayAnimation("Blocking");
            _controller.Model.RPC_SetBlocking(true);
        }

        private void OnReleaseBlocking(InputAction.CallbackContext context)
        {
            if (_playerWeapon.IsAttacking) return;

            _controller.View.RPC_PlayAnimation("ReleaseBlocking");
            _controller.Model.RPC_SetBlocking(false);
            _playerActions.Block.canceled -= OnReleaseBlocking;
        }
    }
}
