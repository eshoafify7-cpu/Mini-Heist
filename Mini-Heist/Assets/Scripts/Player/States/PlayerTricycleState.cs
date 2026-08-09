using Delivery.Managers;
using UnityEngine;

namespace Delivery.Player.States {
    public class PlayerTricycleState : PlayerBaseState {

        public override void Enter(PlayerData player) {
            if (player.VirtualCamera != null && player.VirtualCamera.parent != null) {
                
                player.VirtualCamera.parent = null;            
            }

            InputManager.Instance.DisablePlayerInputActions();
            InputManager.Instance.EnableTricycleInputActions();

            player.PlayerVisual.SetActive(false);
            player.HandPos.parent = player.transform;
        }

    }
}
