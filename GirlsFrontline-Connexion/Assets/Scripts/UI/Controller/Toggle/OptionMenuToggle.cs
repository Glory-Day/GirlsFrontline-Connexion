using GloryDay.UI.Controller.Toggle;
using UnityEngine;

namespace UI.Controller.Toggle
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

        protected override void ChangeValue(bool value)
        {
            screen.SetActive(IsOn);
        }
    }
}