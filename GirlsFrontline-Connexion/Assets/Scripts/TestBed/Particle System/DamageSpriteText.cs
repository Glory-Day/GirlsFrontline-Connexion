using System.Collections;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class DamageSpriteText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textMesh;
        [SerializeField] private CanvasGroup canvasGroup;

        [Space(4f)]
        [SerializeField] private float duration = 0.6f;
        [SerializeField] private Vector2 offset = new Vector2(0f, 60f);
        [SerializeField] private AnimationCurve curve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

        private RectTransform _root;

        private Coroutine _coroutine;

        private void Awake()
        {
            _root = (RectTransform)transform;

            if (canvasGroup == null)
            {
                canvasGroup = GetComponent<CanvasGroup>();
            }
        }

        public void Play(int value, Vector2 position, bool hasIcon = true)
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }

            _root.anchoredPosition = position;
            _root.localScale = Vector3.one;

            canvasGroup.alpha = 1f;
            textMesh.text = DamageSpriteTextBuilder.Build(value, hasIcon);

            _coroutine = StartCoroutine(Playing());
        }

        private IEnumerator Playing()
        {
            var start = _root.anchoredPosition;
            var end = start + offset;

            var time = 0f;
            while (time < duration)
            {
                time += Time.unscaledDeltaTime;

                var a = Mathf.Clamp01(time / duration);
                var b = curve.Evaluate(a);

                _root.anchoredPosition = Vector2.LerpUnclamped(start, end, b);
                canvasGroup.alpha = 1f - a;

                yield return null;
            }

            Pool.Release(this);
        }

        public DamageSpriteTextPool Pool { private get; set; }
    }
}
