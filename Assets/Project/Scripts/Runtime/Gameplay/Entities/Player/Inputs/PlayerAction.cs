namespace Project.Entities.Player.Actions
{
    public abstract class PlayerAction
    {
        protected PlayerController _controller;
        protected PlayerInputActions.PlayerActions _playerActions;

        protected PlayerAction(PlayerInputActions.PlayerActions playerActions, PlayerController controller)
        {
            _playerActions = playerActions;
            _controller = controller;
        }

        public abstract void OnEnable();
        public abstract void OnDisable();
    }
}
