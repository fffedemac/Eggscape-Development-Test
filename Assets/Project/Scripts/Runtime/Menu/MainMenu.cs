using UnityEngine;
using UnityEngine.UI;
using FishNet;
using TMPro;
using System.Text;

namespace Project.Menu
{
    public sealed class MainMenu : MonoBehaviour
    {
        private StringBuilder _sbServerStatus = new StringBuilder();
        [SerializeField] private TMP_Text _serverStatusText;
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
