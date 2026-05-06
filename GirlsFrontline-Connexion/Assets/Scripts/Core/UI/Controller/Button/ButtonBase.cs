using GloryDay.Debug;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GloryDay.UI.Controller.Button
{
    public abstract class ButtonBase : MonoBehaviour, IPointerEnterHandler
    {
        #region COMPONENT FIELD API

        protected UnityEngine.UI.Button Button;

        #endregion

        protected AudioClip HoverSound;
        protected AudioClip ClickSound;
        
        protected virtual void Awake()
        {
            Console.LogProgress();
            
            Button = GetComponent<UnityEngine.UI.Button>();
            Button.onClick.AddListener(Click);
        }
        
        /// <summary>
        /// Invokes when a user clicks the button and releases it
        /// </summary>
        protected abstract void Click();

        public abstract void OnPointerEnter(PointerEventData eventData);
        
        public UnityEngine.UI.Button.ButtonClickedEvent OnClick => Button.onClick;
    }
}
