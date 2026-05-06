using GloryDay.Debug;

<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/ReturnButton.cs
namespace Core.UI.Controller.Button
========
namespace Backend.Object.UI.Controller.Button
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/ReturnButton.cs
{
    public class ReturnButton : UIButtonBase
    {
        #region COMPONENT FIELD API

        private TransitionScreen _transitionScreen;

        #endregion

        // Awake is called when the script instance is being loaded.
        protected override void Awake()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/ReturnButton.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/ReturnButton.cs
            base.Awake();

            _transitionScreen = FindObjectOfType<TransitionScreen>();

            SetHoverSound(0);
            SetClickSound(1);
        }

        protected override void Click()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/ReturnButton.cs
            Console.LogMessage("<b>Return Button</b> is clicked");
            
========
            LogManager.LogMessage("<b>Return Button</b> is clicked");

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/ReturnButton.cs
            base.Click();

            Button.interactable = false;

            _transitionScreen.Transition(1, TransitionType.Slide);
        }
    }
}
