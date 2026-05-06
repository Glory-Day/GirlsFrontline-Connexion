using UnityEngine;

namespace DefaultNamespace
{
    public class DamageSpriteTextSpawner : MonoBehaviour
    {
        [SerializeField] private DamageSpriteTextPool pool;
        [SerializeField] private bool hasIcon;

        [Space(4f)]
        [SerializeField] private RectTransform canvasRectTransform;

        [Space(4f)]
        [SerializeField] private Camera worldCamera;
        [SerializeField] private Camera uiCamera;

        public void Spawn(int value, Vector3 position)
        {
            var anchored = UIPositionUtility.ToAnchoredPosition(canvasRectTransform, worldCamera, position, uiCamera);
            var clone = pool.Get(canvasRectTransform);
            clone.Play(value, anchored, hasIcon);
        }
    }
}
