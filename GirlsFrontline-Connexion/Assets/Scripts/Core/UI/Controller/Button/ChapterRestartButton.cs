using GloryDay.Debug;
using Core.Utility.Manager;

namespace Core.UI.Controller.Button
{
    public class ChapterRestartButton : UIButtonBase
    {
        private TransitionScreen _transitionScreen;
        
        protected override void Awake()
        {
            Console.LogProgress();
            
            base.Awake();
            
            _transitionScreen = FindObjectOfType<TransitionScreen>();
            
            SetHoverSound(0);
            SetClickSound(1);
        }
        
        protected override void Click()
        {
            Console.LogMessage("<b>Disable Dialog Button</b> is clicked");
            
            base.Click();
            
            GameManager.OnApplicationPlay();
            
            _transitionScreen.Transition(SceneManager.CurrentSceneIndex, TransitionType.Gate);
        }
    }
}