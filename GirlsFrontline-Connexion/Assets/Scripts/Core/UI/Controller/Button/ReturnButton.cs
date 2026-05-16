using GloryDay.Debug;

namespace Core.UI.Controller.Button
{
    public class ReturnButton : ButtonBase
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
            Console.LogMessage("<b>Return Button</b> is clicked");

            base.Click();

            Button.interactable = false;

            _transitionScreen.Transition(1, TransitionType.Slide);
        }
    }
}
