using UnityEngine.InputSystem;
using System.Threading.Tasks;

namespace Project.Entities.Player.Actions
{
    public sealed class ActionAttack
    {
        private PlayerController _controller;
        private PlayerModel _model;

        public ActionAttack(PlayerInputActions.PlayerActions playerActions, PlayerController controller)
        {
            _controller = controller;
            _model = controller.Model;
            playerActions.Attack.started += OnAttack;
        }

        private async void OnAttack(InputAction.CallbackContext context)
        {
            if (_model.IsBlocking) return;

            _model.IsAttacking = true;
            _model.MeleeWeaponCollider.enabled = true;
            _controller.View.PlayAnimation("MeleeAttack");

            await ReleaseAttack();
        }

        public async Task ReleaseAttack()
        {
            await Task.Delay(700);
            _model.MeleeWeaponCollider.enabled = false;
            _model.IsAttacking = false;
        }
    }
}
