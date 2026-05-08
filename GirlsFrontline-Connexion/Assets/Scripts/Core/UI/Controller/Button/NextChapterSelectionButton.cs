using System;
using GloryDay.Debug;

using Console = GloryDay.Debug.Console;

namespace Core.UI.Controller.Button
{
    public class NextChapterSelectionButton : ButtonBase
    {
        // Awake is called when the script instance is being loaded.
        protected override void Awake()
        {
            Console.LogProgress();

            base.Awake();

            var component = GetComponentInParent<ChapterSelectionScreen>();
            IsPossibleCallback = component.IsNextChapterSelectionPossible;
            PlayAnimationCallback = component.SelectNextChapter;
            Button.interactable = IsPossibleCallback.Invoke();
        }

        #region ANIMATION EVENT API

        public void SetButtonInteractable()
        {
            Console.LogMessage("<b>Animation Event</b> is called");

            if (IsPossibleCallback != null)
            {
                Button.interactable = IsPossibleCallback.Invoke();
            }
        }

        #endregion

        protected override void Click()
        {
            Console.LogMessage("<b>Next Button</b> is clicked");

            base.Click();
            PlayAnimationCallback?.Invoke();
        }

        private event Func<bool> IsPossibleCallback;

        private event Action PlayAnimationCallback;
    }
}
