using System.Collections;
using GloryDay.Threading;
using GloryDay.Utility;
using UnityEngine;

namespace Utility.Manager
{
    public class EffectManager : Singleton<EffectManager>
    {
        private static IEnumerator FadeOut(SpriteRenderer spriteRenderer, float time = 1f)
        {
            var total = 0f;
            var color = spriteRenderer.color;
            while (total < time)
            {
                spriteRenderer.color = new Color(color.r, color.g, color.b, color.a - total / time);
                total += Time.deltaTime;

                yield return null;
            }
        }
        
        #region STATIC METHOD API

        public static void OnFadeOut(SpriteRenderer spriteRenderer, float time = 1f)
        {
            StaticCoroutineHandler.StartCoroutine(FadeOut(spriteRenderer, time));
        }

        #endregion
    }
}