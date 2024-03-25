using GloryDay.Log;
using GloryDay.UI.Controller.Slider;
using Utility.Manager;

namespace UI.Controller.Slider
{
    public class EffectAudioMixerSlider : SliderBase
    {
        // Start is called before the first frame update
        protected override void Start()
        {
            LogManager.LogProgress();
            
            base.Start();
            
            Slider.value = DataManager.UserData.Option.Volume.Effect;
        }

        protected override void ValueChanged(float value)
        {
            DataManager.UserData.Option.Volume.Effect = value;
            DataManager.OnSaveUserData();
            
            if (SoundManager.IsEffectAudioMute)
            {
                return;
            }
            
            SoundManager.SetEffectAudioVolume(value);
        }
    }
}
