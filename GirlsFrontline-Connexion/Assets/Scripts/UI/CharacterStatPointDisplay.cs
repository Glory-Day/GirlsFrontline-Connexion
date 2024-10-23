using GloryDay.Debug.Log;
using TMPro;
using UnityEngine;

namespace UI
{
    public class CharacterStatPointDisplay : MonoBehaviour
    {
        #region COMPONENT FIELD API

        private TMP_Text _text;

        #endregion

        private void Awake()
        {
            LogManager.LogProgress();

            var index = transform.childCount - 1;
            _text = transform.GetChild(index).GetComponent<TMP_Text>();
        }

        public void SetText(string text)
        {
            _text.text = text;
        }
    }
}