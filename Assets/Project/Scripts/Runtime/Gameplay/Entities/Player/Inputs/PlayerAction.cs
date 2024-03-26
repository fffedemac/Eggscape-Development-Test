namespace Project.Entities.Player.Actions
{
    // Class for generating actions where
    // inputs are triggered only once per execution.
    public abstract class PlayerAction
    {
        protected PlayerController _controller;
        protected PlayerInputActions.PlayerActions _playerActions;

        protected PlayerAction(PlayerInputActions.PlayerActions playerActions, PlayerController controller)
        {
            _playerActions = playerActions;
            _controller = controller;
        }

        // Methods to register or unregister the actions that
        // each input will perform.
        public abstract void OnEnable();
        public abstract void OnDisable();
    }
}
