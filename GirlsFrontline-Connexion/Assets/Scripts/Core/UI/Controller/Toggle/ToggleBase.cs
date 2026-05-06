using GloryDay.Debug;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GloryDay.UI.Controller.Toggle
{
    public abstract class ToggleBase : MonoBehaviour, IPointerEnterHandler
    {
        #region COMPONENT FIELD APT

        protected UnityEngine.UI.Toggle Toggle;

        #endregion

        protected AudioClip HoverSound;
        protected AudioClip ClickSound;
        
        protected virtual void Awake()
        {
            Console.LogProgress();

            Toggle = GetComponent<UnityEngine.UI.Toggle>();
            Toggle.onValueChanged.AddListener(ValueChanged);
            
            if (IsOn)
            {
                Toggle.Select();
            }
        }

        protected abstract void ValueChanged(bool value);
        
        public abstract void OnPointerEnter(PointerEventData eventData);

        public UnityEngine.UI.Toggle.ToggleEvent OnValueChanged => Toggle.onValueChanged;
        
        public bool IsOn
        {
            get => Toggle.isOn;
            set => Toggle.isOn = value;
        }
    }
}