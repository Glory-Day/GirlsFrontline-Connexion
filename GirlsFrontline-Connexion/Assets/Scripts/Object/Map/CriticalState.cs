using System.Collections;
using GloryDay.Log;
using GloryDay.Threading;
using UnityEngine;

namespace Object.Map
{
    public class CriticalState : TileState
    {
        public CriticalState(SpriteRenderer renderer) : base(renderer) { }
        
        public override void StartDisplaying()
        {
            LogManager.LogProgress();
            
            if (IsDisplaying == false)
            {
                Coroutine = FadeIn();
                StaticCoroutineHandler.StartCoroutine(Coroutine);
            }

            Count++;
        }
        
        public override void StopDisplaying()
        {
            LogManager.LogProgress();

            Count--;
            if (IsDisplaying)
            {
                return;
            }

            Renderer.color = new Color(1f, 1f, 1f, 0f);
            
            Coroutine = FadeOut();
            StaticCoroutineHandler.StartCoroutine(Coroutine);
        }

        private IEnumerator FadeIn()
        {
            for (var i = 0f; i <= 0.5f; i += FixedDeltaTime)
            {
                var alpha = i * 2;
                Renderer.color = new Color(1f, 1f, 1f, alpha);

                yield return null;
            }
            
            StaticCoroutineHandler.StopCoroutine(Coroutine);
            Coroutine = null;
        }
        
        private IEnumerator FadeOut()
        {
            for (var i = 0.5f; i >= 0f; i -= FixedDeltaTime)
            {
                var alpha = i * 2;
                Renderer.color = new Color(1f, 1f, 1f, alpha);
                
                yield return null;
            }
            
            StaticCoroutineHandler.StopCoroutine(Coroutine);
            Coroutine = null;
        }
    }
}