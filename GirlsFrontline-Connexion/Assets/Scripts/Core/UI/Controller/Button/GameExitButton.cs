using GloryDay.Debug;
using Core.Utility.Management;

namespace Core.UI.Controller.Button
{
    public class GameExitButton : ButtonBase
    {
        protected override void Click()
        {
            Console.LogMessage("<b>Exit Button</b> is clicked");

            base.Click();

            GameManager.OnApplicationQuit();
        }
    }
}
