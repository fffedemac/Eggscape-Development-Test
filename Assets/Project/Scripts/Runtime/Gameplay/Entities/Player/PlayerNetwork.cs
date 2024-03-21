using UnityEngine;
using Project.Menu;
using FishNet.Object;
using FishNet.Object.Synchronizing;

namespace Project.Entities.Player
{
    public class PlayerNetwork : NetworkBehaviour
    {
        
        [field: SyncVar] public bool IsReady { get; set; }

        public override void OnStartClient()
        {
            base.OnStartClient();
            if (!IsOwner)
            {
                enabled = false;
                return;
            }

            
        }
    }
}
