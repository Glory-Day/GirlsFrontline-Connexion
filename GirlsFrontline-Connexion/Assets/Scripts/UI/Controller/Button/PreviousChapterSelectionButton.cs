using System;
using GloryDay.Log;
using GloryDay.UI.Controller.Button;
using UI.View;

namespace UI.Controller.Button
{
    public class PreviousChapterSelectionButton : ButtonBase
    {
        // Start is called before the first frame update
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();
            
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

            PlayAnimationCallback?.Invoke();
        }

        #endregion
        
        #region CALLBACK EVENT API

        private event Func<bool> IsPossibleCallback;
        
        private event Action PlayAnimationCallback;

        #endregion
    }
}
