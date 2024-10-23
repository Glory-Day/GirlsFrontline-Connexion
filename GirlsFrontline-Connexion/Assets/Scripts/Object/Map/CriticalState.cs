using System.Collections;
using GloryDay;
using GloryDay.Debug.Log;
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
                StaticCoroutine.Start(Coroutine);
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
            StaticCoroutine.Start(Coroutine);
        }

        private IEnumerator FadeIn()
        {
            for (var i = 0f; i <= 0.5f; i += Time.fixedDeltaTime)
            {
                var alpha = i * 2;
                Renderer.color = new Color(1f, 1f, 1f, alpha);

                yield return null;
            }
            
            StaticCoroutine.Stop(Coroutine);
            Coroutine = null;
        }
        
        private IEnumerator FadeOut()
        {
            for (var i = 0.5f; i >= 0f; i -= Time.fixedDeltaTime)
            {
                var alpha = i * 2;
                Renderer.color = new Color(1f, 1f, 1f, alpha);
                
                yield return null;
            }
            
            StaticCoroutine.Stop(Coroutine);
            Coroutine = null;
        }
    }
}