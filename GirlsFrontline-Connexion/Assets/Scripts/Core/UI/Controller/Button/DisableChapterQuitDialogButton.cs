using GloryDay.Debug;
using UnityEngine;

namespace Core.UI.Controller.Button
{
    public class DisableChapterQuitDialogButton : UIButtonBase
    {
        private GameObject _dialogObject;

        private PauseScreen _pauseScreen;
        private ChapterStateDisplay _chapterStateDisplay;
        
        protected override void Awake()
        {
            Console.LogProgress();
            
            base.Awake();
            
            _dialogObject = transform.parent.gameObject;
            
            _pauseScreen = FindObjectOfType<PauseScreen>();
            _chapterStateDisplay = FindObjectOfType<ChapterStateDisplay>();
            
            SetHoverSound(0);
            SetClickSound(1);
        }
        
        protected override void Click()
        {
            Console.LogMessage("<b>Disable Dialog Button</b> is clicked");
            
            base.Click();
            
            _pauseScreen.TurnOff();
            _chapterStateDisplay.DisableState();
            
            _dialogObject.SetActive(false);
        }
    }
}