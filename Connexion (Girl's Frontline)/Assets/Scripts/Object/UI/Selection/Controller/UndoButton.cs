#region NAMESPACE API

using System;
using UnityEngine;
using Manager;
using Label = Manager.Log.Label;

#endregion

namespace Object.UI.Selection.Controller
{
    public class UndoButton : MonoBehaviour
    {
        #region COMPONENT FIELD API

        private UnityEngine.UI.Button undoButton;

        #endregion
        
        private UnityEngine.UI.Button nextButton;
        private UnityEngine.UI.Button previewButton;
        
        // Start is called before the first frame update
        private void Start()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(UndoButton),
                "Start()");

            undoButton = GetComponent<UnityEngine.UI.Button>();
            
            var component = GetComponentInParent<ChapterSelector>();
            nextButton = component.NextButton;
            previewButton = component.PreviewButton;
            GetCurrentChapterButtonCallBack = component.GetCurrentChapterButton;
        }

        #region BUTTON EVENT API

        public void OnClicked()
        {
            LogManager.OnDebugLog(
                Label.Event, 
                typeof(UndoButton),
                $"<b>Undo Button</b> is clicked");

            if (GetCurrentChapterButtonCallBack == null) return;
            
            undoButton.interactable = false;
            nextButton.interactable = false;
            previewButton.interactable = false;
            GetCurrentChapterButtonCallBack.Invoke().interactable = false;
            
            UIManager.OnPlayScreenTransitionToRight();
        }

        #endregion
        
        #region CALLBACK API

        private event Func<UnityEngine.UI.Button> GetCurrentChapterButtonCallBack; 

        #endregion
    }
}
