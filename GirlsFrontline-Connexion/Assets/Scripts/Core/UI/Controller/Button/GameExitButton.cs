using GloryDay.Debug;
using Core.Utility.Manager;

namespace Core.UI.Controller.Button
{
    public class GameExitButton : UIButtonBase
    {
        // Awake is called when the script instance is being loaded.
        protected override void Awake()
        {
            Console.LogProgress();
            
            base.Awake();
            
            SetHoverSound(0);
            SetClickSound(1);
        }
        
        protected override void Click()
        {
            Console.LogMessage("<b>Exit Button</b> is clicked");
            
            base.Click();
            
            GameManager.OnApplicationQuit();
        }
    }
}
