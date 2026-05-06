using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GloryDay.Debug
{
    public class CommandLineButton : MonoBehaviour, IPointerEnterHandler
    {
        #region COMPONENT FIELD API

        private Button _button;

        private TMP_Text _text;

        #endregion

        private AudioClip _hoverSound;
        private AudioClip _clickSound;

        private Action<string> _onInput;
        
        private void Awake()
        {
            Console.LogProgress();
            
            _button = GetComponent<Button>();
            _button.onClick.AddListener(Click);

            _text = GetComponentInChildren<TMP_Text>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="callback"></param>
        public void AddListener(Action<string> callback)
        {
            _onInput = callback;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            throw new NotImplementedException();
        }

        private void Click()
        {
            _onInput.Invoke(Text);
        }

        public Button.ButtonClickedEvent OnClicked => _button.onClick;

        public string Text { get => _text.text; set => _text.text = value; }
    }
}
