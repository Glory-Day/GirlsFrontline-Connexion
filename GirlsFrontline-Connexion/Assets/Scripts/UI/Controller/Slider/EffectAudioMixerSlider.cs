using GloryDay.Debug.Log;
using GloryDay.UI.Controller.Slider;
using Utility.Manager;

namespace UI.Controller.Slider
{
    public class EffectAudioMixerSlider : SliderBase
    {
        // Start is called before the first frame update
        protected override void Awake()
        {
            LogManager.LogProgress();
            
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
