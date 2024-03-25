namespace Project.Entities.Player.Actions
{
    public sealed class PlayerActionsController
    {
        private PlayerInputActions _inputs;
        private PlayerAction[] _playerActions;
        private PlayerActionUpdateable[] _playerActionsUpdateables;

        public PlayerActionsController(PlayerController controller)
        {
            _inputs = new PlayerInputActions();
            _inputs.Enable();

            _playerActions = new PlayerAction[3]
            {
                new ActionRotate(_inputs.Player, controller),
                new ActionMeleeAttack(_inputs.Player, controller),
                new ActionBlock(_inputs.Player, controller)
            };

            _playerActionsUpdateables = new PlayerActionUpdateable[1]
            {
                new ActionMovement(_inputs.Player, controller)
            };
        }

        public void OnUpdate()
        {
            foreach (PlayerActionUpdateable action in _playerActionsUpdateables)
                action.OnUpdate();
        }

        public void OnEnable()
        {
            foreach (PlayerAction action in _playerActions)
                action.OnEnable();
        }

        public void OnDisable()
        {
            foreach (PlayerAction action in _playerActions)
                action.OnDisable();
        }
    }
}
