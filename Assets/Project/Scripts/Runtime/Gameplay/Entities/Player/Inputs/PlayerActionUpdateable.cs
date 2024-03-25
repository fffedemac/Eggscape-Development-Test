namespace Project.Entities.Player.Actions
{
    public abstract class PlayerActionUpdateable : PlayerAction
    {
        protected PlayerActionUpdateable(PlayerInputActions.PlayerActions playerActions, PlayerController controller) : base(playerActions, controller)
        {
            _playerActions = playerActions;
            _controller = controller;
        }

        public abstract void OnUpdate();
        public abstract override void OnEnable();
        public abstract override void OnDisable();
    }
}
