using GloryDay.Debug;
using Core.UI.Utility.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using Core.Utility.Attribute;

namespace Core.UI.Controller.Button
{
    public class EnableChapterQuitDialogButton : ButtonBase
    {
        #region SERIALIZABLE FIELD API

        [Alias("Target Dialog")]
        [SerializeField] private GameObject dialogObject;

        #endregion

        private PauseScreen _pauseScreen;
        private ChapterStateDisplay _chapterStateDisplay;

        private MainInterfaceControls.QuitButtonActions _actions;

        public override void Initialize()
        {
            Console.LogProgress();

            base.Initialize();

            _actions = new MainInterfaceControls().QuitButton;
            _actions.Toggle.performed += Toggle;

            _pauseScreen = FindObjectOfType<PauseScreen>();
            _chapterStateDisplay = FindObjectOfType<ChapterStateDisplay>();
        }

        private void Start()
        {
            Console.LogProgress();

            _actions.Enable();
        }

        private void Toggle(InputAction.CallbackContext context)
        {
            Console.LogProgress();

            Click();
        }

        protected override void Click()
        {
            Console.LogProgress();

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
    }
}
