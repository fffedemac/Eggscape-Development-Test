namespace Project.Entities.Player.Actions
{
    public sealed class ActionBlock
    {
        private PlayerController _controller;

        public ActionBlock(PlayerInputActions.PlayerActions playerActions, PlayerController controller)
        {
            _controller = controller;
        }
    }
}
