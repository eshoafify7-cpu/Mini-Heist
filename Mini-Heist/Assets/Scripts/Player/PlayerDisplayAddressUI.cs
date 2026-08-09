using TMPro;
using UnityEngine;

namespace Delivery.Player {
    [RequireComponent(typeof(PlayerInteract))]
    public class PlayerDisplayAddressUI : MonoBehaviour {
        
        [SerializeField] private TMP_Text addressText;

        private PlayerInteract player;

        private void Awake() {
            player = GetComponent<PlayerInteract>();
        }

        private void Update() {
            addressText.gameObject.SetActive(player.HeldObject != null);

            if (player.HeldObject != null)
                addressText.text = player.HeldObject.tagComponent.ObjectsTag.ToString();
        }

    }
}
