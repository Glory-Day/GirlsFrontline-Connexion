using GloryDay.Debug;
using GloryDay.UI.Controller.Button;
using UnityEngine;

<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/DisableDataResetDialogButton.cs
namespace Core.UI.Controller.Button
========
namespace Backend.Object.UI.Controller.Button
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/DisableDataResetDialogButton.cs
{
    public class DisableDataResetDialogButton : UIButtonBase
    {
        private GameObject _dialogObject;

        // Awake is called when the script instance is being loaded.
        protected override void Awake()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/DisableDataResetDialogButton.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/DisableDataResetDialogButton.cs
            base.Awake();

            _dialogObject = transform.parent.gameObject;

            SetHoverSound(0);
            SetClickSound(1);
        }

        protected override void Click()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/DisableDataResetDialogButton.cs
            Console.LogMessage("<b>Disable Dialog Button</b> is clicked");
            
========
            LogManager.LogMessage("<b>Disable Dialog Button</b> is clicked");

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/DisableDataResetDialogButton.cs
            base.Click();

            _dialogObject.SetActive(false);
        }
    }
}
