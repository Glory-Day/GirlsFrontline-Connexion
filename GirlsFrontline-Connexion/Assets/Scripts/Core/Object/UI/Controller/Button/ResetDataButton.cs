using GloryDay.Debug;
using UnityEngine;
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/ResetDataButton.cs
using Core.Utility.Manager;

namespace Core.UI.Controller.Button
========
using Backend.Utility.Management;

namespace Backend.Object.UI.Controller.Button
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/ResetDataButton.cs
{
    public class ResetDataButton : UIButtonBase
    {
        private OptionPopUpScreen _optionScreen;

        private GameObject _resetDataScreen;

        // Awake is called when the script instance is being loaded.
        protected override void Awake()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/ResetDataButton.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/ResetDataButton.cs
            base.Awake();

            var parent = transform.parent;
            _resetDataScreen = parent.gameObject;
            _optionScreen = GetComponentInParent<OptionPopUpScreen>();

            SetHoverSound(0);
            SetClickSound(1);
        }

        protected override void Click()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/ResetDataButton.cs
            Console.LogMessage("<b>Reset Data</b> is clicked");
            
========
            LogManager.LogMessage("<b>Reset Data</b> is clicked");

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/ResetDataButton.cs
            base.Click();

            Reboot();

            _resetDataScreen.SetActive(false);
            _optionScreen.Toggle();
        }

        /// <summary>
        /// Reboot all assets and data, objects to initialize the application.
        /// </summary>
        private void Reboot()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/ResetDataButton.cs
            Console.LogProgress();
            Console.LogMessage("<b>All Assets, Data and Objects</b> are reloading...");
            
            // Reset user data to initial values and load game start scene.
            DataManager.OnResetUserData();
            SceneManager.OnLoadSceneByIndex(1);
            
            Console.LogSuccess("<b>All Data, Assets and Objects</b> are reloaded done");
========
            LogManager.LogProgress();
            LogManager.LogMessage("<b>All Assets, Data and Objects</b> are reloading...");

            // Reset user data to initial values and load game start scene.
            DataManager.OnResetUserData();
            SceneManager.OnLoadSceneByIndex(1);

            LogManager.LogSuccess("<b>All Data, Assets and Objects</b> are reloaded done");
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/ResetDataButton.cs
        }
    }
}
