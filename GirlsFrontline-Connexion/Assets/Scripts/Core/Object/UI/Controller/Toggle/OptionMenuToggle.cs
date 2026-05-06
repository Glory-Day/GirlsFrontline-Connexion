using GloryDay.Debug;
using GloryDay.UI.Controller.Toggle;
using UnityEngine;

<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Toggle/OptionMenuToggle.cs
namespace Core.UI.Controller.Toggle
========
namespace Backend.Object.UI.Controller.Toggle
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Toggle/OptionMenuToggle.cs
{
    public class OptionMenuToggle : UIToggleBase
    {
        #region SERIALIZABLE FIELD API

        [SerializeField]
        private GameObject screen;

        #endregion

        protected override void Awake()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/Controller/Toggle/OptionMenuToggle.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/Controller/Toggle/OptionMenuToggle.cs
            base.Awake();

            SetHoverSound(0);
            SetClickSound(1);
        }

        protected void Start()
        {
            screen.SetActive(IsOn);
        }

        protected override void ValueChanged(bool value)
        {
            base.ValueChanged(value);

            screen.SetActive(IsOn);
        }
    }
}
