using GloryDay.Debug;
using Core.UI.Utility.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using Core.Utility.Manager;

namespace Core.UI
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
            Console.LogProgress();
            
            _actions.OpenDialogScreen.performed += OpenChapterRestartDialogScreen;
        }

        private void OnDisable()
        {
            Console.LogProgress();
            
            _actions.Disable();
            _actions.OpenDialogScreen.performed -= OpenChapterRestartDialogScreen;
        }

        public override void Play()
        {
            Console.LogProgress();
            
            base.Play();
            
            _actions.Enable();
        }
        
        private void OpenChapterRestartDialogScreen(InputAction.CallbackContext context)
        {
            Console.LogProgress();
            
            OpenChapterRestartDialogScreen();
        }

        private void OpenChapterRestartDialogScreen()
        {
            Console.LogProgress();
            
            _dialogScreen.Open();
        }

        public void PlayTextEffectSound()
        {
            Console.LogProgress();
            
            SoundManager.OnPlayEffectAudioSource(_displayTextSound);
        }
    }
}