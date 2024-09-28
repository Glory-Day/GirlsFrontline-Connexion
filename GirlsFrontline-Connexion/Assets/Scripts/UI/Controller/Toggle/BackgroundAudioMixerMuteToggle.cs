using GloryDay.Log;
using Utility.Manager;

namespace UI.Controller.Toggle
{
    public class BackgroundAudioMixerMuteToggle : UIToggleBase
    {
        // Start is called before the first frame update
        protected override void Awake()
        {
            LogManager.LogProgress();

            base.Awake();

            var isMute = DataManager.UserData.Sound[0].IsMute;
            SoundManager.IsBackgroundAudioMute = isMute;
            IsOn = isMute;
            
            SetHoverSound(0);
            SetClickSound(1);
        }
        
        protected override void ValueChanged(bool value)
        {
            LogManager.LogProgress();
            
            base.ValueChanged(value);
            
            SoundManager.IsBackgroundAudioMute = value;
            
            DataManager.UserData.Sound[0].IsMute = value;
            DataManager.OnSaveUserData();
        }
    }
}