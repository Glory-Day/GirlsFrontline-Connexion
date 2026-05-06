using GloryDay.Debug;
using GloryDay.UI;
using UnityEngine;
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/PauseScreen.cs
using Core.Utility.Manager;

namespace Core.UI
========
using Backend.Utility.Management;

namespace Backend.Object.UI
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/PauseScreen.cs
{
    public class PauseScreen : ScreenBase
    {
        private GameObject _screenObject;

        protected override void Awake()
        {
            Console.LogProgress();

            _screenObject = transform.GetChild(0).gameObject;
        }

        public override void TurnOn()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/PauseScreen.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/PauseScreen.cs
            _screenObject.SetActive(true);

            ApplicationManager.Pause();
        }

        public override void TurnOff()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/PauseScreen.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/PauseScreen.cs
            _screenObject.SetActive(false);

            ApplicationManager.Play();
        }
    }
}
