﻿using GloryDay.Log;

namespace UI.Controller.Button
{
    public class ReturnButton : UIButtonBase
    {
        #region COMPONENT FIELD API

        private TransitionScreen _transitionScreen;

        #endregion
        
        // Awake is called when the script instance is being loaded.
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();
            
            _transitionScreen = FindObjectOfType<TransitionScreen>();
            
            SetHoverSound(0);
            SetClickSound(1);
        }

        protected override void Click()
        {
            LogManager.LogMessage("<b>Return Button</b> is clicked");
            
            base.Click();
            
            Button.interactable = false;
            
            _transitionScreen.Transition(1, TransitionType.Slide);
        }
    }
}