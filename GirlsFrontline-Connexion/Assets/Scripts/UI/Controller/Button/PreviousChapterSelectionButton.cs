using System;
using GloryDay.Debug.Log;
using GloryDay.UI.Controller.Button;

namespace UI.Controller.Button
{
    public class PreviousChapterSelectionButton : UIButtonBase
    {
        // Awake is called when the script instance is being loaded.
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();
            
            SetHoverSound(0);
            SetClickSound(6);
            
            var component = GetComponentInParent<ChapterSelectionScreen>();
            IsPossibleCallback = component.IsPreviousChapterSelectionPossible;
            PlayAnimationCallback = component.SelectPreviousChapter;
            Button.interactable = false;
        }

        #region ANIMATION EVENT API

        public void SetButtonInteractable()
        {
            LogManager.LogMessage("<b>Animation Event</b> is called");

            if (IsPossibleCallback != null)
            {
                Button.interactable = IsPossibleCallback.Invoke();
            }
        }

        #endregion

        #region BUTTON EVENT API

        protected override void Click()
        {
            LogManager.LogMessage("<b>Preview Button</b> is clicked");

            base.Click();
            
            PlayAnimationCallback?.Invoke();
        }

        #endregion
        
        #region CALLBACK EVENT API

        private event Func<bool> IsPossibleCallback;
        
        private event Action PlayAnimationCallback;

        #endregion
    }
}
