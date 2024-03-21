using UnityEngine;
using FishNet.Object;
using TMPro;
using Project.Entities.Player;

namespace Project.Menu
{
    public sealed class LobbyPlayerData : NetworkBehaviour
    {
        public PlayerModel PlayerOwner { get; set; }
        [field: SerializeField] public TMP_Text PositionText { get; set; }
        [SerializeField] private TMP_InputField _usernameInputField;

        private void Awake()
        {
            _usernameInputField.onEndEdit.AddListener(delegate { RPC_ConfirmNewUsername(_usernameInputField.text); });
        }

        [ServerRpc(RequireOwnership = false)]
        private void RPC_ConfirmNewUsername(string newNickname) => ConfirmNewUsername(newNickname);
        [ObserversRpc]
        private void ConfirmNewUsername(string newNickname) => PlayerOwner.Nickname = newNickname;
    }
}
