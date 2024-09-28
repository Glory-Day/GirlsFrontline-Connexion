using GloryDay.Log;
using UI.Utility.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using Utility.Extension;

namespace UI.Controller.Button
{
    public class EnableChapterQuitDialogButton : UIButtonBase
    {
        #region SERIALIZABLE FIELD API

        [Label("Target Dialog")]
        [SerializeField] private GameObject dialogObject;

        #endregion
        
        private PauseScreen _pauseScreen;
        private ChapterStateDisplay _chapterStateDisplay;
        
        private MainInterfaceControls.QuitButtonActions _actions;
        
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();
            
            _actions = new MainInterfaceControls().QuitButton;
            _actions.Toggle.performed += Toggle;
            
            _pauseScreen = FindObjectOfType<PauseScreen>();
            _chapterStateDisplay = FindObjectOfType<ChapterStateDisplay>();
            
            SetHoverSound(0);
            SetClickSound(1);
        }
        
        private void Start()
        {
            LogManager.LogProgress();
            
            _actions.Enable();
        }

        private void Toggle(InputAction.CallbackContext context)
        {
            LogManager.LogProgress();

            Click();
        }

        #region BUTTON EVENT API

        protected override void Click()
        {
            LogManager.LogProgress();

            base.Click();
            
            if (dialogObject.activeSelf)
            {
                _pauseScreen.TurnOff();
                _chapterStateDisplay.DisableState();
                
                dialogObject.SetActive(false);
            }
            else
            {
                _pauseScreen.TurnOn();
                _chapterStateDisplay.EnableState();
                
                dialogObject.SetActive(true);
            }
        }

        #endregion
    }
}