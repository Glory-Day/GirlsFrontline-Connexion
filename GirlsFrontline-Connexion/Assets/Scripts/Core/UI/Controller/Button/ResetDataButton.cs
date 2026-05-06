using GloryDay.Debug;
using UnityEngine;
using Core.Utility.Manager;

namespace Core.UI.Controller.Button
{
    public class ResetDataButton : UIButtonBase
    {
        private OptionPopUpScreen _optionScreen;
        
        private GameObject _resetDataScreen;
        
        // Awake is called when the script instance is being loaded.
        protected override void Awake()
        {
            Console.LogProgress();
            
            base.Awake();

            var parent = transform.parent;
            _resetDataScreen = parent.gameObject;
            _optionScreen = GetComponentInParent<OptionPopUpScreen>();
            
            SetHoverSound(0);
            SetClickSound(1);
        }

        protected override void Click()
        {
            Console.LogMessage("<b>Reset Data</b> is clicked");
            
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
            Console.LogProgress();
            Console.LogMessage("<b>All Assets, Data and Objects</b> are reloading...");
            
            // Reset user data to initial values and load game start scene.
            DataManager.OnResetUserData();
            SceneManager.OnLoadSceneByIndex(1);
            
            Console.LogSuccess("<b>All Data, Assets and Objects</b> are reloaded done");
        }
    }
}