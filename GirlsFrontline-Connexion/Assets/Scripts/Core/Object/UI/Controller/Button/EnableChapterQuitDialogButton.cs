<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/EnableChapterQuitDialogButton.cs
﻿using GloryDay.Debug;
using Core.UI.Utility.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using Core.Utility.Extension;

namespace Core.UI.Controller.Button
========
﻿using GloryDay.Debug.Log;
using Backend.Utility.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using Backend.Utility.Attribute;

namespace Backend.Object.UI.Controller.Button
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/EnableChapterQuitDialogButton.cs
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
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/EnableChapterQuitDialogButton.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/EnableChapterQuitDialogButton.cs
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
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/EnableChapterQuitDialogButton.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/EnableChapterQuitDialogButton.cs
            _actions.Enable();
        }

        private void Toggle(InputAction.CallbackContext context)
        {
            Console.LogProgress();

            Click();
        }

        #region BUTTON EVENT API

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

        #endregion
    }
}
