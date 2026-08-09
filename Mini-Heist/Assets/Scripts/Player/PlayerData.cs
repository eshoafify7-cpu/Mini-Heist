using UnityEngine;

namespace Delivery.Player {
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerData : MonoBehaviour {
        
        [field: SerializeField] public float MoveSpeed { get; private set; }
        
        [field: SerializeField] public float AccelerationTime { get; private set; }
        
        [field: SerializeField] public float DecelrationTime { get; private set; }
        
        [field:Space]

        [field: SerializeField] public Transform VirtualCamera { get; private set; }
        [field: SerializeField] public GameObject PlayerVisual { get; private set; }

        [field: SerializeField] public Transform HandPos { get; private set; }
        [field: SerializeField] public Transform CameraHolder { get; private set; }

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
