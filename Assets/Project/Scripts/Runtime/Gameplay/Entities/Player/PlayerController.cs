using UnityEngine;
using System.Collections;
using Project.Behaviours.HealthComponent;
using FishNet.Object;

namespace Project.Entities.Player
{
    public sealed partial class PlayerController : NetworkBehaviour, IHealthObservable
    {
        public PlayerModel Model {  get; private set; }
        public PlayerView View { get; private set; }
        private HealthComponent _healthComponent;
        private Coroutine DeathCoroutine;
        public bool IsPaused { get; set; } = true;

        private void Awake()
        {
            Model = GetComponent<PlayerModel>();
            View = GetComponent<PlayerView>();

            _healthComponent = GetComponent<HealthComponent>();
            _healthComponent.RegisterObservable(this);
        }

        private void FixedUpdate()
        {
            if (!IsPaused)
                _inputs?.OnUpdate();
        }

        public void PausePlayer(bool value)
        {
            if (value == true)
            {
                IsPaused = true;
                _inputs?.OnDisable();
            }
            else
            {
                IsPaused = false;
                _inputs?.OnEnable();
            }
        }

        #region Player Death Behaviour
        public void OnHealthNotify() => RPC_StartDying();

        [ServerRpc(RequireOwnership = false)]
        private void RPC_StartDying() => StartDying();

        [ObserversRpc]
        private void StartDying()
        {
            if (DeathCoroutine == null)
                DeathCoroutine = StartCoroutine(Death());
            else
            {
                StopCoroutine(DeathCoroutine);
                DeathCoroutine = StartCoroutine(Death());
            }
        }

        private IEnumerator Death()
        {
            View.RPC_PlayAnimation("Death");
            PausePlayer(true);
            yield return new WaitForSeconds(3);

            View.RPC_PlayAnimation("Idle");
            _healthComponent.RPC_ResetValues();
            PausePlayer(false);
        }

        #endregion
    }
}
