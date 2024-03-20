using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Entities.Player.Actions
{
    public sealed class ActionRotate
    {
        private PlayerController _controller;
        private PlayerInputActions.PlayerActions _playerActions;

        private Vector2 _dir;
        private float _rotationAngle;
        private Vector2 _screenCenter;

        public ActionRotate(PlayerInputActions.PlayerActions playerActions, PlayerController controller)
        {
            _playerActions = playerActions;
            _controller = controller;
            _screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
            playerActions.RotateMouse.performed += UpdateRotationMouse;
            playerActions.Rotate.performed += UpdateRotation;
        }

        private void UpdateRotation(InputAction.CallbackContext context)
        {
            if (_controller.Model.Weapon.IsAttacking) return;

            _dir = context.ReadValue<Vector2>();
            if (_dir != Vector2.zero)
            {
                _rotationAngle = Mathf.Atan2(_dir.x, _dir.y) * Mathf.Rad2Deg;
                _controller.transform.rotation = Quaternion.Euler(0, _rotationAngle, 0);
            }
        }

        private void UpdateRotationMouse(InputAction.CallbackContext context)
        {
            if (_controller.Model.Weapon.IsAttacking) return;

            _dir = context.ReadValue<Vector2>() - _screenCenter;
            _rotationAngle = Mathf.Atan2(_dir.x, _dir.y) * Mathf.Rad2Deg;
            _controller.transform.rotation = Quaternion.Euler(0, _rotationAngle, 0);
        }
    }
}
