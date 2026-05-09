using GloryDay.Debug;
using UnityEngine;

namespace Core.UI.Controller.Button
{
    public class DisableChapterQuitDialogButton : ButtonBase
    {
        private GameObject _dialogObject;

        private PauseScreen _pauseScreen;
        private ChapterStateDisplay _chapterStateDisplay;

        public override void Initialize()
        {
            Console.LogProgress();

            base.Initialize();

            _dialogObject = transform.parent.gameObject;

            _pauseScreen = FindObjectOfType<PauseScreen>();
            _chapterStateDisplay = FindObjectOfType<ChapterStateDisplay>();
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
