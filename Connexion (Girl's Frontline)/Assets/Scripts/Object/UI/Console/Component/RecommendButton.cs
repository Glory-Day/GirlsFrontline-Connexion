#region NAMESPACE API

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

#endregion

namespace Object.UI.Console.Component
{
    public class RecommendButton : MonoBehaviour
    {
        #region COMPONENT FIELD

        private TMP_Text text;

        #endregion

        private void Start()
        {
            text = GetComponentInChildren<TMP_Text>();
            text.text = CommandName;
        }

        #region BUTTON EVENT API

        public void OnClicked()
        {
            if (GetInputCommandsCallBack == null)
            {
                return;
            }
            
            var start = GetInputCommandsCallBack.Invoke().Last().Length;
            var token = CommandName.Substring(start);
            SetInputFieldTextCallBack?.Invoke(token);
        }

        #endregion
        
        #region CALLBACK API

        public event Action<string> SetInputFieldTextCallBack;
        public event Func<IEnumerable<string>> GetInputCommandsCallBack;

        #endregion

        #region PROPERTIES API

        public string CommandName { private get; set; }

        #endregion
    }
}
