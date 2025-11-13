using GloryDay.Debug.Log;
using GloryDay.UI.Controller.Slider;
using Backend.Utility.Management;

namespace Backend.Object.UI.Controller.Slider
{
    public class BackgroundAudioMixerSlider : SliderBase
    {
        // Start is called before the first frame update
        protected override void Awake()
        {
            LogManager.LogProgress();

            base.Awake();

            var volume = DataManager.UserData.Sound[0].Volume;
            SoundManager.SetBackgroundAudioVolume(volume);
            Slider.value = volume;
        }

        protected override void ValueChanged(float value)
        {
            SoundManager.SetBackgroundAudioVolume(value);

            DataManager.UserData.Sound[0].Volume = value;
            DataManager.OnSaveUserData();
        }
    }
}
