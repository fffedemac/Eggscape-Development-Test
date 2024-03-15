using UnityEngine.InputSystem;

namespace Project.Entities.Player.Actions
{
    public sealed class ActionMeleeAttack
    {
        private PlayerController _controller;
        private PlayerModel _model;

        public ActionMeleeAttack(PlayerInputActions.PlayerActions playerActions, PlayerController controller)
        {
            _controller = controller;
            _model = controller.Model;
            playerActions.Attack.performed += OnMeleeAttack;
        }

        private void OnMeleeAttack(InputAction.CallbackContext context)
        {
            if (_model.IsBlocking || _model.Weapon.IsAttacking) return;

            _model.Weapon.PerformAttack();
            _controller.View.PlayAnimation("MeleeAttack");
        }
    }
}
