﻿#region NAMESPACE API

using System;
using UnityEngine;
using Manager;
using Label = Manager.Log.Label;

#endregion

namespace Object.UI.Selection.Component
{
    public class PreviewButton : MonoBehaviour
    {
        #region CONSTANT FIELD

        private readonly string[] animationNames =
        {
            "Preview Button Animation 01", "Preview Button Animation 02",
            "Preview Button Animation 03", "Preview Button Animation 04"
        };

        #endregion

        #region CALLBACK API

        private event Action DecreaseChapterIndexCallBack;
        private event Func<int> GetCurrentChapterIndexCallBack; 

        #endregion

        private Animation selectionAnimation;

        // Start is called before the first frame update
        private void Start()
        {
            LogManager.OnDebugLog(
                typeof(PreviewButton),
                "Start()");
            
            var component = GetComponentInParent<SelectionController>();
            selectionAnimation = component.SelectionAnimation;
            DecreaseChapterIndexCallBack = component.DecreaseChapterIndex;
            GetCurrentChapterIndexCallBack = component.GetCurrentChapterIndex;
        }

        #region BUTTON EVENT API

        public void OnClicked()
        {
            LogManager.OnDebugLog(
                Label.Event, 
                typeof(PreviewButton),
                $"<b>Preview Button</b> is clicked");

            if (GetCurrentChapterIndexCallBack == null) return;
            
            DecreaseChapterIndexCallBack?.Invoke();
            
            selectionAnimation.clip = 
                selectionAnimation.GetClip(animationNames[GetCurrentChapterIndexCallBack.Invoke()]);
            selectionAnimation.Play();
            
            LogManager.OnDebugLog(
                Label.Success, 
                typeof(NextButton),
                $"<b>Chapter 0{GetCurrentChapterIndexCallBack.Invoke() + 1}</b> is selected successfully");
        }

        #endregion
    }
}