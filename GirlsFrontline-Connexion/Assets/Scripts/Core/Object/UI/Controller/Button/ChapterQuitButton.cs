<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/ChapterQuitButton.cs
﻿using GloryDay.Debug;
using Core.Utility.Manager;

namespace Core.UI.Controller.Button
========
﻿using GloryDay.Debug.Log;
using Backend.Utility.Management;

namespace Backend.Object.UI.Controller.Button
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/ChapterQuitButton.cs
{
    public class ChapterQuitButton : UIButtonBase
    {
        private TransitionScreen _transitionScreen;

        protected override void Awake()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/ChapterQuitButton.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/ChapterQuitButton.cs
            base.Awake();

            _transitionScreen = FindObjectOfType<TransitionScreen>();

            SetHoverSound(0);
            SetClickSound(1);
        }

        protected override void Click()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/ChapterQuitButton.cs
            Console.LogMessage("<b>Disable Dialog Button</b> is clicked");
            
========
            LogManager.LogMessage("<b>Disable Dialog Button</b> is clicked");

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/ChapterQuitButton.cs
            base.Click();

            ApplicationManager.Play();

            _transitionScreen.Transition(2, TransitionType.Gate);
        }
    }
}
