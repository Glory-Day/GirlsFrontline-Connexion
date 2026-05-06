using GloryDay.Debug;
using TMPro;
using UnityEngine;

namespace Core.UI
{
    public class ChapterInformationDisplay : MonoBehaviour
    {
        #region COMPONENT FIELD API

        private TMP_Text _text;

        #endregion

        private void Awake()
        {
            Console.LogProgress();
            
            _text = transform.GetChild(1).GetChild(1).GetComponent<TMP_Text>();
        }

        public void SetText(string text)
        {
            _text.text = text;
        }
    }
}