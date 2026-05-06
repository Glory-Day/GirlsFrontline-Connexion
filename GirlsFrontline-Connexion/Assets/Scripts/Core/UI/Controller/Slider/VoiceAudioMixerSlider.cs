using GloryDay.Debug;
using GloryDay.UI.Controller.Slider;
using Core.Utility.Manager;

namespace Core.UI.Controller.Slider
{
    public class VoiceAudioMixerSlider : SliderBase
    {
        // Start is called before the first frame update
        protected override void Awake()
        {
            Console.LogProgress();
            
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
