using System.Collections;
using GloryDay;
using GloryDay.Debug.Log;
using UnityEngine;

namespace Object.Map
{
    public class WarningState : TileState
    {
        public WarningState(SpriteRenderer renderer) : base(renderer) { }
        
        public override void StartDisplaying()
        {
            LogManager.LogProgress();
            
            if (IsDisplaying == false)
            {
                Coroutine = Blink();
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