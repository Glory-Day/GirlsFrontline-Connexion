using GloryDay.Log;
using UnityEngine;

namespace UI.Controller.Button
{
    public class ChapterStartButton : UIButtonBase
    {
        #region SERIALIZABLE FIELD API

        [SerializeField]
        private int chapterIndex;

        #endregion

        #region COMPONENT FIELD API

        private ITransitionable _transitionScreen;

        #endregion
        
        // Awake is called when the script instance is being loaded.
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();

            _transitionScreen = FindObjectOfType<TransitionScreen>();
        }

        protected override void Click()
        {
            LogManager.LogMessage($"<b>Chapter {chapterIndex:D2} Button</b> is clicked");
            LogManager.LogMessage($"Start <b>Chapter {chapterIndex:D2}</b>");
            
            _transitionScreen.Transition(chapterIndex, TransitionType.Gate);
        }
    }
}