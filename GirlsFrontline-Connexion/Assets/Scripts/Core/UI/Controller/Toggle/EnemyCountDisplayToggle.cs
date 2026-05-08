using GloryDay.Debug;
using Core.Utility.Management;

namespace Core.UI.Controller.Toggle
{
    public class EnemyCountDisplayToggle : UIToggleBase
    {
        protected override void Awake()
        {
            Console.LogProgress();

            base.Awake();
            
            IsOn = DataManager.UserData.Default.IsDisplayAllowed[1];
            
            SetHoverSound(0);
            SetClickSound(1);
        }
        
        protected override void ValueChanged(bool value)
        {
            Console.LogProgress();

            base.ValueChanged(value);
            
            DataManager.UserData.Default.IsDisplayAllowed[1] = value;
            DataManager.OnSaveUserData();
        }
    }
}
