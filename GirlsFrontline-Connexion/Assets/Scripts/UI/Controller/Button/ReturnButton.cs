using GloryDay.Log;
using GloryDay.UI.Controller.Button;
using Utility.Manager;
using Utility.Manager.UI;

namespace UI.Controller.Button
{
    public class ReturnButton : ButtonBase
    {
        // Start is called before the first frame update
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();
        }

        #region BUTTON EVENT API

        protected override void Click()
        {
            LogManager.LogMessage("<b>Return Button</b> is clicked");
            
            Button.interactable = false;
            
            SceneManager.OnLoadSceneByIndex(1, TransitionMode.Slide);
        }

        #endregion
    }
}
