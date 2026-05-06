using GloryDay.Debug;
using GloryDay.UI.Controller.Slider;
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Slider/EffectAudioMixerSlider.cs
using Core.Utility.Manager;

namespace Core.UI.Controller.Slider
========
using Backend.Utility.Management;

namespace Backend.Object.UI.Controller.Slider
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Slider/EffectAudioMixerSlider.cs
{
    public class EffectAudioMixerSlider : SliderBase
    {
        // Start is called before the first frame update
        protected override void Awake()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Slider/EffectAudioMixerSlider.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Slider/EffectAudioMixerSlider.cs
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
