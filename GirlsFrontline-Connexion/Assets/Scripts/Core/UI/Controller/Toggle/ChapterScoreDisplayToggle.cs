using GloryDay.Debug;
using Core.Utility.Management;

namespace Core.UI.Controller.Toggle
{
    public class ChapterScoreDisplayToggle : ToggleBase
    {
        public override void Initialize()
        {
            Console.LogProgress();

            base.Initialize();

            IsOn = DataManager.UserData.Default.IsDisplayAllowed[3];
        }

        protected override void ValueChanged(bool value)
        {
            Console.LogProgress();

            base.ValueChanged(value);

            DataManager.UserData.Default.IsDisplayAllowed[3] = value;
            DataManager.SaveUserData();
        }
    }
}
