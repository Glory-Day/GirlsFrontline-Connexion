using GloryDay.Log;
using GloryDay.UI.Controller.Toggle;
using UnityEngine.EventSystems;
using Utility.Manager;

namespace UI.Controller.Toggle
{
    public class UIToggleBase : ToggleBase
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
        
        protected override void ValueChanged(bool value)
        {
            LogManager.LogProgress();
            
            SoundManager.OnPlayEffectAudioSource(ClickSound);
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            LogManager.LogProgress();

            if (Toggle.IsActive() && Toggle.IsInteractable())
            {
                SoundManager.OnPlayEffectAudioSource(HoverSound);
            }
        }
    }
}