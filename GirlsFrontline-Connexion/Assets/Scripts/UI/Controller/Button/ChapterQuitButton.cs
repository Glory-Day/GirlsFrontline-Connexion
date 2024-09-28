using GloryDay.Log;
using Utility.Manager;

namespace UI.Controller.Button
{
    public class ChapterQuitButton : UIButtonBase
    {
        private TransitionScreen _transitionScreen;
        
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();
            
            _transitionScreen = FindObjectOfType<TransitionScreen>();
            
            SetHoverSound(0);
            SetClickSound(1);
        }
        
        protected override void Click()
        {
            LogManager.LogMessage("<b>Disable Dialog Button</b> is clicked");
            
            base.Click();
            
            GameManager.OnApplicationPlay();
            
            _transitionScreen.Transition(2, TransitionType.Gate);
        }
    }
}