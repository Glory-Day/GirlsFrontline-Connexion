using GloryDay.Debug;
using GloryDay.UI.Controller.Slider;
using Core.Utility.Management;

namespace Core.UI.Controller.Slider
{
    public class EffectAudioMixerSlider : SliderBase
    {
        // Start is called before the first frame update
        protected override void Awake()
        {
            Console.LogProgress();
            
            base.Awake();
            
            var volume = DataManager.UserData.Sound[1].Volume;
            SoundManager.SetEffectAudioVolume(volume);
            Slider.value = volume;
        }

        protected override void ValueChanged(float value)
        {
            SoundManager.SetEffectAudioVolume(value);
            
            DataManager.UserData.Sound[1].Volume = value;
            DataManager.OnSaveUserData();
        }
    }
}
