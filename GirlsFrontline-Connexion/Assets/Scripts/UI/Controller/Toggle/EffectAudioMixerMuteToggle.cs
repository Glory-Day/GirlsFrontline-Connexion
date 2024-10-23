using GloryDay.Debug.Log;
using Utility.Manager;

namespace UI.Controller.Toggle
{
    public class EffectAudioMixerMuteToggle : UIToggleBase
    {
        // Start is called before the first frame update
        protected override void Awake()
        {
            LogManager.LogProgress();

            base.Awake();

            var isMute = DataManager.UserData.Sound[1].IsMute;
            SoundManager.IsEffectAudioMute = isMute;
            IsOn = isMute;
            
            SetHoverSound(0);
            SetClickSound(1);
        }
        
        protected override void ValueChanged(bool value)
        {
            LogManager.LogProgress();

            base.ValueChanged(value);
            
            SoundManager.IsEffectAudioMute = value;
            
            DataManager.UserData.Sound[1].IsMute = value;
            DataManager.OnSaveUserData();
        }
    }
}