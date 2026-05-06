using GloryDay.Debug;
using UnityEngine;

<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/DisableChapterQuitDialogButton.cs
namespace Core.UI.Controller.Button
========
namespace Backend.Object.UI.Controller.Button
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/DisableChapterQuitDialogButton.cs
{
    public class DisableChapterQuitDialogButton : UIButtonBase
    {
        private GameObject _dialogObject;

        private PauseScreen _pauseScreen;
        private ChapterStateDisplay _chapterStateDisplay;

        protected override void Awake()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/DisableChapterQuitDialogButton.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/DisableChapterQuitDialogButton.cs
            base.Awake();

            _dialogObject = transform.parent.gameObject;

            _pauseScreen = FindObjectOfType<PauseScreen>();
            _chapterStateDisplay = FindObjectOfType<ChapterStateDisplay>();

            SetHoverSound(0);
            SetClickSound(1);
        }

        protected override void Click()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/DisableChapterQuitDialogButton.cs
            Console.LogMessage("<b>Disable Dialog Button</b> is clicked");
            
========
            LogManager.LogMessage("<b>Disable Dialog Button</b> is clicked");

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/DisableChapterQuitDialogButton.cs
            base.Click();

            _pauseScreen.TurnOff();
            _chapterStateDisplay.DisableState();

            _dialogObject.SetActive(false);
        }
    }
}
