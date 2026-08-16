using System;
using Delivery.Managers;
using Delivery.Player.States;
using UnityEngine;

namespace Delivery.Car {
    [RequireComponent(typeof(Rigidbody))]
    public class CarMovement : MonoBehaviour {
        
        [Header("Speed")]
        [SerializeField] private float acceleration;
        [SerializeField] private float deceleration;
        [SerializeField] private float maxForwardSpeed;
        [SerializeField] private float maxReverseSpeed;

        [Header("Steering")]
        [SerializeField] private float steeringSpeed;

        [Space]
        [SerializeField] private GameObject virtualCamera;
        [SerializeField] private Transform playerExitPos;
        [SerializeField] private float playerOffset;

        private Rigidbody rb;

        private float currentSpeed;
        private float targetSpeed;

        private PlayerStateMachine player;

        private void Awake() {
            rb = GetComponent<Rigidbody>();
            player = FindObjectOfType<PlayerStateMachine>();
        }

        private void Start() {
            player.OnPlayerChangeState += Player_OnPlayerChangeState;

            InputManager.Instance.OnPlayerLeaveCar += Car_OnPlayerLeave;
        }

        private void Car_OnPlayerLeave(object sender, EventArgs e) {
            if (player.CurrentState != player.playerCarState)
                return;

            player.ChangeState(player.playerIdleState);
        }

        private void Player_OnPlayerChangeState(PlayerBaseState playerState) {
            virtualCamera.SetActive(playerState == player.playerCarState);
        }

        private void FixedUpdate() {
            if (player.CurrentState != player.playerCarState)
                return;

            player.transform.position = playerExitPos.position;

            float throttle = InputManager.Instance.GetThrottleReverse().y;
            float steering = InputManager.Instance.GetSteeringNormalized().x;

            if (throttle > 0f) {
                targetSpeed = throttle * maxForwardSpeed;
            } 
            else {
                targetSpeed = throttle * maxReverseSpeed;    
            }

            float targetTime;
            if (throttle == 0f) {
                targetTime = deceleration;
            }
            else {
                targetTime = acceleration;
            }

            currentSpeed = Mathf.MoveTowards(
                currentSpeed,
                targetSpeed,
                targetTime * Time.fixedDeltaTime
            );

            rb.MovePosition(
                rb.position + Time.fixedDeltaTime * transform.forward * currentSpeed 
            );

            float speedFactor = Mathf.Clamp01(
                Mathf.Abs(currentSpeed) / maxForwardSpeed
            );

            float steerAmuont = 
                steering * steeringSpeed * speedFactor;

            Quaternion rotation = Quaternion.Euler(
                0f,
                steerAmuont * Time.fixedDeltaTime,
                0f
            );

            rb.MoveRotation(rb.rotation * rotation);
        }


    }
}
