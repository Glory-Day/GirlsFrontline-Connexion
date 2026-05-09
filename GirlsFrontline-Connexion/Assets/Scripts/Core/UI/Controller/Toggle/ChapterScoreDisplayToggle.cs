using GloryDay.Debug;
using Core.Utility.Management;

namespace Core.UI.Controller.Toggle
{
    public class ChapterScoreDisplayToggle : ToggleBase
    {
        protected override void Awake()
        {
            Console.LogProgress();

            base.Awake();

            IsOn = DataManager.UserData.Default.IsDisplayAllowed[3];
        }

        protected override void ValueChanged(bool value)
        {
            Console.LogProgress();

            base.ValueChanged(value);

            DataManager.UserData.Default.IsDisplayAllowed[3] = value;
            DataManager.OnSaveUserData();
        }
    }
}
