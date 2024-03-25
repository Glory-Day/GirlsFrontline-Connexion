using GloryDay.Log;
using GloryDay.UI.Controller.Button;
using UnityEngine;

namespace UI.Controller.Button
{
    public class DisableScreenButton : ButtonBase
    {
        #region SERIALIZED FIELD API

        [Header("Screen Game Object")]
        [SerializeField]
        private GameObject screenObject;

        #endregion
        
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();
        }
        
        #region BUTTON EVENT API

        protected override void Click()
        {
            LogManager.LogMessage("<b>Disable Screen Button</b> is clicked");
            
            screenObject.SetActive(false);
        }

        #endregion
    }
}