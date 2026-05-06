using GloryDay.Debug;
using GloryDay.UI.Controller.Slider;
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Slider/BackgroundAudioMixerSlider.cs
using Core.Utility.Manager;

namespace Core.UI.Controller.Slider
========
using Backend.Utility.Management;

namespace Backend.Object.UI.Controller.Slider
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Slider/BackgroundAudioMixerSlider.cs
{
    public class BackgroundAudioMixerSlider : SliderBase
    {
        // Start is called before the first frame update
        protected override void Awake()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Slider/BackgroundAudioMixerSlider.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Slider/BackgroundAudioMixerSlider.cs
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
