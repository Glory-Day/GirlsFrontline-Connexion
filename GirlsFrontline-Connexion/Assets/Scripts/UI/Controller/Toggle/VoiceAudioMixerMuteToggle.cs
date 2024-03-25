using GloryDay.Log;
using GloryDay.UI.Controller.Toggle;
using Utility.Manager;

namespace UI.Controller.Toggle
{
    public class VoiceAudioMixerMuteToggle : ToggleBase
    {
        // Start is called before the first frame update
        private void Start()
        {
            LogManager.LogProgress();

            IsOn = DataManager.UserData.Option.IsMute.Voice;
        }
        
        protected override void ChangeValue(bool value)
        {
            LogManager.LogProgress();
            
            if (value)
            {
                SoundManager.SetVoiceAudioVolume(-80f);
            }
            else
            {
                SoundManager.SetBackgroundAudioVolume(DataManager.UserData.Option.Volume.Voice);
            }

            SoundManager.IsVoiceAudioMute = value;

            DataManager.UserData.Option.IsMute.Voice = value;
            DataManager.OnSaveUserData();
        }
    }
}