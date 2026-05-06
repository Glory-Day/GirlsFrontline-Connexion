using GloryDay.Debug;
using GloryDay.UI.Controller.Toggle;
using UnityEngine.EventSystems;
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Toggle/UIToggleBase.cs
using Core.Utility.Manager;

namespace Core.UI.Controller.Toggle
========
using Backend.Utility.Management;

namespace Backend.Object.UI.Controller.Toggle
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Toggle/UIToggleBase.cs
{
    public class UIToggleBase : ToggleBase
    {
        protected void SetHoverSound(int index)
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Toggle/UIToggleBase.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Toggle/UIToggleBase.cs
            var key = DataManager.AudioData.Effect[index];
            var clip = ResourceManager.AudioClipResource.Effect[key];
            HoverSound = clip;
        }

        protected void SetClickSound(int index)
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Toggle/UIToggleBase.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Toggle/UIToggleBase.cs
            var key = DataManager.AudioData.Effect[index];
            var clip = ResourceManager.AudioClipResource.Effect[key];
            ClickSound = clip;
        }

        protected override void ValueChanged(bool value)
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Toggle/UIToggleBase.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Toggle/UIToggleBase.cs
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
