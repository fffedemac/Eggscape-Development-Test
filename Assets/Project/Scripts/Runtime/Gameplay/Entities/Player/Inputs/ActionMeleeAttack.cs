using UnityEngine.InputSystem;

namespace Project.Entities.Player.Actions
{
    public sealed class ActionMeleeAttack : PlayerAction
    {
        private PlayerModel _model;

        public ActionMeleeAttack(PlayerInputActions.PlayerActions playerActions, PlayerController controller) : base(playerActions, controller)
        {
            _playerActions = playerActions;
            _controller = controller;
            _model = controller.Model;
        }

        private void OnMeleeAttack(InputAction.CallbackContext context)
        {
            if (_model.IsBlocking || _model.Weapon.IsAttacking) return;

            _model.Weapon.RPC_PerformAttack();
            _controller.View.RPC_PlayAnimation("MeleeAttack");
        }

        public override void OnEnable() => _playerActions.Attack.performed += OnMeleeAttack;
        public override void OnDisable() => _playerActions.Attack.performed -= OnMeleeAttack;
    }
}
