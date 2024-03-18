using UnityEngine;
using UnityEngine.UI;
using FishNet;

namespace Project.Menu
{
    public sealed class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button _hostButton;
        [SerializeField] private Button _connectButton;

        private void Awake()
        {
            _hostButton.onClick.AddListener(() =>
            {
                InstanceFinder.ServerManager.StartConnection();
                InstanceFinder.ClientManager.StartConnection();
            });

            _connectButton.onClick.AddListener(() => InstanceFinder.ClientManager.StartConnection());
        }
    }
}
