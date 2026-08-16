using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Delivery.Managers {
    public class InputManager : MonoBehaviour {

        public static InputManager Instance { get; private set; }

        private PlayerInputActions playerInputActions;

        public event EventHandler OnPlayerLeaveCar;

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
            playerInputActions.Car.Enable();
        }

        public void DisableTricycleInputActions() {
            playerInputActions.Car.Disable();
        }

        private void Start() {
            playerInputActions.Car.Leave.performed += Car_OnPlayerLeave;
        } 

        private void Car_OnPlayerLeave(InputAction.CallbackContext e) {
            OnPlayerLeaveCar?.Invoke(this, EventArgs.Empty);
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

        public Vector2 GetThrottleReverse() {
            Vector2 throttle;

            throttle = playerInputActions.Car.ThrottleReverse.ReadValue<Vector2>();

            throttle = throttle.normalized;

            return throttle;
        }

        public Vector2 GetSteeringNormalized() {
            Vector2 steering;

            steering = playerInputActions.Car.Steering.ReadValue<Vector2>();

            steering = steering.normalized;

            return steering;
        }

    }
}

