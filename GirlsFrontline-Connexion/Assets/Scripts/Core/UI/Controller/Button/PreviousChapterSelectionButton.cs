using System;
using GloryDay.Debug;

using Console = GloryDay.Debug.Console;

namespace Core.UI.Controller.Button
{
    public class PreviousChapterSelectionButton : ButtonBase
    {
        public override void Initialize()
        {
            Console.LogProgress();

            base.Initialize();

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
