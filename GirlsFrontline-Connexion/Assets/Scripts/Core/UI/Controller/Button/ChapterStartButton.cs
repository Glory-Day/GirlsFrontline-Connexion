using GloryDay.Debug;
using UnityEngine;

namespace Core.UI.Controller.Button
{
    public class ChapterStartButton : ButtonBase
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
            Console.LogProgress();

            base.Awake();

            _transitionScreen = FindObjectOfType<TransitionScreen>();
        }

        protected override void Click()
        {
            Console.LogMessage($"<b>Chapter {chapterIndex:D2} Button</b> is clicked");
            Console.LogMessage($"Start <b>Chapter {chapterIndex:D2}</b>");

            _transitionScreen.Transition(chapterIndex, TransitionType.Gate);
        }
    }
}
