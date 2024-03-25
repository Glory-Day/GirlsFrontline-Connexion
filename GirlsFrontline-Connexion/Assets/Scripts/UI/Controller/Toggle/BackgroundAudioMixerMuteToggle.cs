using GloryDay.Log;
using GloryDay.UI.Controller.Toggle;
using Utility.Manager;

namespace UI.Controller.Toggle
{
    public class BackgroundAudioMixerMuteToggle : ToggleBase
    {
        // Start is called before the first frame update
        private void Start()
        {
            LogManager.LogProgress();

            IsOn = DataManager.UserData.Option.IsMute.Background;
        }
        
        protected override void ChangeValue(bool value)
        {
            LogManager.LogProgress();
            
            if (value)
            {
                SoundManager.SetBackgroundAudioVolume(-80f);
            }
            else
            {
                SoundManager.SetBackgroundAudioVolume(DataManager.UserData.Option.Volume.Background);
            }

            SoundManager.IsBackgroundAudioMute = value;
            
            DataManager.UserData.Option.IsMute.Background = value;
            DataManager.OnSaveUserData();
        }
    }
}