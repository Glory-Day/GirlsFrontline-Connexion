using GloryDay.Debug;
using GloryDay.UI.Controller.Slider;
using Core.Utility.Management;

namespace Core.UI.Controller.Slider
{
    public class BackgroundAudioMixerSlider : SliderBase
    {
        public override void Initialize()
        {
            Console.LogProgress();

            base.Initialize();

            var volume = DataManager.UserData.Sound[0].Volume;
            SoundManager.BackgroundAudioVolume = volume;
            Slider.value = volume;
        }

        protected override void ValueChanged(float value)
        {
            SoundManager.BackgroundAudioVolume = value;

            DataManager.UserData.Sound[0].Volume = value;
            DataManager.SaveUserData();
        }
    }
}
