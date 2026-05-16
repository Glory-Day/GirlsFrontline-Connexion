using GloryDay.Debug;
using Core.Utility.Management;

namespace Core.UI.Controller.Toggle
{
    public class EffectAudioMixerMuteToggle : ToggleBase
    {
        // Start is called before the first frame update
        public override void Initialize()
        {
            Console.LogProgress();

            base.Initialize();

            var isMute = DataManager.UserData.Sound[1].IsMute;
            SoundManager.IsEffectAudioMute = isMute;

            IsOn = isMute;
        }

        protected override void ValueChanged(bool value)
        {
            Console.LogProgress();

            base.ValueChanged(value);

            SoundManager.IsEffectAudioMute = value;

            DataManager.UserData.Sound[1].IsMute = value;
            DataManager.SaveUserData();
        }
    }
}
