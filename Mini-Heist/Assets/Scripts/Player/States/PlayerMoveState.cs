using Delivery.Managers;
using UnityEngine;

namespace Delivery.Player.States {
    public class PlayerMoveState : PlayerBaseState {

        public override void Update(PlayerData player) {
            if (player.currentInput.magnitude == 0.001f) {
                playerSM.ChangeState(playerSM.playerIdleState);
            }
        }

        public override void FixedUpdate(PlayerData player) {
            player.rb.velocity = new Vector3(
                player.moveDir.x * player.moveSpeed,
                player.rb.velocity.y,
                player.moveDir.z * player.moveSpeed
            );
        }

    }
}
