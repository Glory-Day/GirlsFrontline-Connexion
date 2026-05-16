using Core.Utility.Management;

using Console = GloryDay.Debug.Console;

namespace Core.UI.Controller.Button
{
    public class SkipVideoButton : ButtonBase
    {
        protected override void Click()
        {
            Console.LogMessage("<b>Video</b> is skipped");

            base.Click();

            SceneManager.OnLoadSceneByIndex(1);
        }
    }
}
