using GloryDay.Debug;
using Core.Utility.Management;

namespace Core.UI.Controller.Toggle
{
    public class EnemyCountDisplayToggle : ToggleBase
    {
        public override void Initialize()
        {
            Console.LogProgress();

            base.Initialize();

            IsOn = DataManager.UserData.Default.IsDisplayAllowed[1];
        }

        protected override void ValueChanged(bool value)
        {
            Console.LogProgress();

            base.ValueChanged(value);

            DataManager.UserData.Default.IsDisplayAllowed[1] = value;
            DataManager.SaveUserData();
        }
    }
}
