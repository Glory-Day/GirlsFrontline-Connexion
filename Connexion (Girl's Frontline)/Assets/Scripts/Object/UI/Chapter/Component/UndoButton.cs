#region NAMESPACE API

using UnityEngine;
using Manager;
using Label = Manager.Log.Label;

#endregion

namespace Object.UI.Chapter.Component
{
    public class UndoButton : MonoBehaviour
    {
        private ChapterController controller;
        
        // Start is called before the first frame update
        private void Start()
        {
            LogManager.OnDebugLog(
                typeof(UndoButton),
                "Start()");
            
            controller = GetComponentInParent<ChapterController>();
        }

        #region BUTTON EVENT API

        public void OnClicked()
        {
            LogManager.OnDebugLog(
                Label.Event, 
                typeof(UndoButton),
                $"<b>Undo Button</b> is clicked");

            controller.UndoButton.interactable = false;
            controller.NextButton.interactable = false;
            controller.PreviewButton.interactable = false;
            controller.CurrentChapter.button.interactable = false;
            
            UIManager.SetScreenTransitionDirectionToRight();
            UIManager.OnPlayScreenTransitionAnimation();
        }

        #endregion
    }
}
