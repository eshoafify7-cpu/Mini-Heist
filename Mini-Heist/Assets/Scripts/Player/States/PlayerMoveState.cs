using UnityEngine;

namespace Delivery.Player.States {
    public class PlayerMoveState : PlayerBaseState {

        public override void Enter(PlayerData player) {
            foreach (GameObject child in player.playerChildren) {
                child.SetActive(true);
            }
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
