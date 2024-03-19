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
            _controller.View.PlayAnimationServer("StartBlocking");
        }

        private void OnBlocking(InputAction.CallbackContext context)
        {
            if (_playerWeapon.IsAttacking) return;

            _controller.View.PlayAnimationServer("Blocking");
            _controller.Model.IsBlocking = true;
        }

        private void OnReleaseBlocking(InputAction.CallbackContext context)
        {
            if (_playerWeapon.IsAttacking) return;

            _controller.View.PlayAnimationServer("ReleaseBlocking");
            _controller.Model.IsBlocking = false;
            _playerActions.Block.canceled -= OnReleaseBlocking;
        }
    }
}
