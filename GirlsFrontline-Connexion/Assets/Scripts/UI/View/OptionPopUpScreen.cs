using GloryDay.Log;
using GloryDay.UI.View;
using UnityEngine.InputSystem;

namespace UI.View
{
    public class OptionPopUpScreen : PopUpScreenBase
    {
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();
            
            SetInputActionCallbackName(typeof(OptionPopUpScreen), "Toggle");
            SetInputAction("escape");
        }

        protected override void Start()
        {
            LogManager.LogProgress();
            
            base.Start();
        }
        
        protected override void Toggle(InputAction.CallbackContext context)
        {
            ScreenObject.SetActive(!ScreenObject.activeSelf);
        }
    }
}