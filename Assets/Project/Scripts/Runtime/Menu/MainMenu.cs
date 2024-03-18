using UnityEngine;
using UnityEngine.UI;
using FishNet;
using TMPro;
using System.Text;
using FishNet.Connection;

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
                //InstanceFinder.ClientManager.StartConnection();
            });

            _connectButton.onClick.AddListener(() => InstanceFinder.ClientManager.StartConnection());
        }

        private void CheckServerStatus(NetworkConnection connection, bool arg2)
        {
            _sbServerStatus.Clear();
            if (arg2)
            {
                _sbServerStatus.Append("Server is Online");
                _serverStatusText.text = _sbServerStatus.ToString();
                _serverStatusText.color = Color.green;
                _hostButton.gameObject.SetActive(false);
            }
            else
            {
                _sbServerStatus.Append("Server is Offline");
                _serverStatusText.text = _sbServerStatus.ToString();
                _serverStatusText.color = Color.red;
                _hostButton.gameObject.SetActive(true);
            }
        }

        private void CheckServerStatus(bool value)
        {
            
        }

        private void Update()
        {
            //CheckServerStatus();
        }
    }
}
