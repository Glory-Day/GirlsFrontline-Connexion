using System;
using UnityEngine;
using UnityEngine.UI;
using GloryDay.Animations;
using GloryDay.Log;
using GloryDay.UI;
using Utility.Manager;
using Utility.Extension;

namespace UI
{
    public class ChapterSelectionScreen : ScreenBase
    {
        #region SERIALIZABLE STRUCTURE API

        [Serializable]
        public struct Chapter
        {
            public Button     button;
            public GameObject block;
            public GameObject decorators;
            public GameObject title;
        }

        #endregion
        
        #region SERIALIZABLE FIELD API
        
        [Header("# Chapter Components")]
        [SerializeField]
        [NamedArray("Chapter", 1)]
        private Chapter[] chapters;
        
        #endregion

        private Animation _animation;
        private AnimationNameList _animationNames;
        
        private int _index;

        private OptionPopUpScreen _optionPopUpScreen;
        
        private ResultRankDisplay _resultRankDisplay;
        
        // Awake is called when an enabled script instance is being loaded.
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();
            
            _animation = GetComponent<Animation>();
            _animationNames = new AnimationNameList(_animation);

            _optionPopUpScreen = FindObjectOfType<OptionPopUpScreen>();
            
            _resultRankDisplay = GetComponentInChildren<ResultRankDisplay>();
            
            _index = 0;
            var length = chapters.Length;
            for (var i = 0; i < length; i++)
            {
                var isChapterBlock = DataManager.UserData.Chapter[i].IsLocked;
                chapters[i].button.interactable = false;
                chapters[i].block.SetActive(isChapterBlock);
                chapters[i].title.SetActive(!isChapterBlock);
                chapters[i].decorators.SetActive(!isChapterBlock);
            }
            
            chapters[0].button.interactable = true;
        }

        private void Start()
        {
            LogManager.LogProgress();
            
            _optionPopUpScreen.DisplayToggles[0].OnValueChanged.AddListener(ToggleResultRankDisplay);
            
            _resultRankDisplay.gameObject.SetActive(_optionPopUpScreen.DisplayToggles[0].IsOn);
            
            PlayResultRank();
        }

        private void OnDestroy()
        {
            LogManager.LogProgress();
            
            _optionPopUpScreen.DisplayToggles[0].OnValueChanged.RemoveListener(ToggleResultRankDisplay);
        }

        public void SetChapterButtonInteractable()
        {
            if (chapters[_index].block.activeSelf)
            {
                return;
            }
            
            chapters[_index].button.interactable = true;
        }
        
        public bool IsNextChapterSelectionPossible() => _index != chapters.Length - 1;
        
        public bool IsPreviousChapterSelectionPossible() => 0 != _index;
        
        public void SelectNextChapter()
        {
            _resultRankDisplay.Rewind();
            
            chapters[_index].button.interactable = false;
            _animation.clip = _animation.GetClip(_animationNames[_index]);
            _index++;
            _animation.Play();
        }
        
        public void SelectPreviousChapter()
        {
            _resultRankDisplay.Rewind();
            
            chapters[_index].button.interactable = false;
            _index--;
            _animation.clip = _animation.GetClip(_animationNames[_index + 4]);
            _animation.Play();
        }

        public void PlayResultRank()
        {
            LogManager.LogProgress();
            
            var score = DataManager.UserData.Chapter[_index].Score;
            if (score < 0)
            {
                return;
            }
            
            _resultRankDisplay.SetRank(score);
            _resultRankDisplay.Play();
        }

        private void ToggleResultRankDisplay(bool value)
        {
            LogManager.LogProgress();
            
            _resultRankDisplay.gameObject.SetActive(value);
        }
    }
}
