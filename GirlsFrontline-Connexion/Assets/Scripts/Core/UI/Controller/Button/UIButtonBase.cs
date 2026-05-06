using GloryDay.Debug;
using GloryDay.UI.Controller.Button;
using UnityEngine.EventSystems;
using Core.Utility.Manager;

namespace Core.UI.Controller.Button
{
    public abstract class UIButtonBase : ButtonBase
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

        protected override void Click()
        {
            Console.LogProgress();
            
            SoundManager.OnPlayEffectAudioSource(ClickSound);
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            Console.LogProgress();

            if (Button.IsActive() && Button.IsInteractable())
            {
                SoundManager.OnPlayEffectAudioSource(HoverSound);
            }
        }
    }
}