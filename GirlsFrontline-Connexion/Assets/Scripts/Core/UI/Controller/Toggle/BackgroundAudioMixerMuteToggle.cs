using GloryDay.Debug;
using Core.Utility.Management;

namespace Core.UI.Controller.Toggle
{
    public class BackgroundAudioMixerMuteToggle : ToggleBase
    {
        // Start is called before the first frame update
        public override void Initialize()
        {
            Console.LogProgress();

            base.Initialize();

            var isMute = DataManager.UserData.Sound[0].IsMute;
            SoundManager.IsBackgroundAudioMute = isMute;

            IsOn = isMute;
        }

        protected override void ValueChanged(bool value)
        {
            Console.LogProgress();

            base.ValueChanged(value);

            SoundManager.IsBackgroundAudioMute = value;

            DataManager.UserData.Sound[0].IsMute = value;
            DataManager.SaveUserData();
        }
    }
}
