using UnityEngine;

namespace Delivery { 
    public class TagComponent : MonoBehaviour {

        public enum Tag {
            None,
            Address_A,
            Address_B,
            Address_C,
            Tricycle,
        }

        [SerializeField] private new Tag tag;
        public Tag ObjectsTag => tag;

        public bool CompareTag(Tag otherTag) {
            if (otherTag == ObjectsTag)
                return true;

            return false;
        }

    }
}