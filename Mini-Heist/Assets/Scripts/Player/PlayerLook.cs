using Delivery.Managers;
using UnityEngine;

namespace Delivery.Player {
    public class PlayerLook : MonoBehaviour {
        
        [SerializeField] private float sensitivity;
        
        [Space]

        [SerializeField] private Transform cameraHolder;

        private float xRotation;
        private const float MAX_Y_ROT = 90f;
        private const float MIN_Y_ROT = -90f;

        private void Awake() {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            Application.targetFrameRate = 120;
        }

        private void Update() {
            Vector2 mouseDelta = InputManager.Instance.GetMouseDelta();

            float mouseX = mouseDelta.x * sensitivity;
            float mouseY = mouseDelta.y * sensitivity;

            transform.Rotate(Vector3.up * mouseX);

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, MIN_Y_ROT, MAX_Y_ROT);

            cameraHolder.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }

    }
}