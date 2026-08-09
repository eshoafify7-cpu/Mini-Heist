using Delivery.Interfaces;
using UnityEngine;

namespace Delivery {
    public class Tricycle : MonoBehaviour, IInteractable {
        
        public TagComponent tagComponent { get; set; }

        [SerializeField] private GameObject playerObject;

        public void Interact(Transform newParent) {
            if (playerObject != null) {
                playerObject.SetActive(false);
            }
        }
    }
}
