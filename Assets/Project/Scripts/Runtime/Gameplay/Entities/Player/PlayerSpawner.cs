using UnityEngine;
using UnityEngine.UI;
using Project.Menu;
using FishNet.Object;

namespace Project.Entities.Player
{
    // This class is solely used for character selection
    // through the lobby.
    public class PlayerSpawner : NetworkBehaviour
    {
        private Button _spawnPlayer1Button;
        private Button _spawnPlayer2Button;

        public override void OnStartClient()
        {
            if (!IsOwner) return;

            _spawnPlayer1Button = CharacterSelection.Instance.SelectPlayer1Button;
            _spawnPlayer2Button = CharacterSelection.Instance.SelectPlayer2Button;

            _spawnPlayer1Button.onClick.AddListener(() =>
            {
                RPC_SpawnPlayer(0);
                CharacterSelection.Instance.SelectionPanel.SetActive(false);
                CharacterSelection.Instance.SelectionText.SetActive(false);
            });

            _spawnPlayer2Button.onClick.AddListener(() =>
            {
                RPC_SpawnPlayer(1);
                CharacterSelection.Instance.SelectionPanel.SetActive(false);
                CharacterSelection.Instance.SelectionText.SetActive(false);
            });
        }

        // Spawns a playable controller through the server
        // establishes its own connection so it cannot be controlled
        // by other instances or the host itself.
        [ServerRpc(RequireOwnership = false)]
        private void RPC_SpawnPlayer(int prefab)
        {
            GameObject player = Instantiate(CharacterSelection.Instance.PlayerPrefabs[prefab], Vector3.zero, Quaternion.identity);
            Spawn(player, Owner);
        }
    }
}
