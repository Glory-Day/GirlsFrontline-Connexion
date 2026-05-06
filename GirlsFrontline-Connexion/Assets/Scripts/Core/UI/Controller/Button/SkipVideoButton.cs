using System;
using GloryDay.Debug;
using GloryDay.UI.Controller.Button;
using Core.UI.Utility.Input;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Core.Utility.Manager;

using Console = GloryDay.Debug.Console;

namespace Core.UI.Controller.Button
{
    public class SkipVideoButton : UIButtonBase
    {
        protected override void Awake()
        {
            Console.LogProgress();
            
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
