using UnityEngine;

namespace Project.Entities.Player.Actions
{
    public sealed class ActionMovement : PlayerActionUpdateable
    {
        private Rigidbody _rigidbody;
        private Vector2 _inputValue;
        private Vector3 _dir;

        public ActionMovement(PlayerInputActions.PlayerActions playerActions, PlayerController controller) : base(playerActions, controller)
        {
            _playerActions = playerActions;
            _controller = controller;
            _rigidbody = controller.Model.Rigidbody;
        }

        public override void OnUpdate()
        {
            _inputValue = _playerActions.Move.ReadValue<Vector2>();

            if (_inputValue != Vector2.zero)
            {
                _dir = new Vector3(_inputValue.x, 0, _inputValue.y);
                _rigidbody.MovePosition(_controller.transform.position + _dir * _controller.Model.Speed * Time.deltaTime);
            }
        }

        public override void OnEnable() => _playerActions.Move.Enable();

        public override void OnDisable() => _playerActions.Move.Disable();

        
    }
}
