using UnityEngine;

namespace Project.Entities.Player.Actions
{
    public sealed class ActionMovement
    {
        private PlayerController _controller;
        private PlayerInputActions.PlayerActions _playerActions;

        private Rigidbody _rigidbody;
        private Vector2 _inputValue;
        private Vector3 _dir;

        public ActionMovement(PlayerInputActions.PlayerActions playerActions, PlayerController controller)
        {
            _playerActions = playerActions;
            _controller = controller;
            _rigidbody = controller.Model.Rigidbody;
        }

        public void OnUpdate()
        {
            _inputValue = _playerActions.Move.ReadValue<Vector2>();

            if (_inputValue != Vector2.zero )
            {
                _dir = new Vector3(_inputValue.x, 0, _inputValue.y);
                _rigidbody.MovePosition(_controller.transform.position + _dir * _controller.Model.Speed * Time.deltaTime);
            }
        }
    }
}
