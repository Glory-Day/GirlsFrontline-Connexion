using Core.Object.Character;
using UnityEngine;

namespace DefaultNamespace
{
    public class ParticleSystemUIStressTester : MonoBehaviour
    {
        public int index;

        private readonly DamageNumberRenderer[] _damageNumberRenderers = new DamageNumberRenderer[4];

        private void Awake()
        {
            _damageNumberRenderers[0] = transform.GetChild(0).GetComponent<DamageNumberRenderer>();
            _damageNumberRenderers[1] = transform.GetChild(1).GetComponent<DamageNumberRenderer>();
            _damageNumberRenderers[2] = transform.GetChild(2).GetComponent<DamageNumberRenderer>();
            _damageNumberRenderers[3] = transform.GetChild(3).GetComponent<DamageNumberRenderer>();
        }

        private void Update()
        {
            _damageNumberRenderers[index].Render(Random.Range(1, 100000).ToString());
        }
    }
}
