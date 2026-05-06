using GloryDay.Debug;
using GloryDay.UI.Controller.Toggle;
using UnityEngine;

namespace Core.UI.Controller.Toggle
{
    public class OptionMenuToggle : UIToggleBase
    {
        #region SERIALIZABLE FIELD API
        
        [SerializeField]
        private GameObject screen;

        #endregion

        protected override void Awake()
        {
            Console.LogProgress();
            
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