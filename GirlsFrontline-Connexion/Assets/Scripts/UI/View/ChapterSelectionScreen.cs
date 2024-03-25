using System;
using UnityEngine;
using UnityEngine.UI;
using GloryDay.Animations;
using GloryDay.Log;
using GloryDay.UI.View;
using Utility.Manager;
using View;

namespace UI.View
{
    public class ChapterSelectionScreen : ScreenBase
    {
        #region SERIALIZABLE FIELD API
        
        [Header("# Chapter Components")]
        [SerializeField]
        [NamedArray("Chapter", 1)]
        private Chapter[] chapters;
        
        #endregion

        private Animation      _animation;
        private AnimationNames _animationNames;
        
        private int _index;

        // Start is called before the first frame update
        protected override void Start()
        {
            LogManager.LogProgress();
            
            _animation = GetComponent<Animation>();
            _animationNames = new AnimationNames(_animation);
            
            _index = 0;
            var length = chapters.Length;
            for (var i = 0; i < length; i++)
            {
                var isChapterBlock = DataManager.UserData.GetChapter(i).IsLocked;
                chapters[i].button.interactable = false;
                chapters[i].block.SetActive(isChapterBlock);
                chapters[i].title.SetActive(!isChapterBlock);
                chapters[i].decorators.SetActive(!isChapterBlock);
            }
            chapters[0].button.interactable = true;
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
            chapters[_index].button.interactable = false;
            _animation.clip = _animation.GetClip(_animationNames[_index]);
            _index++;
            _animation.Play();
        }
        
        public void SelectPreviousChapter()
        {
            chapters[_index].button.interactable = false;
            _index--;
            _animation.clip = _animation.GetClip(_animationNames[_index + 4]);
            _animation.Play();
        }
    }
    
    [Serializable]
    public struct Chapter
    {
        public Button     button;
        public GameObject block;
        public GameObject decorators;
        public GameObject title;
    }
}
