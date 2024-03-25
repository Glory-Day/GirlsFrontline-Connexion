using GloryDay.Log;
using Utility.Manager;
using GloryDay.UI.Controller.Button;

namespace UI.Controller.Button
{
    public class GameExitButton : ButtonBase
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
            LogManager.LogMessage("<b>Exit Button</b> is clicked");
            
            GameManager.OnApplicationQuit();
        }

        #endregion
    }
}
