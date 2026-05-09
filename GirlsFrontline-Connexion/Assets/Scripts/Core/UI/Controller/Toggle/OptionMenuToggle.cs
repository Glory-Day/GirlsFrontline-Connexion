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