using GloryDay.Debug;
using GloryDay.UI.Controller.Slider;
using Core.Utility.Management;

namespace Core.UI.Controller.Slider
{
    public class EffectAudioMixerSlider : SliderBase
    {
        public override void Initialize()
        {
            Console.LogProgress();

            base.Initialize();

            var volume = DataManager.UserData.Sound[1].Volume;
            SoundManager.EffectAudioVolume = volume;
            Slider.value = volume;
        }

        protected override void ValueChanged(float value)
        {
            SoundManager.EffectAudioVolume = value;

            DataManager.UserData.Sound[1].Volume = value;
            DataManager.SaveUserData();
        }
    }
}
