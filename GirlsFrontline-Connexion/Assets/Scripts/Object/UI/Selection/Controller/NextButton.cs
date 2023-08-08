using System;
using UnityEngine;
using Util.Manager;

namespace Object.UI.Selection.Controller
{
    public class NextButton : MonoBehaviour
    {
        #region CONSTANT FIELD API

        private readonly string[] animationNames =
        {
            "Next Button Animation 01", "Next Button Animation 02",
            "Next Button Animation 03", "Next Button Animation 04"
        };

        #endregion

        private Animation selectionAnimation;
        
        // Start is called before the first frame update
        private void Start()
        {
            LogManager.LogProgress();
            
            var component = GetComponentInParent<ChapterSelector>();
            selectionAnimation = component.SelectionAnimation;
            IncreaseChapterIndexCallBack = component.IncreaseChapterIndex;
            GetCurrentChapterIndexCallBack = component.GetCurrentChapterIndex;
        }

        #region BUTTON EVENT API

        public void OnClicked()
        {
            LogManager.LogMessage("<b>Next Button</b> is clicked");

            if (GetCurrentChapterIndexCallBack == null) return;

            selectionAnimation.clip = 
                selectionAnimation.GetClip(animationNames[GetCurrentChapterIndexCallBack.Invoke()]);
            selectionAnimation.Play();

            IncreaseChapterIndexCallBack?.Invoke();

            LogManager.LogSuccess($"<b>Chapter 0{(GetCurrentChapterIndexCallBack.Invoke() + 1).ToString()}</b> is selected");
        }

        #endregion
        
        #region CALLBACK API

        private event Action IncreaseChapterIndexCallBack;
        private event Func<int> GetCurrentChapterIndexCallBack;
        
        #endregion
    }
}
