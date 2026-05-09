using GloryDay.Debug;
using Core.Utility.Management;

namespace Core.UI.Controller.Toggle
{
    public class VoiceAudioMixerMuteToggle : ToggleBase
    {
        // Start is called before the first frame update
        public override void Initialize()
        {
            Console.LogProgress();

            base.Initialize();

            var isMute = DataManager.UserData.Sound[2].IsMute;
            SoundManager.IsVoiceAudioMute = isMute;

            IsOn = isMute;
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
