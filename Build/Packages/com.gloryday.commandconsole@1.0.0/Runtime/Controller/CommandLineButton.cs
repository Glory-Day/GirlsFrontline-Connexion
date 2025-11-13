using System;
using GloryDay.Debug.Log;
using GloryDay.UI.Controller.Button;
using UnityEngine.EventSystems;

namespace Library.UI.CommandConsole.Controller
{
    public class CommandLineButton : TextButton
    {
        private Action<string> _onInput;
        
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="callback"></param>
        public void AddListener(Action<string> callback)
        {
            _onInput = callback;
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            throw new NotImplementedException();
        }

        #region BUTTON EVENT API

        protected override void Click()
        {
            _onInput.Invoke(Text);
        }

        #endregion
    }
}
