using System;
using GloryDay.Debug;
using GloryDay.UI.Controller.Button;

<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/PreviousChapterSelectionButton.cs
using Console = GloryDay.Debug.Console;

namespace Core.UI.Controller.Button
========
namespace Backend.Object.UI.Controller.Button
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/PreviousChapterSelectionButton.cs
{
    public class PreviousChapterSelectionButton : UIButtonBase
    {
        // Awake is called when the script instance is being loaded.
        protected override void Awake()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/PreviousChapterSelectionButton.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/PreviousChapterSelectionButton.cs
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
            Console.LogMessage("<b>Animation Event</b> is called");

            if (IsPossibleCallback != null)
            {
                Button.interactable = IsPossibleCallback.Invoke();
            }
        }

        #endregion

        #region BUTTON EVENT API

        protected override void Click()
        {
            Console.LogMessage("<b>Preview Button</b> is clicked");

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
