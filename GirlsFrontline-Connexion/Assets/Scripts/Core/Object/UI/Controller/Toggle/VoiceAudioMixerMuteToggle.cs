<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Toggle/VoiceAudioMixerMuteToggle.cs
﻿using GloryDay.Debug;
using Core.Utility.Manager;

namespace Core.UI.Controller.Toggle
========
﻿using GloryDay.Debug.Log;
using Backend.Utility.Management;

namespace Backend.Object.UI.Controller.Toggle
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Toggle/VoiceAudioMixerMuteToggle.cs
{
    public class VoiceAudioMixerMuteToggle : UIToggleBase
    {
        // Start is called before the first frame update
        protected override void Awake()
        {
            Console.LogProgress();

            base.Awake();

            var isMute = DataManager.UserData.Sound[2].IsMute;
            SoundManager.IsVoiceAudioMute = isMute;
            IsOn = isMute;

            SetHoverSound(0);
            SetClickSound(1);
        }

        protected override void ValueChanged(bool value)
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Toggle/VoiceAudioMixerMuteToggle.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Toggle/VoiceAudioMixerMuteToggle.cs
            base.ValueChanged(value);

            SoundManager.IsVoiceAudioMute = value;

            DataManager.UserData.Sound[2].IsMute = value;
            DataManager.OnSaveUserData();
        }
    }
}
