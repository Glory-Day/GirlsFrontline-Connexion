﻿#region NAMESPACE API

using System;
using UnityEngine;
using Manager;
using Label = Manager.Log.Label;

#endregion

namespace Object.UI.Selection.Component
{
    public class UndoButton : MonoBehaviour
    {
        #region CALLBACK API

        private event Func<UnityEngine.UI.Button> GetCurrentChapterButtonCallBack; 

        #endregion

        private UnityEngine.UI.Button nextButton;
        private UnityEngine.UI.Button previewButton;
        private UnityEngine.UI.Button undoButton;
        
        // Start is called before the first frame update
        private void Start()
        {
            LogManager.OnDebugLog(
                typeof(UndoButton),
                "Start()");

            undoButton = GetComponent<UnityEngine.UI.Button>();
            
            var component = GetComponentInParent<SelectionController>();
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
            
            UIManager.SetScreenTransitionDirectionToRight();
            UIManager.OnPlayScreenTransitionAnimation();
        }

        #endregion
    }
}