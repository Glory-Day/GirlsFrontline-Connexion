#region NAMESPACE API

using System;
using System.Linq;
using UnityEngine;
using Manager;
using View;
using Label = Manager.Log.Label;

#endregion

namespace Object.UI.Selection
{
    public class SelectionController : MonoBehaviour
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
        
        #endregion

        private int    currentChapterIndex;
        private bool[] isChapterBlock;

        // Start is called before the first frame update
        private void Start()
        {
            LogManager.OnDebugLog(
                typeof(SelectionController),
                "Start()");
            
            Initialize();

            SelectionAnimation = GetComponent<Animation>();
        }

        private void Initialize()
        {
            LogManager.OnDebugLog(
                typeof(SelectionController),
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

            currentChapterIndex = 0;
            previewButton.interactable = false;
        }

        public void IncreaseChapterIndex()
        {
            currentChapterIndex++;
        }

        public void DecreaseChapterIndex()
        {
            currentChapterIndex--;
        }

        public int GetCurrentChapterIndex()
        {
            return currentChapterIndex;
        }

        public UnityEngine.UI.Button GetCurrentChapterButton()
        {
            return chapters[currentChapterIndex].button;
        }

        #region ANIMATION EVENT API

        public void OnEnableButtons()
        {
            LogManager.OnDebugLog(
                Label.Event, 
                typeof(SelectionController), 
                "<b>Chapter Controller Animation Event</b> is activated. " +
                "Next, preview, Undo Buttons is <b>Enabled</b>");
            
            switch (currentChapterIndex)
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

            chapters[currentChapterIndex].button.interactable = !isChapterBlock[currentChapterIndex];
        }
        
        public void OnDisableButtons()
        {
            LogManager.OnDebugLog(
                Label.Event, 
                typeof(SelectionController), 
                "<b>Chapter Controller Animation Event</b> is activated. " +
                "Next, preview, Undo Buttons is <b>Disabled</b>");
            
            nextButton.interactable = false;
            previewButton.interactable = false;
        }

        #endregion

        #region PROPERTIES API

        public UnityEngine.UI.Button NextButton => nextButton;

        public UnityEngine.UI.Button PreviewButton => previewButton;
        
        /// <summary>
        /// Animation to select <see cref="chapters"/>
        /// </summary>
        public Animation SelectionAnimation { get; private set; }

        #endregion
    }
}
