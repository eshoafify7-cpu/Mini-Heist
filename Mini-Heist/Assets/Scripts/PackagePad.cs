using UnityEngine;

namespace Delivery {
    public class PackagePad : MonoBehaviour {
        
        [SerializeField] private Transform[] packageTransform;
        [SerializeField] private Transform spawnPoint;
        
        [Space]
        
        [SerializeField] private int maxPackageCount;
        [SerializeField] private float spawnTime;
        private float spawnTimeCounter;

        public int packageCount;

        private bool canSpawn;

        private void Update() {
            canSpawn = packageCount < maxPackageCount;

            if (canSpawn && spawnTimeCounter <= 0f) {
                
                int boxIndex = Random.Range(0, packageTransform.Length);

                Instantiate(packageTransform[boxIndex], spawnPoint.position, Quaternion.identity);

                spawnTimeCounter = spawnTime;

                IncreasePackageCount();

            }
            else {
                spawnTimeCounter -= Time.deltaTime;
            } 
        }

        private void IncreasePackageCount() {
            packageCount++;
        }

        public void DecreasePackageCount() {
            packageCount--;
        }

    }
}
