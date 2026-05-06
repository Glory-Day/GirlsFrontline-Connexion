<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Toggle/BackgroundAudioMixerMuteToggle.cs
﻿using GloryDay.Debug;
using Core.Utility.Manager;

namespace Core.UI.Controller.Toggle
========
﻿using GloryDay.Debug.Log;
using Backend.Utility.Management;

namespace Backend.Object.UI.Controller.Toggle
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Toggle/BackgroundAudioMixerMuteToggle.cs
{
    public class BackgroundAudioMixerMuteToggle : UIToggleBase
    {
        // Start is called before the first frame update
        protected override void Awake()
        {
            Console.LogProgress();

            base.Awake();

            var isMute = DataManager.UserData.Sound[0].IsMute;
            SoundManager.IsBackgroundAudioMute = isMute;
            IsOn = isMute;

            SetHoverSound(0);
            SetClickSound(1);
        }

        protected override void ValueChanged(bool value)
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Toggle/BackgroundAudioMixerMuteToggle.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Toggle/BackgroundAudioMixerMuteToggle.cs
            base.ValueChanged(value);

            SoundManager.IsBackgroundAudioMute = value;

            DataManager.UserData.Sound[0].IsMute = value;
            DataManager.OnSaveUserData();
        }
    }
}
