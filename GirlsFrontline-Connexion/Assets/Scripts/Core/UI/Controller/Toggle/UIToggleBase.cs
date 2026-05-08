using GloryDay.Debug;
using GloryDay.UI.Controller.Toggle;
using UnityEngine.EventSystems;
using Core.Utility.Management;

namespace Core.UI.Controller.Toggle
{
    public class UIToggleBase : ToggleBase
    {
        protected void SetHoverSound(int index)
        {
            Console.LogProgress();
            
            var key = DataManager.AudioData.Effect[index];
            var clip = ResourceManager.AudioClipResource.Effect[key];
            HoverSound = clip;
        }
        
        protected void SetClickSound(int index)
        {
            Console.LogProgress();
            
            var key = DataManager.AudioData.Effect[index];
            var clip = ResourceManager.AudioClipResource.Effect[key];
            ClickSound = clip;
        }
        
        protected override void ValueChanged(bool value)
        {
            Console.LogProgress();
            
            SoundManager.OnPlayEffectAudioSource(ClickSound);
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            Console.LogProgress();

            if (Toggle.IsActive() && Toggle.IsInteractable())
            {
                SoundManager.OnPlayEffectAudioSource(HoverSound);
            }
        }
    }
}
