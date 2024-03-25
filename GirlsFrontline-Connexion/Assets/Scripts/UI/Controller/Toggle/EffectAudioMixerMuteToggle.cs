using GloryDay.Log;
using GloryDay.UI.Controller.Toggle;
using Utility.Manager;

namespace UI.Controller.Toggle
{
    public class EffectAudioMixerMuteToggle : ToggleBase
    {
        // Start is called before the first frame update
        private void Start()
        {
            LogManager.LogProgress();

            IsOn = DataManager.UserData.Option.IsMute.Effect;
        }
        
        protected override void ChangeValue(bool value)
        {
            LogManager.LogProgress();

            if (value)
            {
                SoundManager.SetEffectAudioVolume(-80f);
            }
            else
            {
                SoundManager.SetBackgroundAudioVolume(DataManager.UserData.Option.Volume.Effect);
            }

            SoundManager.IsEffectAudioMute = value;
            
            DataManager.UserData.Option.IsMute.Effect = value;
            DataManager.OnSaveUserData();
        }
    }
}