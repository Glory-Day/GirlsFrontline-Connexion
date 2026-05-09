using GloryDay.Debug;
using UnityEngine;

namespace Core.UI.Controller.Toggle
{
    public class OptionMenuToggle : ToggleBase
    {
        #region SERIALIZABLE FIELD API

        [SerializeField]
        private GameObject screen;

        #endregion

        public override void Initialize()
        {
            Console.LogProgress();

            base.Initialize();

            screen.SetActive(IsOn);
        }

        protected override void ValueChanged(bool value)
        {
            base.ValueChanged(value);

            screen.SetActive(IsOn);
        }
    }
}