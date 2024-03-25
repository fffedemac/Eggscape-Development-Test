using UnityEngine;
using UnityEngine.InputSystem;

namespace Project.Entities.Player.Actions
{
    public sealed class ActionRotate : PlayerAction
    {
        private PlayerModel _model;
        private Vector2 _dir;
        private float _rotationAngle;
        private Vector2 _screenCenter;

        public ActionRotate(PlayerInputActions.PlayerActions playerActions, PlayerController controller) : base(playerActions, controller)
        {
            _playerActions = playerActions;
            _model = controller.Model;
            _screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        }

        private void UpdateRotation(InputAction.CallbackContext context)
        {
            if (_model.Weapon.IsAttacking) return;

            _dir = context.ReadValue<Vector2>();
            if (_dir != Vector2.zero)
            {
                _rotationAngle = Mathf.Atan2(_dir.x, _dir.y) * Mathf.Rad2Deg;
                _model.Player_Root.transform.rotation = Quaternion.Euler(0, _rotationAngle, 0);
            }
        }

        private void UpdateRotationMouse(InputAction.CallbackContext context)
        {
            if (_model.Weapon.IsAttacking) return;

            _dir = context.ReadValue<Vector2>() - _screenCenter;
            _rotationAngle = Mathf.Atan2(_dir.x, _dir.y) * Mathf.Rad2Deg;
            _model.Player_Root.transform.rotation = Quaternion.Euler(0, _rotationAngle, 0);
        }

        public override void OnEnable()
        {
            _playerActions.RotateMouse.performed += UpdateRotationMouse;
            _playerActions.Rotate.performed += UpdateRotation;
        }

        public override void OnDisable()
        {
            _playerActions.RotateMouse.performed -= UpdateRotationMouse;
            _playerActions.Rotate.performed -= UpdateRotation;
        }
    }
}
