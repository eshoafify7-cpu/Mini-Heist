using UnityEngine;

namespace Delivery.Managers {
    public class InputManager : MonoBehaviour {

        public static InputManager Instance { get; private set; }

        private PlayerInputActions playerInputActions;

        private void Awake() {
            Instance = this;

            playerInputActions = new PlayerInputActions();
            EnablePlayerInputActions();
        }

        private void OnDisable() {
            DisablePlayerInputActions();
        }

        public void EnablePlayerInputActions() {
            playerInputActions.Player.Enable();
        }

        public void DisablePlayerInputActions() {
            playerInputActions.Player.Disable();
        }

        public void EnableTricycleInputActions() {
            playerInputActions.Tricycle.Enable();
        }

        public void DisableTricycleInputActions() {
            playerInputActions.Tricycle.Disable();
        }

        public Vector2 GetMoveInputNormalized() {
            Vector2 moveInput;

            moveInput = playerInputActions.Player.Movement.ReadValue<Vector2>();

            moveInput = moveInput.normalized;

            return moveInput;
        }

        public Vector2 GetMouseDelta() {
            Vector2 mouseDelta;

            mouseDelta = playerInputActions.Player.Look.ReadValue<Vector2>();

            return mouseDelta;
        }

        public bool WasInteractPressed() {
            return playerInputActions.Player.Interact.WasPressedThisFrame();
        }

    }
}

