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

        private const float SMOOTH_TIME = 10f;

        public float deliveryDelayTimer;
        public float deliveryDelayTimerMax = 1f;

        public bool isDelivering;

        private PackagePad packagePad;

        private const string ADDRESS_PADS_LAYER = "Address Pad";

        private void Awake() {
            rb = GetComponent<Rigidbody>();
            packagePad = FindObjectOfType<PackagePad>();

            tagComponent = GetComponent<TagComponent>();

            deliveryDelayTimer = deliveryDelayTimerMax;
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

            if (isDelivering) {
                deliveryDelayTimer -= Time.deltaTime;

                if (deliveryDelayTimer <= 0f) {
                    deliveryDelayTimer = 0f;

                    if (transform.parent == null) {

                        Destroy(gameObject);
                        packagePad.DecreasePackageCount();
                    }
                }
            }
        }

        private void OnCollisionEnter(Collision other) {
            if (!GetComponent<TagComponent>())
                return;

            if (!other.gameObject.TryGetComponent(out TagComponent addressTag))
                return;

            if (other.gameObject.layer != LayerMask.NameToLayer(ADDRESS_PADS_LAYER))
                return;
                
            if (tagComponent.ObjectsTag != addressTag.ObjectsTag)
                return;

            isDelivering = true;
            deliveryDelayTimer = deliveryDelayTimerMax;
        }

        private void OnCollisionExit(Collision other) {
            if (!GetComponent<TagComponent>())
                return;

            if (!other.gameObject.TryGetComponent(out TagComponent addressTag))
                return;

            if (tagComponent.ObjectsTag != addressTag.ObjectsTag)
                return;

            isDelivering = false;
            
        }
    }
}
