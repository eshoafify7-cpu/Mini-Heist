using System;
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

        private void Awake() {
            rb = GetComponent<Rigidbody>();

            tagComponent = GetComponent<TagComponent>();
        }

        public void Interact(Transform newParent) {
            this.newParent = newParent;
            
            transform.parent = newParent;

            if (newParent != null) {
                transform.position = newParent.position;
                transform.rotation = newParent.rotation;
            }
        }

        private void Update() {
            rb.isKinematic = newParent != null;
        }

        

    }
}
