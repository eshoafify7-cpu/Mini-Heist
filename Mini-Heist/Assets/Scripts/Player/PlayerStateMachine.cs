using Delivery.Managers;
using UnityEngine;

namespace Delivery.Player.States {
    [RequireComponent(typeof(PlayerData))]
    public class PlayerStateMachine : MonoBehaviour {

        public static PlayerStateMachine Instance { get; private set; }

        private PlayerData player;

        private PlayerBaseState currentState;

        public PlayerBaseState playerIdleState;
        public PlayerBaseState playerMoveState;
        public PlayerBaseState playerTricycleState;

        private void Awake() {
            Instance = this;

            player = GetComponent<PlayerData>();

            playerIdleState = new PlayerIdleState();
            playerMoveState = new PlayerMoveState();
            playerTricycleState = new PlayerTricycleState();

            ChangeState(playerIdleState);
        }

        private void Update() {
            currentState.Update(player);

            player.moveInput = 
                InputManager.Instance.GetMoveInputNormalized();

            float targetTime = 
                player.moveInput != Vector2.zero ? player.AccelerationTime : player.DecelrationTime;

            player.currentInput = 
                Vector2.SmoothDamp(player.currentInput, player.moveInput, ref player.smoothedVelocity, targetTime);

            player.moveDir =
                player.transform.right * player.currentInput.x + player.transform.forward * player.currentInput.y;

        }

        private void FixedUpdate() {
            currentState.FixedUpdate(player);
        }

        public void ChangeState(PlayerBaseState newState) {
            if (currentState == newState)
                return;

            currentState?.Exit(player);
            currentState = newState;
            currentState.Enter(player);
        }

    }
}