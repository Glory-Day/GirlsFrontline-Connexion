using GloryDay.Log;
using GloryDay.UI.Controller.Button;
using Object;
using UnityEngine;

namespace UI.Controller.Button
{
    public class ResetDataButton : ButtonBase
    {
        private GameObject _resetDataScreen;
        private GameObject _optionScreen;
        
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();

            var parent = transform.parent;
            _resetDataScreen = parent.gameObject;
            _optionScreen = parent.parent.gameObject;
        }
        
        #region BUTTON EVENT API

        protected override void Click()
        {
            LogManager.LogMessage("<b>Reset Data</b> is clicked");
            
            BootManager.Reboot();
            
            _resetDataScreen.SetActive(false);
            _optionScreen.SetActive(false);
        }

        #endregion
    }
}