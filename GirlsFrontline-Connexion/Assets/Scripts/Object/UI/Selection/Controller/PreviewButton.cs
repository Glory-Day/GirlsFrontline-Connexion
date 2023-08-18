using System;
using UnityEngine;
using Utility.Manager;

namespace Object.UI.Selection.Controller
{
    public class PreviewButton : MonoBehaviour
    {
        #region CONSTANT FIELD API

        private readonly string[] animationNames =
        {
            "Preview Button Animation 01", "Preview Button Animation 02",
            "Preview Button Animation 03", "Preview Button Animation 04"
        };

        #endregion

        private Animation selectionAnimation;
        
        // Start is called before the first frame update
        private void Start()
        {
            LogManager.LogProgress();
            
            var component = GetComponentInParent<ChapterSelector>();
            selectionAnimation = component.SelectionAnimation;
            DecreaseChapterIndexCallBack = component.DecreaseChapterIndex;
            GetCurrentChapterIndexCallBack = component.GetCurrentChapterIndex;
        }

        #region BUTTON EVENT API

        public void OnClicked()
        {
            LogManager.LogMessage("<b>Preview Button</b> is clicked");

            if (GetCurrentChapterIndexCallBack == null) return;
            
            DecreaseChapterIndexCallBack?.Invoke();
            
            selectionAnimation.clip = 
                selectionAnimation.GetClip(animationNames[GetCurrentChapterIndexCallBack.Invoke()]);
            selectionAnimation.Play();
            
            LogManager.LogSuccess($"<b>Chapter 0{(GetCurrentChapterIndexCallBack.Invoke() + 1).ToString()}</b> is selected");
        }

        #endregion
        
        #region CALLBACK API

        private event Action DecreaseChapterIndexCallBack;
        private event Func<int> GetCurrentChapterIndexCallBack; 

        #endregion
    }
}
