using GloryDay.Debug;
using UnityEngine;

<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/ChapterStartButton.cs
namespace Core.UI.Controller.Button
========
namespace Backend.Object.UI.Controller.Button
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/ChapterStartButton.cs
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
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/ChapterStartButton.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/ChapterStartButton.cs
            base.Awake();

            _transitionScreen = FindObjectOfType<TransitionScreen>();
        }

        protected override void Click()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/ChapterStartButton.cs
            Console.LogMessage($"<b>Chapter {chapterIndex:D2} Button</b> is clicked");
            Console.LogMessage($"Start <b>Chapter {chapterIndex:D2}</b>");
            
========
            LogManager.LogMessage($"<b>Chapter {chapterIndex:D2} Button</b> is clicked");
            LogManager.LogMessage($"Start <b>Chapter {chapterIndex:D2}</b>");

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/ChapterStartButton.cs
            _transitionScreen.Transition(chapterIndex, TransitionType.Gate);
        }
    }
}
