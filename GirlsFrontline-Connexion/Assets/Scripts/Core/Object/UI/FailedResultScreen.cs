<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/FailedResultScreen.cs
﻿using GloryDay.Debug;
using Core.UI.Utility.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using Core.Utility.Manager;

namespace Core.UI
========
﻿using GloryDay.Debug.Log;
using Backend.Utility.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using Backend.Utility.Management;

namespace Backend.Object.UI
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/FailedResultScreen.cs
{
    public class FailedResultScreen : StageResultScreen
    {
        private UIControls.FailedResultActions _actions;

        private ChapterRestartDialogScreen _dialogScreen;

        private AudioClip _displayTextSound;

        protected override void Awake()
        {
            Console.LogProgress();

            base.Awake();

            _actions = new UIControls().FailedResult;

            _dialogScreen = FindObjectOfType<ChapterRestartDialogScreen>();

            var key = DataManager.AudioData.Background[8];
            BackgroundSound = ResourceManager.AudioClipResource.Background[key];

            key = DataManager.AudioData.Effect[7];
            _displayTextSound = ResourceManager.AudioClipResource.Effect[key];
        }

        private void OnEnable()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/FailedResultScreen.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/FailedResultScreen.cs
            _actions.OpenDialogScreen.performed += OpenChapterRestartDialogScreen;
        }

        private void OnDisable()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/FailedResultScreen.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/FailedResultScreen.cs
            _actions.Disable();
            _actions.OpenDialogScreen.performed -= OpenChapterRestartDialogScreen;
        }

        public override void Play()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/FailedResultScreen.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/FailedResultScreen.cs
            base.Play();

            _actions.Enable();
        }

        private void OpenChapterRestartDialogScreen(InputAction.CallbackContext context)
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/FailedResultScreen.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/FailedResultScreen.cs
            OpenChapterRestartDialogScreen();
        }

        private void OpenChapterRestartDialogScreen()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/FailedResultScreen.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/FailedResultScreen.cs
            _dialogScreen.Open();
        }

        public void PlayTextEffectSound()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/FailedResultScreen.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/FailedResultScreen.cs
            SoundManager.OnPlayEffectAudioSource(_displayTextSound);
        }
    }
}
