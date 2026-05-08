using GloryDay.Debug;
using Core.Utility.Management;

namespace Core.UI.Controller.Toggle
{
    public class EffectAudioMixerMuteToggle : UIToggleBase
    {
        // Start is called before the first frame update
        protected override void Awake()
        {
            Console.LogProgress();

            base.Awake();

            var isMute = DataManager.UserData.Sound[1].IsMute;
            SoundManager.IsEffectAudioMute = isMute;
            IsOn = isMute;
            
            SetHoverSound(0);
            SetClickSound(1);
        }
        
        protected override void ValueChanged(bool value)
        {
            Console.LogProgress();

            base.ValueChanged(value);
            
            SoundManager.IsEffectAudioMute = value;
            
            DataManager.UserData.Sound[1].IsMute = value;
            DataManager.OnSaveUserData();
        }
    }
}
