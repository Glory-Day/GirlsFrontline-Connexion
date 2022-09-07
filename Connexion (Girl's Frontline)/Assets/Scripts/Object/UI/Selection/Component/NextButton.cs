#region NAMESPACE API

using System;
using UnityEngine;
using Manager;
using Label = Manager.Log.Label;

#endregion

namespace Object.UI.Selection.Component
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
            LogManager.OnDebugLog(
                typeof(NextButton),
                "Start()");
            
            var component = GetComponentInParent<SelectionController>();
            selectionAnimation = component.SelectionAnimation;
            IncreaseChapterIndexCallBack = component.IncreaseChapterIndex;
            GetCurrentChapterIndexCallBack = component.GetCurrentChapterIndex;
        }

        #region BUTTON EVENT API

        public void OnClicked()
        {
            LogManager.OnDebugLog(
                Label.Event, 
                typeof(NextButton),
                $"<b>Next Button</b> is clicked");

            if (GetCurrentChapterIndexCallBack == null) return;

            selectionAnimation.clip = 
                selectionAnimation.GetClip(animationNames[GetCurrentChapterIndexCallBack.Invoke()]);
            selectionAnimation.Play();

            IncreaseChapterIndexCallBack?.Invoke();

            LogManager.OnDebugLog(
                Label.Success,
                typeof(NextButton),
                $"<b>Chapter 0{GetCurrentChapterIndexCallBack.Invoke() + 1}</b> is selected successfully");
        }

        #endregion
        
        #region CALLBACK API

        private event Action IncreaseChapterIndexCallBack;
        private event Func<int> GetCurrentChapterIndexCallBack;
        
        #endregion
    }
}
