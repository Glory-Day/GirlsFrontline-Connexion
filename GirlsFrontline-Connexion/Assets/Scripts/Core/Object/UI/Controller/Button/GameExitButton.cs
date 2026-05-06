<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/GameExitButton.cs
﻿using GloryDay.Debug;
using Core.Utility.Manager;

namespace Core.UI.Controller.Button
========
﻿using GloryDay.Debug.Log;
using Backend.Utility.Management;

namespace Backend.Object.UI.Controller.Button
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/GameExitButton.cs
{
    public class GameExitButton : UIButtonBase
    {
        // Awake is called when the script instance is being loaded.
        protected override void Awake()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/GameExitButton.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/GameExitButton.cs
            base.Awake();

            SetHoverSound(0);
            SetClickSound(1);
        }

        protected override void Click()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/GameExitButton.cs
            Console.LogMessage("<b>Exit Button</b> is clicked");
            
========
            LogManager.LogMessage("<b>Exit Button</b> is clicked");

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/GameExitButton.cs
            base.Click();

            ApplicationManager.Quit();
        }
    }
}
