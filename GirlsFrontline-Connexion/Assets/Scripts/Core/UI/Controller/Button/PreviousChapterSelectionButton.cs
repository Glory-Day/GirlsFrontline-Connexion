using System;
using GloryDay.Debug;

using Console = GloryDay.Debug.Console;

namespace Core.UI.Controller.Button
{
    public class PreviousChapterSelectionButton : ButtonBase
    {
        // Awake is called when the script instance is being loaded.
        protected override void Awake()
        {
            Console.LogProgress();

            base.Awake();

            var component = GetComponentInParent<ChapterSelectionScreen>();
            IsPossibleCallback = component.IsPreviousChapterSelectionPossible;
            PlayAnimationCallback = component.SelectPreviousChapter;
            Button.interactable = false;
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
            Console.LogMessage("<b>Preview Button</b> is clicked");

            base.Click();

            PlayAnimationCallback?.Invoke();
        }

        private event Func<bool> IsPossibleCallback;

        private event Action PlayAnimationCallback;
    }
}
