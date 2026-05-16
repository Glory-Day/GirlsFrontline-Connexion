using GloryDay.Debug;
using GloryDay.UI.Controller.Slider;
using Core.Utility.Management;

namespace Core.UI.Controller.Slider
{
    public class VoiceAudioMixerSlider : SliderBase
    {
        public override void Initialize()
        {
            Console.LogProgress();

            base.Initialize();

            var volume = DataManager.UserData.Sound[2].Volume;
            SoundManager.VoiceAudioVolume = volume;
            Slider.value = volume;
        }

        protected override void ValueChanged(float value)
        {
            SoundManager.VoiceAudioVolume = value;

            DataManager.UserData.Sound[2].Volume = value;
            DataManager.SaveUserData();
        }
    }
}
