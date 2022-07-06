using System;
using Manager;
using Manager.Log;
using UnityEngine;
using UnityEngine.UI;

namespace Main
{
    public class SelectionButtonUtility : MonoBehaviour
    {
        [Serializable]
        public struct Chapter
        {
            public Button button;
            public GameObject block;
            public GameObject decorators;
            public GameObject title;
        }
        
        [Header("# Chapter Select Button")] 
        [SerializeField]
        public Button nextButton;
        public Button previewButton;

        [Header("# Chapter Buttons")] 
        [SerializeField]
        public Chapter[] chapters;

        /// <summary>
        /// Chapter button index
        /// </summary>
        private int chapterIndex;
        
        /// <summary>
        /// Chapter selection animation component
        /// </summary>
        private Animation selectionAnimation;

        /// <summary>
        /// Whether chapter buttons stored in game data are enabled
        /// </summary>
        private bool[] chapterButtonData;

        #region ANIMATION NAME API

        private readonly string[] nextButtonAnimationNames =
        {
            "Next_Button_Animation_01","Next_Button_Animation_02",
            "Next_Button_Animation_03","Next_Button_Animation_04"
        };
        
        private readonly string[] previewButtonAnimationNames =
        {
            "Preview_Button_Animation_01","Preview_Button_Animation_02", 
            "Preview_Button_Animation_03","Preview_Button_Animation_04"
        };

        #endregion

        // Start is called before the first frame update
        private void Start()
        {
            selectionAnimation = GetComponent<Animation>();

            chapterIndex = 0;
            previewButton.interactable = false;
            chapterButtonData = DataManager.GameData.chapterButtonData;

            for (var i = 0; i < 5; i++)
            {
                var isEnable = chapterButtonData[i];
                chapters[i].block.SetActive(isEnable);
                chapters[i].decorators.SetActive(!isEnable);
                chapters[i].title.SetActive(!isEnable);
            }
        }

        #region BUTTON API
        
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

        /// <summary>
        /// Button event to click <b>Next Button</b> in <b>Selection Scene</b>
        /// </summary>
        public void OnClickedNextButton()
        {
            LogManager.OnDebugLog(Label.LabelType.Event, typeof(SelectionButtonUtility), 
                $"<b>Next Button</b> is clicked.");

            // Play animation for select next chapter button
            selectionAnimation.clip = selectionAnimation.GetClip(nextButtonAnimationNames[chapterIndex]);
            selectionAnimation.Play();

            chapterIndex++;
            
            LogManager.OnDebugLog(Label.LabelType.Success, typeof(SelectionButtonUtility), 
                $"<b>Chapter 0{chapterIndex + 1}</b> is selected");
        }
        
        /// <summary>
        /// Button event to click <b>Preview Button</b> in <b>Selection Scene</b>
        /// </summary>
        public void OnClickedPreviewButton()
        {
            LogManager.OnDebugLog(Label.LabelType.Event, typeof(SelectionButtonUtility), 
                $"<b>Preview Button</b> is clicked.");

            // Play animation for select preview chapter button
            selectionAnimation.clip = selectionAnimation.GetClip(previewButtonAnimationNames[chapterIndex - 1]);
            selectionAnimation.Play();

            chapterIndex--;
            
            LogManager.OnDebugLog(Label.LabelType.Success, typeof(SelectionButtonUtility), 
                $"<b>Chapter 0{chapterIndex + 1}</b> is selected");
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
        /// Enable <b>Next Button</b> and <b>Preview Button</b> and selected chapter button
        /// </summary>
        public void OnEnableButtons()
        {
            // Enable next, preview button to context
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
                default :
                    nextButton.interactable = previewButton.interactable = true;
                    break;
            }
            
            // Enable chapter button to context
            chapters[chapterIndex].button.interactable = !chapterButtonData[chapterIndex];
        }

        #endregion
    }
}
