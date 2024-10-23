using GloryDay.Debug.Log;
using Utility.Manager;

namespace UI.Controller.Toggle
{
    public class EnemyCountDisplayToggle : UIToggleBase
    {
        protected override void Awake()
        {
            LogManager.LogProgress();

            base.Awake();
            
            IsOn = DataManager.UserData.Default.IsDisplayAllowed[1];
            
            SetHoverSound(0);
            SetClickSound(1);
        }
        
        protected override void ValueChanged(bool value)
        {
            LogManager.LogProgress();

            base.ValueChanged(value);
            
            DataManager.UserData.Default.IsDisplayAllowed[1] = value;
            DataManager.OnSaveUserData();
        }
    }
}