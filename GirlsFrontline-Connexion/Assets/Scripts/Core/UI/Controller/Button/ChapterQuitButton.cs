using GloryDay.Debug;
using Core.Utility.Management;
using UnityEngine;

namespace Core.UI.Controller.Button
{
    public class ChapterQuitButton : ButtonBase
    {
        private TransitionScreen _transitionScreen;

        public override void Initialize()
        {
            Console.LogProgress();

            base.Initialize();

            _transitionScreen = FindObjectOfType<TransitionScreen>();
        }

        protected override void Click()
        {
            Console.LogMessage("<b>Disable Dialog Button</b> is clicked");

            base.Click();

            GameManager.OnApplicationPlay();

            _transitionScreen.Transition(2, TransitionType.Gate);
        }
    }
}
