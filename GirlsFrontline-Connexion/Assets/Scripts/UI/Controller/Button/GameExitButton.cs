using GloryDay.Log;
using Utility.Manager;

namespace UI.Controller.Button
{
    public class GameExitButton : UIButtonBase
    {
        // Awake is called when the script instance is being loaded.
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();
            
            SetHoverSound(0);
            SetClickSound(1);
        }
        
        protected override void Click()
        {
            LogManager.LogMessage("<b>Exit Button</b> is clicked");
            
            base.Click();
            
            GameManager.OnApplicationQuit();
        }
    }
}
