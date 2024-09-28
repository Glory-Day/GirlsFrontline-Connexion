using GloryDay.Log;
using GloryDay.UI.Controller.Slider;
using Utility.Manager;

namespace UI.Controller.Slider
{
    public class VoiceAudioMixerSlider : SliderBase
    {
        // Start is called before the first frame update
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();
            
            var volume = DataManager.UserData.Sound[2].Volume;
            SoundManager.SetVoiceAudioVolume(volume);
            Slider.value = volume;
        }

        protected override void ValueChanged(float value)
        {
            SoundManager.SetVoiceAudioVolume(value);
            
            DataManager.UserData.Sound[2].Volume = value;
            DataManager.OnSaveUserData();
        }
    }
}
