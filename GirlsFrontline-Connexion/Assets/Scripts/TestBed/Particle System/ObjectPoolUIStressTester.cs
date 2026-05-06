using UnityEngine;

namespace DefaultNamespace
{
    public class ObjectPoolUIStressTester : MonoBehaviour
    {
        [SerializeField] private DamageSpriteTextSpawner spawner;

        [Space(4f)]
        [SerializeField] private Vector3 jitter = new Vector3(1.5f, 1.5f, 0f);

        private void Update()
        {
            if (spawner == null)
            {
                return;
            }

            var x = Random.Range(-jitter.x, jitter.x);
            var y = Random.Range(-jitter.y, jitter.y);
            var z = Random.Range(-jitter.z, jitter.z);
            var offset = new Vector3(x, y, z);

            var value = Random.Range(1, 100000);
            var position = transform.position + offset;

            spawner.Spawn(value, position);
        }
    }
}
