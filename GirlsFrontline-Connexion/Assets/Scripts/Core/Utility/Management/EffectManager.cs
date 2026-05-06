using System.Collections;
using GloryDay.Services;
using GloryDay.Utility;
using UnityEngine;

<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/EffectManager.cs
namespace Core.Utility.Manager
========
namespace Backend.Utility.Management
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/EffectManager.cs
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
            StaticCoroutine.Start(FadeOut(spriteRenderer, time));
        }

        #endregion
    }
}
