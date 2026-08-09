using UnityEngine;

namespace Delivery.Player.States {
    public class PlayerIdleState : PlayerBaseState {

        public override void Enter(PlayerData player) {
            if (player.CameraHolder != null && player.CameraHolder.parent == null) {
                
                player.CameraHolder.parent = player.transform;
            }

            if (!player.PlayerVisual.activeInHierarchy)
                player.PlayerVisual.SetActive(true);

            if (!player.HandPos.parent == player.CameraHolder) 
                player.HandPos.parent = player.CameraHolder;
        }

        public override void Update(PlayerData player) {
            player.rb.velocity = Vector3.zero;

            if (player.currentInput.magnitude >= 0.001f) {
                playerSM.ChangeState(playerSM.playerMoveState);
            }
        }

    }
}
