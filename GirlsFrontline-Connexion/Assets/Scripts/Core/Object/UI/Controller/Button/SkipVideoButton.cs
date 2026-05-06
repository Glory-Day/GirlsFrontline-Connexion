using System;
using GloryDay.Debug;
using GloryDay.UI.Controller.Button;
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/SkipVideoButton.cs
using Core.UI.Utility.Input;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Core.Utility.Manager;

using Console = GloryDay.Debug.Console;

namespace Core.UI.Controller.Button
========
using Backend.Utility.Input;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Backend.Utility.Management;

namespace Backend.Object.UI.Controller.Button
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/SkipVideoButton.cs
{
    public class SkipVideoButton : UIButtonBase
    {
        protected override void Awake()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/SkipVideoButton.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/SkipVideoButton.cs
            base.Awake();

            SetHoverSound(0);
            SetClickSound(1);
        }

        protected override void Click()
        {
            Console.LogMessage("<b>Video</b> is skipped");

            base.Click();

            SceneManager.OnLoadSceneByIndex(1);
        }
    }
}
