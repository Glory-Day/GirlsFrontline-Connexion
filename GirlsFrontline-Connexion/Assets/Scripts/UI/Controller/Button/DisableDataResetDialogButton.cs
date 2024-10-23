using GloryDay.Debug.Log;
using GloryDay.UI.Controller.Button;
using UnityEngine;

namespace UI.Controller.Button
{
    public class DisableDataResetDialogButton : UIButtonBase
    {
        private GameObject _dialogObject;
        
        // Awake is called when the script instance is being loaded.
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();

            _dialogObject = transform.parent.gameObject;
            
            SetHoverSound(0);
            SetClickSound(1);
        }

        protected override void Click()
        {
            LogManager.LogMessage("<b>Disable Dialog Button</b> is clicked");
            
            base.Click();
            
            _dialogObject.SetActive(false);
        }
    }
}