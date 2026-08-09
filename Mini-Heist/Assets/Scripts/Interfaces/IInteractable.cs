
using UnityEngine;

namespace Delivery.Interfaces {
    public interface IInteractable {

        TagComponent tagComponent { get; set; }

        void Interact(Transform newParent);

    }
}
