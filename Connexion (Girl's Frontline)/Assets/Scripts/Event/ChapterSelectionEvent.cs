#region NAMESPACE API

using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Manager;
using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace Scene
{
    /// <summary>
    /// Events in the <b>Selection Scene</b>
    /// </summary>
    public class ChapterSelectionEvent : MonoBehaviour
    {
        #region SERIALIZABLE FIELD

        [Serializable]
        public struct Chapter
        {
            public Button     button;
            public GameObject block;
            public GameObject decorators;
            public GameObject title;
        }

        [Header("# Undo Button")]
        [SerializeField]
        public Button undoButton;

        [Header("# Chapter Select Button")]
        [SerializeField]
        public Button nextButton;
        public Button previewButton;

        [Header("# Chapter Buttons")]
        [SerializeField]
        public Chapter[] chapters;

        #endregion

        /// <summary>
        /// Number of current selected <see cref="chapters"/> index
        /// </summary>
        private int currentChapterIndex;

        /// <summary>
        /// <see cref="Chapter"/> selection <see cref="Animation"/> component
        /// </summary>
        private Animation selectionAnimation;

        /// <summary>
        /// Whether <see cref="chapters"/> stored in <see cref="Manager.Data.Category.GameData"/> are enabled
        /// </summary>
        private bool[] isChapterLock;

        #region ANIMATION NAME API
        
        /// <summary>
        /// Animation names in <see cref="nextButton"/>
        /// </summary>
        private readonly string[] nextButtonAnimationNames =
        {
            "Next Button Animation 01", "Next Button Animation 02",
            "Next Button Animation 03", "Next Button Animation 04"
        };
        
        /// <summary>
        /// Animation names in <see cref="previewButton"/>
        /// </summary>
        private readonly string[] previewButtonAnimationNames =
        {
            "Preview Button Animation 01", "Preview Button Animation 02",
            "Preview Button Animation 03", "Preview Button Animation 04"
        };

        #endregion

        // Awake is called when the script instance is being loaded
        private void Awake()
        {
            LogManager.OnDebugLog(
                typeof(ChapterSelectionEvent),
                "Awake()");
            
            isChapterLock = Enumerable.Range(0, 5)
                                      .Select(i => DataManager.GameData.chapters[i].isLock)
                                      .ToArray();

            for (var i = 0; i < 5; i++)
            {
                var isEnable = isChapterLock[i];
                chapters[i].block.SetActive(isEnable);
                chapters[i].decorators.SetActive(!isEnable);
                chapters[i].title.SetActive(!isEnable);
            }

            previewButton.interactable = false;
            currentChapterIndex = 0;
        }

        // Start is called before the first frame update
        private void Start()
        {
            LogManager.OnDebugLog(
                typeof(ChapterSelectionEvent),
                "Start()");
            
            selectionAnimation = GetComponent<Animation>();
        }

        #region BUTTON EVENT API

        /// <summary>
        /// <see cref="Button"/> event to click <see cref="undoButton"/> in <b>Selection Scene</b>
        /// </summary>
        public void OnClickedUndoButton()
        {
            LogManager.OnDebugLog(
                LabelType.Event, 
                typeof(ChapterSelectionEvent),
                "<b>Undo Button</b> is clicked");

            undoButton.interactable = false;
            nextButton.interactable = previewButton.interactable = false;
            chapters[currentChapterIndex].button.interactable = false;

            UIManager.SetScreenTransitionDirectionToRight();
            UIManager.OnPlayScreenTransitionAnimation();
        }

        /// <summary>
        /// <see cref="Button"/> event to click <see cref="nextButton"/> in <b>Selection Scene</b>
        /// </summary>
        public void OnClickedNextButton()
        {
            LogManager.OnDebugLog(
                LabelType.Event, 
                typeof(ChapterSelectionEvent),
                $"<b>Next Button</b> is clicked");

            // Play animation for select next chapter button
            selectionAnimation.clip = selectionAnimation.GetClip(nextButtonAnimationNames[currentChapterIndex++]);
            selectionAnimation.Play();

            LogManager.OnDebugLog(
                LabelType.Success, 
                typeof(ChapterSelectionEvent),
                $"<b>Chapter 0{currentChapterIndex + 1}</b> is selected successfully");
        }

        /// <summary>
        /// <see cref="Button"/> event to click <see cref="previewButton"/> in <b>Selection Scene</b>
        /// </summary>
        public void OnClickedPreviewButton()
        {
            LogManager.OnDebugLog(
                LabelType.Event, 
                typeof(ChapterSelectionEvent),
                $"<b>Preview Button</b> is clicked");

            // Play animation for select preview chapter button
            selectionAnimation.clip = selectionAnimation.GetClip(previewButtonAnimationNames[--currentChapterIndex]);
            selectionAnimation.Play();

            LogManager.OnDebugLog(
                LabelType.Success, 
                typeof(ChapterSelectionEvent),
                $"<b>Chapter 0{currentChapterIndex + 1}</b> is selected successfully");
        }

        #endregion

        #region ANIMATION EVENT API

        /// <summary>
        /// Disable <see cref="nextButton"/> and <see cref="previewButton"/> for playing selection animation
        /// </summary>
        public void OnDisableButtons()
        {
            nextButton.interactable = previewButton.interactable = false;
        }

        /// <summary>
        /// Enable <see cref="nextButton"/> and <see cref="previewButton"/> and <b>Selected Chapter Button</b>
        /// </summary>
        public void OnEnableButtons()
        {
            // Enable next, preview button to context
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
                    nextButton.interactable = previewButton.interactable = true;
                    break;
            }

            // Enable chapter button to context
            chapters[currentChapterIndex].button.interactable = !isChapterLock[currentChapterIndex];
        }

        #endregion
    }
}
