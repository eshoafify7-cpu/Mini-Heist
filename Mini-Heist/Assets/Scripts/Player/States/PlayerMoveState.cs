using Delivery.Managers;
using UnityEngine;

namespace Delivery.Player.States {
    public class PlayerMoveState : PlayerBaseState {

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
            if (player.currentInput.magnitude == 0.001f) {
                playerSM.ChangeState(playerSM.playerIdleState);
            }
        }

        public override void FixedUpdate(PlayerData player) {
            player.rb.velocity = new Vector3(
                player.moveDir.x * player.MoveSpeed,
                player.rb.velocity.y,
                player.moveDir.z * player.MoveSpeed
            );
        }

    }
}
