using GloryDay.Log;
using Utility.Manager;

namespace UI.Controller.Toggle
{
    public class ElapsedTimeDisplayToggle : UIToggleBase
    {
        protected override void Awake()
        {
            LogManager.LogProgress();

            base.Awake();

            IsOn = DataManager.UserData.Default.IsDisplayAllowed[2];
            
            SetHoverSound(0);
            SetClickSound(1);
        }
        
        protected override void ValueChanged(bool value)
        {
            LogManager.LogProgress();

            base.ValueChanged(value);
            
            DataManager.UserData.Default.IsDisplayAllowed[2] = value;
            DataManager.OnSaveUserData();
        }
    }
}