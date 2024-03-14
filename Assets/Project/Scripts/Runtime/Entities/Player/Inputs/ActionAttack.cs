namespace Project.Entities.Player.Actions
{
    public sealed class ActionAttack
    {
        private PlayerController _controller;

        public ActionAttack(PlayerInputActions.PlayerActions playerActions, PlayerController controller)
        {
            _controller = controller;
        }
    }
}
