using GloryDay.Log;
using UI.Utility.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using Utility.Manager;

namespace UI
{
    public class FailedResultScreen : StageResultScreen
    {
        private UIControls.FailedResultActions _actions;
        
        private ChapterRestartDialogScreen _dialogScreen;
        
        private AudioClip _displayTextSound;

        protected override void Awake()
        {
            LogManager.LogProgress();

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
            LogManager.LogProgress();
            
            _actions.OpenDialogScreen.performed += OpenChapterRestartDialogScreen;
        }

        private void OnDisable()
        {
            LogManager.LogProgress();
            
            _actions.Disable();
            _actions.OpenDialogScreen.performed -= OpenChapterRestartDialogScreen;
        }

        public override void Play()
        {
            LogManager.LogProgress();
            
            base.Play();
            
            _actions.Enable();
        }
        
        private void OpenChapterRestartDialogScreen(InputAction.CallbackContext context)
        {
            LogManager.LogProgress();
            
            OpenChapterRestartDialogScreen();
        }

        private void OpenChapterRestartDialogScreen()
        {
            LogManager.LogProgress();
            
            _dialogScreen.Open();
        }

        public void PlayTextEffectSound()
        {
            LogManager.LogProgress();
            
            SoundManager.OnPlayEffectAudioSource(_displayTextSound);
        }
    }
}