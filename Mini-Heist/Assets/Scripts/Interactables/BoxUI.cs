using Delivery.Player;
using TMPro;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

namespace Delivery.Interactable {
    [RequireComponent(typeof(TagComponent))]
    public class BoxUI : MonoBehaviour {
        
        [SerializeField] private TMP_Text addressText;

        private PlayerInteract player;

        private TagComponent tagComponent;

        private bool showText;

        private void Awake() {
            player = FindObjectOfType<PlayerInteract>();

            tagComponent = GetComponent<TagComponent>();
        }

        private void Update() {
            if (player != null) {
                showText = player.LookedAtTransform == transform;

                addressText.text = tagComponent.ObjectsTag.ToString();
                addressText.gameObject.SetActive(showText);
            }
        }

    }
}
