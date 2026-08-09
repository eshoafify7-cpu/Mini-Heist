using Delivery.Managers;
using UnityEngine;

namespace Delivery.Player {
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour {
        
        [Header("Movement Settings")] 
        [SerializeField] private float moveSpeed;
        [SerializeField] private float accelerationTime;
        [SerializeField] private float decelerationTime;
        private Vector2 moveInput;
        private Vector2 currentInput;
        private Vector2 smoothedVelocity;
        private Rigidbody rb;

        private void Awake() {
            rb = GetComponent<Rigidbody>();
        }

        private void Update() {
            moveInput = InputManager.Instance.GetMoveInputNormalized();
        }

        private void FixedUpdate() {
            HandleMovement();
        }

        private void HandleMovement() {
            float targetTime = moveInput != Vector2.zero ? accelerationTime : decelerationTime;

            currentInput = Vector2.SmoothDamp(currentInput, moveInput, ref smoothedVelocity, targetTime);
            
            Vector3 moveDir = 
                transform.right * currentInput.x + transform.forward * currentInput.y;

            rb.velocity = new Vector3(
                moveDir.x * moveSpeed,
                rb.velocity.y,
                moveDir.z * moveSpeed
            );
        }

    }
}
