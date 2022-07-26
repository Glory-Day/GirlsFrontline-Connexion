#region NAMESPACE API

using System;

using UnityEngine;
using UnityEngine.UI;

using Manager;
using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace Main
{
    /// <summary>
    /// Events in the <b>Selection Scene</b>
    /// </summary>
    public class SelectionEventUtility : MonoBehaviour
    {
        #region SERIALIZABLE FIELD

        [Serializable]
        public struct Chapter
        {
            public Button button;
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
        /// Number of current selected chapter button index
        /// </summary>
        private int currentChapterIndex;
        
        /// <summary>
        /// Chapter selection animation component
        /// </summary>
        private Animation selectionAnimation;

        /// <summary>
        /// Whether chapter buttons stored in <b>GameData</b> are enabled
        /// </summary>
        private bool[] isChapterLock;

        #region ANIMATION NAME API

        // Animation names in Next Button
        private readonly string[] nextButtonAnimationNames =
        {
            "Next_Button_Animation_01","Next_Button_Animation_02",
            "Next_Button_Animation_03","Next_Button_Animation_04"
        };
        
        // Animation names in Preview Button
        private readonly string[] previewButtonAnimationNames =
        {
            "Preview_Button_Animation_01","Preview_Button_Animation_02", 
            "Preview_Button_Animation_03","Preview_Button_Animation_04"
        };

        #endregion

        // Awake is called when the script instance is being loaded
        private void Awake()
        {
            isChapterLock = DataManager.GameData.isChapterLock;
            
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
            selectionAnimation = GetComponent<Animation>();
        }

        #region BUTTON EVENT API
        
        /// <summary>
        /// Button event to click <b>Undo Button</b> in <b>Selection Scene</b>
        /// </summary>
        public void OnClickedUndoButton()
        {
            LogManager.OnDebugLog(LabelType.Event, typeof(SelectionEventUtility), 
                "<b>Undo Button</b> is clicked");

            undoButton.interactable = false;
            nextButton.interactable = previewButton.interactable = false;
            chapters[currentChapterIndex].button.interactable = false;
            
            UIManager.SetScreenTransitionDirectionToRight();
            UIManager.OnPlayScreenTransitionAnimation();
        }

        /// <summary>
        /// Button event to click <b>Next Button</b> in <b>Selection Scene</b>
        /// </summary>
        public void OnClickedNextButton()
        {
            LogManager.OnDebugLog(LabelType.Event, typeof(SelectionEventUtility), 
                $"<b>Next Button</b> is clicked");

            // Play animation for select next chapter button
            selectionAnimation.clip = selectionAnimation.GetClip(nextButtonAnimationNames[currentChapterIndex++]);
            selectionAnimation.Play();

            LogManager.OnDebugLog(LabelType.Success, typeof(SelectionEventUtility), 
                $"<b>Chapter 0{currentChapterIndex + 1}</b> is selected");
        }
        
        /// <summary>
        /// Button event to click <b>Preview Button</b> in <b>Selection Scene</b>
        /// </summary>
        public void OnClickedPreviewButton()
        {
            LogManager.OnDebugLog(LabelType.Event, typeof(SelectionEventUtility), 
                $"<b>Preview Button</b> is clicked");

            // Play animation for select preview chapter button
            selectionAnimation.clip = selectionAnimation.GetClip(previewButtonAnimationNames[--currentChapterIndex]);
            selectionAnimation.Play();

            LogManager.OnDebugLog(LabelType.Success, typeof(SelectionEventUtility), 
                $"<b>Chapter 0{currentChapterIndex + 1}</b> is selected");
        }

        #endregion

        #region ANIMATION EVENT API

        /// <summary>
        /// Disable <b>Next Button</b> and <b>Preview Button</b> for playing selection animation
        /// </summary>
        public void OnDisableButtons()
        {
            nextButton.interactable = previewButton.interactable = false;
        }
        
        /// <summary>
        /// Enable <b>Next Button</b> and <b>Preview Button</b> and <b>Selected Chapter Button</b>
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
                default :
                    nextButton.interactable = previewButton.interactable = true;
                    break;
            }
            
            // Enable chapter button to context
            chapters[currentChapterIndex].button.interactable = !isChapterLock[currentChapterIndex];
        }

        #endregion
    }
}
