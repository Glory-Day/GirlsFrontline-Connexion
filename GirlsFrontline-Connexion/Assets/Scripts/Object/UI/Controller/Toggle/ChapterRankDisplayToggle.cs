using GloryDay.Debug.Log;
using Backend.Utility.Management;

namespace Backend.Object.UI.Controller.Toggle
{
    public class ChapterRankDisplayToggle : UIToggleBase
    {
        protected override void Awake()
        {
            LogManager.LogProgress();

            base.Awake();

            IsOn = DataManager.UserData.Default.IsDisplayAllowed[0];

            SetHoverSound(0);
            SetClickSound(1);
        }

        protected override void ValueChanged(bool value)
        {
            LogManager.LogProgress();

            base.ValueChanged(value);

            DataManager.UserData.Default.IsDisplayAllowed[0] = value;
            DataManager.OnSaveUserData();
        }
    }
}
