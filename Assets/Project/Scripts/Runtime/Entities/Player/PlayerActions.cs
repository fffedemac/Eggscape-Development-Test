namespace Project.Entities.Player.Actions
{
    public sealed class PlayerActions
    {
        private static PlayerInputActions _inputs;
        private static ActionMovement _inputMovement;
        private static ActionAttack _inputAttack;
        private static ActionBlock _inputBlock;

        public PlayerActions(PlayerController controller)
        {
            _inputs = new PlayerInputActions();
            _inputs.Enable();

            _inputMovement = new ActionMovement(_inputs.Player, controller);
            _inputAttack = new ActionAttack(_inputs.Player, controller);
            _inputBlock = new ActionBlock(_inputs.Player, controller);
        }

        public void OnUpdate()
        {
            _inputMovement.OnUpdate();
        }
    }
}
