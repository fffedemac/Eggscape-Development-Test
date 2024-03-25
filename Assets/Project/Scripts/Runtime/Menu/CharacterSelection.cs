using UnityEngine;
using UnityEngine.UI;
using FishNet.Object;

namespace Project.Menu
{
    public class CharacterSelection : NetworkBehaviour
    {
        public static CharacterSelection Instance;

        [field: SerializeField] public GameObject[] PlayerPrefabs { get; private set; }
        [field: SerializeField] public GameObject SelectionPanel { get; private set; }
        [field: SerializeField] public GameObject SelectionText { get; private set; }
        [field: SerializeField] public Button SelectPlayer1Button { get; private set; }
        [field: SerializeField] public Button SelectPlayer2Button { get; private set; }

        private void Awake() => Instance = this;
    }
}
