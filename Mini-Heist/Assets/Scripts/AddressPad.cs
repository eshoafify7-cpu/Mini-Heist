using UnityEngine;

namespace Delivery {
    public class AddressPad : MonoBehaviour {
        
        private PackagePad packagePad;

        private void Awake() {
            packagePad = FindObjectOfType<PackagePad>();
        }

        private void OnCollisionEnter(Collision other) {
            if (TryGetComponent(out TagComponent boxTag)) {
                
                if (other.gameObject.TryGetComponent(out TagComponent addressTag)) {
                    
                    if (boxTag.ObjectsTag == addressTag.ObjectsTag) {
                        float deliveryDelay = 1f;
                        
                        Destroy(other.gameObject, deliveryDelay);

                        packagePad.DecreasePackageCount();
                    } 
                }

            }
        }

    }
}
