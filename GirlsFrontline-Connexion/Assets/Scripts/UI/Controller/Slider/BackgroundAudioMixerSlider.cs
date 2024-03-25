using GloryDay.Log;
using GloryDay.UI.Controller.Slider;
using Utility.Manager;

namespace UI.Controller.Slider
{
    public class BackgroundAudioMixerSlider : SliderBase
    {
        // Start is called before the first frame update
        protected override void Start()
        {
            LogManager.LogProgress();
            
            base.Start();

            Slider.value = DataManager.UserData.Option.Volume.Background;
        }

        protected override void ValueChanged(float value)
        {
            DataManager.UserData.Option.Volume.Background = value;
            DataManager.OnSaveUserData();
            
            if (SoundManager.IsBackgroundAudioMute)
            {
                return;
            }
            
            SoundManager.SetBackgroundAudioVolume(value);
        }
    }
}
