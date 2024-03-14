using UnityEngine.InputSystem;
using Project.WeaponSystem;

namespace Project.Entities.Player.Actions
{
    public sealed class ActionBlock
    {
        private PlayerController _controller;
        private Weapon _playerWeapon;

        public ActionBlock(PlayerInputActions.PlayerActions playerActions, PlayerController controller)
        {
            _controller = controller;
            _playerWeapon = _controller.Model.Weapon;

            playerActions.Block.started += OnStartBlocking;
            playerActions.Block.performed += OnBlocking;
            playerActions.Block.canceled += OnReleaseBlocking;
        }

        private void OnStartBlocking(InputAction.CallbackContext context)
        {
            if (_playerWeapon.IsAttacking) return;
            _controller.View.PlayAnimation("StartBlocking");
        }

        private void OnBlocking(InputAction.CallbackContext context)
        {
            if (_playerWeapon.IsAttacking) return;
            _controller.View.PlayAnimation("Blocking");
            _controller.Model.IsBlocking = true;
        }

        private void OnReleaseBlocking(InputAction.CallbackContext context)
        {
            if (_playerWeapon.IsAttacking) return;
            _controller.View.PlayAnimation("ReleaseBlocking");
            _controller.Model.IsBlocking = false;
        }
    }
}
