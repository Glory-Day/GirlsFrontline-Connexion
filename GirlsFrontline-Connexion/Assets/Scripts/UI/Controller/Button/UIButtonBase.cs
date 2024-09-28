using GloryDay.Log;
using GloryDay.UI.Controller.Button;
using UnityEngine.EventSystems;
using Utility.Manager;

namespace UI.Controller.Button
{
    public abstract class UIButtonBase : ButtonBase
    {
        protected void SetHoverSound(int index)
        {
            LogManager.LogProgress();
            
            var key = DataManager.AudioData.Effect[index];
            var clip = ResourceManager.AudioClipResource.Effect[key];
            HoverSound = clip;
        }
        
        protected void SetClickSound(int index)
        {
            LogManager.LogProgress();
            
            var key = DataManager.AudioData.Effect[index];
            var clip = ResourceManager.AudioClipResource.Effect[key];
            ClickSound = clip;
        }

        protected override void Click()
        {
            LogManager.LogProgress();
            
            SoundManager.OnPlayEffectAudioSource(ClickSound);
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            LogManager.LogProgress();

            if (Button.IsActive() && Button.IsInteractable())
            {
                SoundManager.OnPlayEffectAudioSource(HoverSound);
            }
        }
    }
}