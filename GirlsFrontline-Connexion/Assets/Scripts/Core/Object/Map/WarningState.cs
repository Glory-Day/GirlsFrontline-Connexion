using System.Collections;
using GloryDay.Debug;
using GloryDay.Services;
using UnityEngine;

namespace Core.Object.Map
{
    public class WarningState : TileState
    {
        public WarningState(SpriteRenderer renderer) : base(renderer) { }

        public override void StartDisplaying()
        {
            Console.LogProgress();

            if (IsDisplaying == false)
            {
                Coroutine = Blink();
                StaticCoroutine.Start(Coroutine);
            }

            Count++;
        }

        public override void StopDisplaying()
        {
            Console.LogProgress();

            Count--;
            if (IsDisplaying)
            {
                return;
            }

            Renderer.color = new Color(1f, 1f, 1f, 0f);

            StaticCoroutine.Stop(Coroutine);
            Coroutine = null;
        }

        private IEnumerator Blink()
        {
            while (true)
            {
                for (var i = 0f; i <= 2f; i += Time.fixedDeltaTime)
                {
                    var alpha = i <= 1f ? i : 1f - (i - 1f);
                    Renderer.color = new Color(1f, 1f, 1f, alpha);

                    yield return null;
                }
            }
        }
    }
}
