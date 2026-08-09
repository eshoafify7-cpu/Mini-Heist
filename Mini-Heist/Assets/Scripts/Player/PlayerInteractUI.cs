using UnityEngine;
using UnityEngine.UI;

namespace Delivery.Player {
    [RequireComponent(typeof(PlayerInteract))]
    public class PlayerInteractUI : MonoBehaviour {
        
        private PlayerInteract player;

        [SerializeField] private Image cursorImage;
        [SerializeField] private Sprite normalCursor;
        [SerializeField] private Sprite canInteractCursor;

        private void Awake() {
            player = GetComponent<PlayerInteract>();
        }

        private void Update() {
            cursorImage.sprite = !player.CanInteract ? normalCursor : canInteractCursor;
        }

    }
}
