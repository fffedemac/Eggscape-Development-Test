namespace Project.Entities.Player.Actions
{
    // Class for generating actions where
    // inputs need to be updated frame by frame during execution.
    public abstract class PlayerActionUpdateable : PlayerAction
    {
        protected PlayerActionUpdateable(PlayerInputActions.PlayerActions playerActions, PlayerController controller) : base(playerActions, controller)
        {
            _playerActions = playerActions;
            _controller = controller;
        }

        // Adds the update method to continue
        // playing the action.
        public abstract void OnUpdate();
        public abstract override void OnEnable();
        public abstract override void OnDisable();
    }
}
