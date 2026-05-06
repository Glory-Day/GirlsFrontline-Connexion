using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class DamageSpriteTextPool : MonoBehaviour
    {
        [SerializeField] private DamageSpriteText prefab;

        [Space(4f)]
        [SerializeField] private int amount;

        private readonly Stack<DamageSpriteText> _pool = new Stack<DamageSpriteText>();

        private void Awake()
        {
            Prewarm();
        }

        private void Prewarm()
        {
            for (var i = 0; i < amount; i++)
            {
                var clone = Create();

                Release(clone);
            }
        }

        private DamageSpriteText Create()
        {
            var clone = Instantiate(prefab, transform);
            clone.gameObject.SetActive(false);
            clone.Pool = this;

            return clone;
        }

        public DamageSpriteText Get(Transform parent)
        {
            var clone = _pool.Count > 0 ? _pool.Pop() : Create();
            clone.transform.SetParent(parent, false);
            clone.transform.SetAsLastSibling();
            clone.gameObject.SetActive(true);

            return clone;
        }

        public void Release(DamageSpriteText clone)
        {
            clone.gameObject.SetActive(false);
            clone.transform.SetParent(transform, false);

            _pool.Push(clone);
        }
    }
}
