using GloryDay.Log;
using Utility.Manager;
using GloryDay.UI.Controller.Button;
using Utility.Manager.UI;

namespace UI.Controller.Button
{
    public class GameStartButton : ButtonBase
    {
        // Awake is called when the script instance is being loaded
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();
        }

        #region BUTTON EVENT API

        protected override void Click()
        {
            LogManager.LogMessage("<b>Game Start Button</b> is clicked");
            
            Button.interactable = false;
            
            SceneManager.OnLoadSceneByIndex(2, TransitionMode.Slide);
        }
        
        #endregion
    }
}
