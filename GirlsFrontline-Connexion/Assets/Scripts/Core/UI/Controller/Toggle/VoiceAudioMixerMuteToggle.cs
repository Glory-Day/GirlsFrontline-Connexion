using GloryDay.Debug;
using Core.Utility.Manager;

namespace Core.UI.Controller.Toggle
{
    public class VoiceAudioMixerMuteToggle : UIToggleBase
    {
        // Start is called before the first frame update
        protected override void Awake()
        {
            Console.LogProgress();

            base.Awake();

            var isMute = DataManager.UserData.Sound[2].IsMute;
            SoundManager.IsVoiceAudioMute = isMute;
            IsOn = isMute;
            
            SetHoverSound(0);
            SetClickSound(1);
        }
        
        protected override void ValueChanged(bool value)
        {
            Console.LogProgress();
            
            base.ValueChanged(value);
            
            SoundManager.IsVoiceAudioMute = value;

            DataManager.UserData.Sound[2].IsMute = value;
            DataManager.OnSaveUserData();
        }
    }
}