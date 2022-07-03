using System;
using Manager;
using Manager.Log;
using UnityEngine;
using UnityEngine.UI;

namespace Main
{
    public class SelectionButtonUtility : MonoBehaviour
    {
        [Header("# Chapter Select Button")] 
        [SerializeField]
        public Button nextButton;
        public Button previewButton;

        private int chapterIndex;
        private Animation selectionAnimation;

        private readonly string[] nextButtonAnimationNames =
        {
            "Next_Button_Animation_01", "Next_Button_Animation_02",
            "Next_Button_Animation_03", "Next_Button_Animation_04"
        };
        
        private readonly string[] previewButtonAnimationNames =
        {
            "Preview_Button_Animation_01", "Preview_Button_Animation_02", 
            "Preview_Button_Animation_03", "Preview_Button_Animation_04"
        };

        // Start is called before the first frame update
        private void Start()
        {
            selectionAnimation = GetComponent<Animation>();

            chapterIndex = 0;
            previewButton.interactable = false;
        }

        /// <summary>
        /// Button event to click <b>Undo Button</b> in <b>Selection Scene</b>
        /// </summary>
        public void OnClickedUndoButton()
        {
            LogManager.OnDebugLog(Label.LabelType.Event, typeof(SelectionButtonUtility), 
                "<b>Undo Button</b> is clicked");
            
            UIManager.SetRightScreenTransitionAnimation();
            UIManager.OnPlayScreenTransitionAnimation();
        }

        #region BUTTON API

        /// <summary>
        /// Button event to click <b>Next Button</b> in <b>Selection Scene</b>
        /// </summary>
        public void OnClickedNextButton()
        {
            LogManager.OnDebugLog(Label.LabelType.Event, typeof(SelectionButtonUtility), 
                $"<b>Next Button</b> is clicked");

            selectionAnimation.clip = selectionAnimation.GetClip(nextButtonAnimationNames[chapterIndex++]);
            selectionAnimation.Play();
        }
        
        /// <summary>
        /// Button event to click <b>Preview Button</b> in <b>Selection Scene</b>
        /// </summary>
        public void OnClickedPreviewButton()
        {
            LogManager.OnDebugLog(Label.LabelType.Event, typeof(SelectionButtonUtility), 
                $"<b>Preview Button</b> is clicked");

            selectionAnimation.clip = selectionAnimation.GetClip(previewButtonAnimationNames[--chapterIndex]);
            selectionAnimation.Play();
        }

        #endregion

        #region ANIMATION EVENT API

        public void OnDisableSelectButton()
        {
            nextButton.interactable = previewButton.interactable = false;
        }
        
        public void OnEnableSelectButton()
        {
            switch (chapterIndex)
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
        }

        #endregion
    }
}
