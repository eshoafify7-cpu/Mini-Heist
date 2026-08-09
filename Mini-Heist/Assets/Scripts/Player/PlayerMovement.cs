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
            
        }

    }
}
