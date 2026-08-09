using System.Collections;
using UnityEngine;

namespace Delivery {
    public class AddressPad : MonoBehaviour {
        
        private PackagePad packagePad;

        private void Awake() {
            packagePad = FindObjectOfType<PackagePad>();
        }

        private void OnCollisionEnter(Collision other) {
            if (!TryGetComponent(out TagComponent boxTag))
                return;

            if (!other.gameObject.TryGetComponent(out TagComponent addressTag))
                return;

            if (boxTag.ObjectsTag != addressTag.ObjectsTag)
                return;

            StartCoroutine(DeliverBox(other.gameObject));
        }

        private IEnumerator DeliverBox(GameObject box) {

            yield return new WaitForSeconds(1f);

            if (box != null && box.transform.parent == null) {
                Destroy(box);
                packagePad.DecreasePackageCount();
            }
        }

    }
}
