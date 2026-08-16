using Delivery.Managers;
using UnityEngine;

namespace Delivery.Player.States {
    public class PlayerCarState : PlayerBaseState {

        public override void Enter(PlayerData player) {
            InputManager.Instance.DisablePlayerInputActions();
            InputManager.Instance.EnableTricycleInputActions();

            foreach (GameObject child in player.playerChildren) {
                child.SetActive(false);
            }
        }

        public override void Exit(PlayerData player) {
            InputManager.Instance.EnablePlayerInputActions();
            InputManager.Instance.DisableTricycleInputActions();

            foreach (GameObject child in player.playerChildren) {
                child.SetActive(true);
            }
        }

    }
}
