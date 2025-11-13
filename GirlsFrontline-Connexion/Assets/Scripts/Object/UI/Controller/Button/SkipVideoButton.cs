using System;
using GloryDay.Debug.Log;
using GloryDay.UI.Controller.Button;
using Backend.Utility.Input;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Backend.Utility.Management;

namespace Backend.Object.UI.Controller.Button
{
    public class SkipVideoButton : UIButtonBase
    {
        protected override void Awake()
        {
            LogManager.LogProgress();

            base.Awake();

            SetHoverSound(0);
            SetClickSound(1);
        }

        protected override void Click()
        {
            LogManager.LogMessage("<b>Video</b> is skipped");

            base.Click();

            SceneManager.OnLoadSceneByIndex(1);
        }
    }
}
