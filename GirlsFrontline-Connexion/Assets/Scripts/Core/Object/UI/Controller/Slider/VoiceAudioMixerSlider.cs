using GloryDay.Debug;
using GloryDay.UI.Controller.Slider;
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Slider/VoiceAudioMixerSlider.cs
using Core.Utility.Manager;

namespace Core.UI.Controller.Slider
========
using Backend.Utility.Management;

namespace Backend.Object.UI.Controller.Slider
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Slider/VoiceAudioMixerSlider.cs
{
    public class VoiceAudioMixerSlider : SliderBase
    {
        // Start is called before the first frame update
        protected override void Awake()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Slider/VoiceAudioMixerSlider.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Slider/VoiceAudioMixerSlider.cs
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
