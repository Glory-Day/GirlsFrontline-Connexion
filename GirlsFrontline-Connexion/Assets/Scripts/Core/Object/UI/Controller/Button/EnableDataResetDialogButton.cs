using GloryDay.Debug;
using GloryDay.UI.Controller.Button;
using UnityEngine;
using UnityEngine.Serialization;
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/EnableDataResetDialogButton.cs
using Core.Utility.Manager;

namespace Core.UI.Controller.Button
========
using Backend.Utility.Management;

namespace Backend.Object.UI.Controller.Button
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/EnableDataResetDialogButton.cs
{
    public class EnableDataResetDialogButton : UIButtonBase
    {
        #region SERIALIZED FIELD API

        [SerializeField] private GameObject dialogObject;

        #endregion

        private AudioClip _openDialogSound;

        // Awake is called when the script instance is being loaded.
        protected override void Awake()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/EnableDataResetDialogButton.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/EnableDataResetDialogButton.cs
            base.Awake();

            SetHoverSound(0);
            SetClickSound(1);

            var key = DataManager.AudioData.Effect[3];
            _openDialogSound = ResourceManager.AudioClipResource.Effect[key];
        }

        protected override void Click()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Button/EnableDataResetDialogButton.cs
            Console.LogMessage("<b>Enable Dialog Button</b> is clicked");
            
========
            LogManager.LogMessage("<b>Enable Dialog Button</b> is clicked");

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Button/EnableDataResetDialogButton.cs
            base.Click();

            SoundManager.OnPlayEffectAudioSource(_openDialogSound);

            dialogObject.SetActive(true);
        }
    }
}
