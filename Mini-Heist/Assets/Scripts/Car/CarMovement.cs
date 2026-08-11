using Delivery.Player.States;
using UnityEngine;

namespace Delivery.Car {
    [RequireComponent(typeof(Rigidbody))]
    public class CarMovement : MonoBehaviour {
        
        [Header("Movement Settings")]
        [SerializeField] private float acceleration;
        [SerializeField] private float brakingForce;
        [SerializeField] private float deceleration;

        [Space]

        [Header("Steering Settings")]
        [SerializeField] private float turnSpeed;
        [SerializeField] private float minSteeringSpeed;
        
        [Space]
        
        [SerializeField] private float maxAccelForce;
        [SerializeField] private float maxDecelForce;
        
        [Space]

        [SerializeField] private GameObject cameraHolder;

        private float currentForce;

        private Rigidbody rb;

        private PlayerStateMachine player;

        private void Awake() {
            rb = GetComponent<Rigidbody>();

            player = FindObjectOfType<PlayerStateMachine>();
        }
        
        private void ResetDrift() {
            rb.velocity = transform.forward * rb.velocity.magnitude;
        }

        private void FixedUpdate() {
            if (player.CurrentState != player.playerCarState) {
                cameraHolder.SetActive(false);
                return;
            }
            else {
                cameraHolder.SetActive(true);    
            }

            // Throttle and Braking
            if (Input.GetKey(KeyCode.W)) {
                currentForce += acceleration * Time.fixedDeltaTime;
            }
            else if (Input.GetKey(KeyCode.S)) {
                currentForce -= brakingForce * Time.fixedDeltaTime;
            }
            else {
                currentForce = Mathf.MoveTowards(
                    currentForce,
                    0f,
                    deceleration * Time.fixedDeltaTime
                );
            }

            currentForce = Mathf.Clamp(
                currentForce,
                maxDecelForce,
                maxAccelForce
            );

            rb.AddForce(transform.forward * currentForce);

            // Steering

            float steeringInput = Input.GetAxisRaw("Horizontal");
            if (Mathf.Abs(currentForce) > minSteeringSpeed) {    
                transform.eulerAngles += new Vector3(
                    0f,
                    steeringInput * turnSpeed * Time.fixedDeltaTime,
                    0f
                );
            }

            ResetDrift();
        }


    }
}
