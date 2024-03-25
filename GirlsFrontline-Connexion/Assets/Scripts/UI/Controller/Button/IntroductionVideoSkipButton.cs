using GloryDay.Log;
using GloryDay.UI.Controller.Button;
using Utility.Manager;
using Utility.Manager.UI;

namespace UI.Controller.Button
{
    public class IntroductionVideoSkipButton : ButtonBase
    {
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();
        }

        #region BUTTON EVENT API

        protected override void Click()
        {
            LogManager.LogMessage("<b>Video</b> is skipped");

            SceneManager.OnLoadSceneByIndex(1, TransitionMode.None);
        }
        
        #endregion
    }
}
