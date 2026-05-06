<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Toggle/ElapsedTimeDisplayToggle.cs
﻿using GloryDay.Debug;
using Core.Utility.Manager;

namespace Core.UI.Controller.Toggle
========
﻿using GloryDay.Debug.Log;
using Backend.Utility.Management;

namespace Backend.Object.UI.Controller.Toggle
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Toggle/ElapsedTimeDisplayToggle.cs
{
    public class ElapsedTimeDisplayToggle : UIToggleBase
    {
        protected override void Awake()
        {
            Console.LogProgress();

            base.Awake();

            IsOn = DataManager.UserData.Default.IsDisplayAllowed[2];

            SetHoverSound(0);
            SetClickSound(1);
        }

        protected override void ValueChanged(bool value)
        {
            Console.LogProgress();

            base.ValueChanged(value);

            DataManager.UserData.Default.IsDisplayAllowed[2] = value;
            DataManager.OnSaveUserData();
        }
    }
}
