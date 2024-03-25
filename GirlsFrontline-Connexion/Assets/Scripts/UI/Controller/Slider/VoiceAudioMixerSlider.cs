using GloryDay.Log;
using GloryDay.UI.Controller.Slider;
using Utility.Manager;

namespace UI.Controller.Slider
{
    public class VoiceAudioMixerSlider : SliderBase
    {
        // Start is called before the first frame update
        protected override void Start()
        {
            LogManager.LogProgress();
            
            base.Start();
            
            Slider.value = DataManager.UserData.Option.Volume.Voice;
        }

        protected override void ValueChanged(float value)
        {
            DataManager.UserData.Option.Volume.Voice = value;
            DataManager.OnSaveUserData();
            
            if (SoundManager.IsVoiceAudioMute)
            {
                return;
            }
            
            SoundManager.SetVoiceAudioVolume(value);
        }
    }
}
