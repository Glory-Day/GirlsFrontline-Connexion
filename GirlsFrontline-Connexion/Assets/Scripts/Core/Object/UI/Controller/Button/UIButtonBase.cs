using GloryDay.Debug;
using GloryDay.UI.Controller.Button;
using UnityEngine.EventSystems;
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/UIButtonBase.cs
using Core.Utility.Manager;

namespace Core.UI.Controller.Button
========
using Backend.Utility.Management;

namespace Backend.Object.UI.Controller.Button
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/UIButtonBase.cs
{
    public abstract class UIButtonBase : ButtonBase
    {
        protected void SetHoverSound(int index)
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/UIButtonBase.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/UIButtonBase.cs
            var key = DataManager.AudioData.Effect[index];
            var clip = ResourceManager.AudioClipResource.Effect[key];
            HoverSound = clip;
        }

        protected void SetClickSound(int index)
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/UIButtonBase.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/UIButtonBase.cs
            var key = DataManager.AudioData.Effect[index];
            var clip = ResourceManager.AudioClipResource.Effect[key];
            ClickSound = clip;
        }

        protected override void Click()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/UIButtonBase.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/UIButtonBase.cs
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
