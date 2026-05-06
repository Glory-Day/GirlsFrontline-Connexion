<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Toggle/EffectAudioMixerMuteToggle.cs
﻿using GloryDay.Debug;
using Core.Utility.Manager;

namespace Core.UI.Controller.Toggle
========
﻿using GloryDay.Debug.Log;
using Backend.Utility.Management;

namespace Backend.Object.UI.Controller.Toggle
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Toggle/EffectAudioMixerMuteToggle.cs
{
    public class EffectAudioMixerMuteToggle : UIToggleBase
    {
        // Start is called before the first frame update
        protected override void Awake()
        {
            Console.LogProgress();

            base.Awake();

            var isMute = DataManager.UserData.Sound[1].IsMute;
            SoundManager.IsEffectAudioMute = isMute;
            IsOn = isMute;

            SetHoverSound(0);
            SetClickSound(1);
        }

        protected override void ValueChanged(bool value)
        {
            Console.LogProgress();

            base.ValueChanged(value);

            SoundManager.IsEffectAudioMute = value;

            DataManager.UserData.Sound[1].IsMute = value;
            DataManager.OnSaveUserData();
        }
    }
}
