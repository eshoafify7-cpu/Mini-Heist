using System;
using System.Net.Sockets;
using Delivery.Interfaces;
using UnityEngine;

namespace Delivery.Interactable {
[RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(TagComponent))]
    public class Box : MonoBehaviour, IInteractable {
        
        private Transform newParent;

        private Rigidbody rb;

        public TagComponent tagComponent { get; set; }

        public event EventHandler OnDeliverySuccess;
        public event EventHandler OnDeliveryFailed;

        private const float SMOOTH_TIME = 10f;

        private void Awake() {
            rb = GetComponent<Rigidbody>();

            tagComponent = GetComponent<TagComponent>();
        }

        public void Interact(Transform newParent) {
            this.newParent = newParent;
            transform.parent = newParent;
        }

        private void Update() {
            rb.isKinematic = newParent != null;

            if (newParent != null) {
                transform.position = Vector3.Lerp(transform.position, newParent.position, SMOOTH_TIME * Time.deltaTime);

                transform.rotation = Quaternion.Slerp(transform.rotation, newParent.rotation, SMOOTH_TIME * Time.deltaTime);
            }
        }

    }
}
