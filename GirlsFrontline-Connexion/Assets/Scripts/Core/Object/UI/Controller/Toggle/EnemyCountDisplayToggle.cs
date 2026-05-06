<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Toggle/EnemyCountDisplayToggle.cs
﻿using GloryDay.Debug;
using Core.Utility.Manager;

namespace Core.UI.Controller.Toggle
========
﻿using GloryDay.Debug.Log;
using Backend.Utility.Management;

namespace Backend.Object.UI.Controller.Toggle
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Toggle/EnemyCountDisplayToggle.cs
{
    public class EnemyCountDisplayToggle : UIToggleBase
    {
        protected override void Awake()
        {
            Console.LogProgress();

            base.Awake();

            IsOn = DataManager.UserData.Default.IsDisplayAllowed[1];

            SetHoverSound(0);
            SetClickSound(1);
        }

        protected override void ValueChanged(bool value)
        {
            Console.LogProgress();

            base.ValueChanged(value);

            DataManager.UserData.Default.IsDisplayAllowed[1] = value;
            DataManager.OnSaveUserData();
        }
    }
}
