using GloryDay.Debug;
using GloryDay.UI;
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/OptionPopUpScreen.cs
using Core.UI.Controller.Toggle;
using UnityEngine.InputSystem;
using Core.Utility.Manager;

namespace Core.UI
========
using Backend.Object.UI.Controller.Toggle;
using UnityEngine.InputSystem;
using Backend.Utility.Management;

namespace Backend.Object.UI
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/OptionPopUpScreen.cs
{
    public class OptionPopUpScreen : PopUpScreenBase
    {
        protected override void Awake()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/OptionPopUpScreen.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/OptionPopUpScreen.cs
            base.Awake();

            SetInputActionCallbackName(typeof(OptionPopUpScreen), "Toggle");
            SetInputAction("escape");

            DisplayToggles[0] = GetComponentInChildren<ChapterRankDisplayToggle>();
            DisplayToggles[1] = GetComponentInChildren<EnemyCountDisplayToggle>();
            DisplayToggles[2] = GetComponentInChildren<ElapsedTimeDisplayToggle>();
            DisplayToggles[3] = GetComponentInChildren<ChapterScoreDisplayToggle>();

            var key = DataManager.AudioData.Effect[2];
            var clip = ResourceManager.AudioClipResource.Effect[key];
            OpenPopUpSound = clip;
        }

        protected override void Start()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/OptionPopUpScreen.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/OptionPopUpScreen.cs
            base.Start();

            ScreenObject.SetActive(false);
        }

        protected override void Toggle(InputAction.CallbackContext context)
        {
            Toggle();
        }

        public void Toggle()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/OptionPopUpScreen.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/OptionPopUpScreen.cs
            if (ScreenObject.activeSelf)
            {
                ScreenObject.SetActive(false);

                ApplicationManager.Play();
            }
            else
            {
                SoundManager.OnPlayEffectAudioSource(OpenPopUpSound);

                ScreenObject.SetActive(true);

                ApplicationManager.Pause();
            }
        }

        public UIToggleBase[] DisplayToggles { get; } = new UIToggleBase[4];
    }
}
