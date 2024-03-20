using UnityEngine;
using UnityEngine.SceneManagement;
using FishNet.Managing;

namespace Project.SteamworksIntegrations
{
    public sealed class SteamworksManager : MonoBehaviour
    {
        private const string _menuName = "Menu";
        [SerializeField] private NetworkManager _networkManager;
        [SerializeField] FishySteamworks.FishySteamworks _fishySteamworks;

        public void LoadMenu() => SceneManager.LoadScene(_menuName, LoadSceneMode.Additive);
    }
}