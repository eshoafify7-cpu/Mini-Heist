using Delivery.Interfaces;
using Delivery.Player.States;
using UnityEngine;

namespace Delivery {
    [RequireComponent(typeof(TagComponent))]
    public class Tricycle : MonoBehaviour, IInteractable {
        
        public TagComponent tagComponent { get; set; }

        private void Awake() {
            tagComponent = GetComponent<TagComponent>();
        }

        public void Interact(Transform newParent) {
            if (PlayerStateMachine.Instance != null) {
                PlayerStateMachine.Instance.ChangeState(PlayerStateMachine.Instance.playerTricycleState);
            }
        }
    }
}
