using Delivery.Interfaces;
using Delivery.Managers;
using UnityEngine;

namespace Delivery.Player {
    public class PlayerInteract : MonoBehaviour {
        
        [SerializeField] private float interactRange;
        [SerializeField] private LayerMask interactableLayer;
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private Transform handPos;

        private IInteractable heldObject;
        public IInteractable HeldObject => heldObject;

        private bool canInteract;

        public bool CanInteract => canInteract;

        private Transform lookedAtTransform;

        public Transform LookedAtTransform => lookedAtTransform;

        private void Update() {
                
            canInteract = Physics.Raycast(cameraTransform.position, cameraTransform.forward, out RaycastHit hit, interactRange, interactableLayer);

            if (lookedAtTransform == null) {
                lookedAtTransform = hit.transform;
            }
            
            if (hit.transform == null) {
                lookedAtTransform = null;
            }

            if (InputManager.Instance.WasInteractPressed()) {
                
                heldObject?.Interact(null);
                heldObject = null;
                
                if (canInteract) {
                    
                    IInteractable interactable = hit.collider.gameObject.GetComponent<IInteractable>();

                    if (interactable != null && !interactable.tagComponent.CompareTag(TagComponent.Tag.Tricycle)) {
                        
                        heldObject = interactable;
                        interactable.Interact(handPos);

                    } else {
                        
                            interactable.Interact(null);   
                    }
                }
                
            }

        }

    }
}