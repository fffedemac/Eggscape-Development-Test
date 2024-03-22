using FishNet.Object;
using Project.Behaviours.HealthComponent;

namespace Project.Entities.Player
{
    public sealed partial class PlayerController : NetworkBehaviour, IHealthObservable
    {
        public PlayerModel Model {  get; private set; }
        public PlayerView View { get; private set; }
        private HealthComponent _healthComponent;

        private void Awake()
        {
            Model = GetComponent<PlayerModel>();
            View = GetComponent<PlayerView>();

            _healthComponent = GetComponent<HealthComponent>();
            _healthComponent.RegisterObservable(this);
        }

        private void FixedUpdate()
        {
            if (Model.IsPaused) return;
            _inputs?.OnUpdate();
        }

        public void OnHealthNotify()
        {
            
        }
    }
}
