#region NAMESPACE API

using System;
using System.Linq;
using UnityEngine;
using Manager;
using View;
using Label = Manager.Log.Label;

#endregion

namespace Object.UI.Chapter
{
    public class ChapterController : MonoBehaviour
    {
        #region SERIALIZABLE FIELD

        [Serializable]
        public struct Chapter
        {
            public UnityEngine.UI.Button button;
            public GameObject            block;
            public GameObject            decorators;
            public GameObject            title;
        }

        [Header("# Chapter Components")]
        [SerializeField]
        [NamedArray("Chapter", 1)]
        private Chapter[] chapters;

        [Header("# Chapter Selection Buttons")]
        [SerializeField]
        private UnityEngine.UI.Button nextButton;
        [SerializeField]
        private UnityEngine.UI.Button previewButton;

        [Header("# Undo Button")]
        [SerializeField]
        private UnityEngine.UI.Button undoButton;
        
        #endregion

        private bool[] isChapterBlock;

        // Start is called before the first frame update
        private void Start()
        {
            LogManager.OnDebugLog(
                typeof(ChapterController),
                "Start()");
            
            Initialize();

            SelectionAnimation = GetComponent<Animation>();

            CurrentChapterIndex = 0;
            previewButton.interactable = false;
        }

        private void Initialize()
        {
            LogManager.OnDebugLog(
                typeof(ChapterController),
                "Initialize()");

            isChapterBlock = Enumerable.Range(0, 5)
                                       .Select(i => DataManager.GameData.chapters[i].isBlock)
                                       .ToArray();

            for (var i = 0; i < 5; i++)
            {
                var isBlock = isChapterBlock[i];
                chapters[i].block.SetActive(isBlock);
                chapters[i].decorators.SetActive(!isBlock);
                chapters[i].title.SetActive(!isBlock);
            }
        }

        #region ANIMATION EVENT API

        public void OnEnableButtons()
        {
            LogManager.OnDebugLog(
                Label.Event, 
                typeof(ChapterController), 
                "<b>Chapter Controller Animation Event</b> is activated. " +
                "Next, preview, Undo Buttons is <b>Enabled</b>");
            
            switch (CurrentChapterIndex)
            {
                case 0:
                    nextButton.interactable = true;
                    previewButton.interactable = false;
                    break;
                case 4:
                    nextButton.interactable = false;
                    previewButton.interactable = true;
                    break;
                default:
                    nextButton.interactable = true;
                    previewButton.interactable = true;
                    break;
            }

            CurrentChapter.button.interactable = !isChapterBlock[CurrentChapterIndex];
        }
        
        public void OnDisableButtons()
        {
            LogManager.OnDebugLog(
                Label.Event, 
                typeof(ChapterController), 
                "<b>Chapter Controller Animation Event</b> is activated. " +
                "Next, preview, Undo Buttons is <b>Disabled</b>");
            
            nextButton.interactable = false;
            previewButton.interactable = false;
        }

        #endregion

        public UnityEngine.UI.Button NextButton => nextButton;

        public UnityEngine.UI.Button PreviewButton => previewButton;

        public UnityEngine.UI.Button UndoButton => undoButton;
        
        public Chapter[] Chapters => chapters;
        
        /// <summary>
        /// Animation to select <see cref="chapters"/>
        /// </summary>
        public Animation SelectionAnimation { get; private set; }
        
        public int CurrentChapterIndex { get; set; }

        public Chapter CurrentChapter => chapters[CurrentChapterIndex];
    }
}
