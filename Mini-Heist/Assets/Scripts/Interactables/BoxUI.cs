using Delivery.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Delivery.Interactable {
[RequireComponent(typeof(TagComponent))]
    [RequireComponent(typeof(Box))]
    public class BoxUI : MonoBehaviour {
        
        [SerializeField] private TMP_Text addressText;

        [Space]

        [SerializeField] private Image deliveryDelayImage;
        [SerializeField] private GameObject deliveryDelayBar;

        private PlayerInteract player;
        private TagComponent tagComponent;
        private Box box;

        private bool showText;

        private void Awake() {
            player = FindObjectOfType<PlayerInteract>();

            tagComponent = GetComponent<TagComponent>();
            box = GetComponent<Box>();
        }

        private void Update() {
            if (player != null) {
                showText = player.LookedAtTransform == transform;

                addressText.text = tagComponent.ObjectsTag.ToString();
                addressText.gameObject.SetActive(showText);
            }

            deliveryDelayBar.SetActive(box.isDelivering);

            deliveryDelayImage.fillAmount = box.deliveryDelayTimer / box.deliveryDelayTimerMax;
        }

    }
}
