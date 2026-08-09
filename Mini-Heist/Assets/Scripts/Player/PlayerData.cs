using UnityEngine;

namespace Delivery.Player {
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerData : MonoBehaviour {
        
        [field: SerializeField] public float moveSpeed { get; private set; }
        
        [field: SerializeField] public float accelerationTime { get; private set; }
        
        [field: SerializeField] public float decelrationTime { get; private set; }

        [HideInInspector] public Vector2 moveInput;
        [HideInInspector] public Rigidbody rb;

        [HideInInspector] public Vector2 currentInput;
        [HideInInspector] public Vector2 smoothedVelocity;
        [HideInInspector] public Vector3 moveDir;

        private void Awake() {
            rb = GetComponent<Rigidbody>();            
        }

    }
}
