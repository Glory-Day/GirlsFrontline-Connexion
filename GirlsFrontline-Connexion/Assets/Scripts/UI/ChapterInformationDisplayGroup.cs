using GloryDay.Log;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ChapterInformationDisplayGroup : MonoBehaviour
    {
        #region COMPONENT FIELD API

        private VerticalLayoutGroup _verticalLayoutGroup;

        #endregion
        
        private readonly ChapterInformationDisplay[] _chapterInformationDisplays = new ChapterInformationDisplay[3];
        private readonly GameObject[] _displayObjects = new GameObject[3];

        private OptionPopUpScreen _optionPopUpScreen;

        private int _count;
        private readonly float[] _heights = { -240f, -240f, -160f };
        
        private void Awake()
        {
            LogManager.LogProgress();
            
            _verticalLayoutGroup = GetComponent<VerticalLayoutGroup>();
            
            var child = transform.GetChild(0);
            _displayObjects[0] = child.gameObject;
            _chapterInformationDisplays[0] = child.GetComponent<ChapterInformationDisplay>();
            
            child = transform.GetChild(1);
            _displayObjects[1] = child.gameObject;
            _chapterInformationDisplays[1] = child.GetComponent<ChapterInformationDisplay>();
            
            child = transform.GetChild(2);
            _displayObjects[2] = child.gameObject;
            _chapterInformationDisplays[2] = child.GetComponent<ChapterInformationDisplay>();

            _optionPopUpScreen = FindObjectOfType<OptionPopUpScreen>();
            _optionPopUpScreen.DisplayToggles[1].OnValueChanged.AddListener(ToggleEnemyCountDisplay);
            _optionPopUpScreen.DisplayToggles[2].OnValueChanged.AddListener(ToggleElapsedTimeDisplay);
            _optionPopUpScreen.DisplayToggles[3].OnValueChanged.AddListener(ToggleScoreDisplay);
            
            for (var i = 0; i < 3; i++)
            {
                if (_optionPopUpScreen.DisplayToggles[i + 1].IsOn)
                {
                    _displayObjects[i].SetActive(true);
                    _count++;
                }
                else
                {
                    _displayObjects[i].SetActive(false);
                }
            }

            _verticalLayoutGroup.spacing = _heights[_count - 1];
        }

        private void OnDestroy()
        {
            LogManager.LogProgress();
            
            _optionPopUpScreen.DisplayToggles[1].OnValueChanged.RemoveListener(ToggleEnemyCountDisplay);
            _optionPopUpScreen.DisplayToggles[2].OnValueChanged.RemoveListener(ToggleElapsedTimeDisplay);
            _optionPopUpScreen.DisplayToggles[3].OnValueChanged.RemoveListener(ToggleScoreDisplay);
        }

        private void ToggleEnemyCountDisplay(bool value)
        {
            LogManager.LogProgress();
            
            if (value)
            {
                _displayObjects[0].SetActive(true);
                _count++;
            }
            else
            {
                _displayObjects[0].SetActive(false);
                _count--;
            }
            
            _verticalLayoutGroup.spacing = _heights[_count - 1];
        }

        private void ToggleElapsedTimeDisplay(bool value)
        {
            if (value)
            {
                _displayObjects[1].SetActive(true);
                _count++;
            }
            else
            {
                _displayObjects[1].SetActive(false);
                _count--;
            }
            
            _verticalLayoutGroup.spacing = _heights[_count - 1];
        }
        
        private void ToggleScoreDisplay(bool value)
        {
            if (value)
            {
                _displayObjects[2].SetActive(true);
                _count++;
            }
            else
            {
                _displayObjects[2].SetActive(false);
                _count--;
            }
            
            _verticalLayoutGroup.spacing = _heights[_count - 1];
        }

        public ChapterInformationDisplay this[int index] => _chapterInformationDisplays[index];
    }
}