using GloryDay.Debug.Log;
using UnityEngine;

namespace UI
{
    public class ChapterStateDisplay : MonoBehaviour
    {
        #region COMPONENT FIELD API

        private GameObject _playStateImageObject;
        private GameObject _pauseStateImageObject;

        #endregion

        private void Awake()
        {
            LogManager.LogProgress();

            _playStateImageObject = transform.GetChild(0).gameObject;
            _pauseStateImageObject = transform.GetChild(1).gameObject;
            
            _pauseStateImageObject.SetActive(false);
        }

        public void DisableState()
        {
            LogManager.LogProgress();
            
            _playStateImageObject.SetActive(true);
            _pauseStateImageObject.SetActive(false);
        }

        public void EnableState()
        {
            LogManager.LogProgress();
            
            _playStateImageObject.SetActive(false);
            _pauseStateImageObject.SetActive(true);
        }
    }
}