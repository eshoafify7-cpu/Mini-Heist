using UnityEngine;

namespace Delivery.Player.States {
    public class PlayerIdleState : PlayerBaseState {

        public override void Enter(PlayerData player) {
            foreach (GameObject child in player.playerChildren) {
                child.SetActive(true);
            }
        }

        public override void Update(PlayerData player) {
            player.rb.velocity = Vector3.zero;

            if (player.currentInput.magnitude >= 0.001f) {
                playerSM.ChangeState(playerSM.playerMoveState);
            }
        }

    }
}
