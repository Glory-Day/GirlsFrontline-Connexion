#region NAMESPACE API

using UnityEngine;
using Manager;
using Label = Manager.Log.Label;

#endregion

namespace Object.UI.Chapter.Component
{
    public class NextButton : MonoBehaviour
    {
        #region CONSTANT FIELD

        private readonly string[] animationNames =
        {
            "Next Button Animation 01", "Next Button Animation 02",
            "Next Button Animation 03", "Next Button Animation 04"
        };

        #endregion

        private ChapterController controller;
        
        // Start is called before the first frame update
        private void Start()
        {
            LogManager.OnDebugLog(
                typeof(NextButton),
                "Start()");
            
            controller = GetComponentInParent<ChapterController>();
        }

        #region BUTTON EVENT API

        public void OnClicked()
        {
            LogManager.OnDebugLog(
                Label.Event, 
                typeof(NextButton),
                $"<b>Next Button</b> is clicked");

            controller.SelectionAnimation.clip = controller.SelectionAnimation.GetClip(
                animationNames[controller.CurrentChapterIndex++]);
            controller.SelectionAnimation.Play();
            
            LogManager.OnDebugLog(
                Label.Success, 
                typeof(NextButton),
                $"<b>Chapter 0{controller.CurrentChapterIndex + 1}</b> is selected successfully");
        }

        #endregion
    }
}
