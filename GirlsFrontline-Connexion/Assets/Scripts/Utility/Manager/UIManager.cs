using System;
using GloryDay.Log;
using GloryDay.UI.View;
using GloryDay.Utility;
using UI.View;
using UnityEngine;
using Utility.Manager.UI;

namespace Utility.Manager
{
    public class UIManager : SingletonGameObject<UIManager>
    {
        private ITransitionable _slidingTransition;
        private GameObject      _pauseScreen;
        private GameObject      _optionScreen;
        private GameObject      _loadingMessageScreen;
        
        protected UIManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }

        #region INSTANTIATE METHOD API

        private void InstantiateAllUIPrefabs()
        {
            LogManager.LogProgress();
            
            SetSceneTransitionScreen();
            SetOptionCanvas();
            SetPauseCanvas();
            SetLoadingMessageCanvas();
            
            LogManager.LogSuccess("<b>All UI Prefabs</b> is loaded");
        }
        
        private void SetSceneTransitionScreen()
        {
            LogManager.LogProgress();
            
            var key = DataManager.GameObjectData.UI.SceneTransitionScreen;
            var original = ResourceManager.GameObjectResource.UI[key];
            var instance = Instantiate(original, transform, true);
            
            // Set event from instance object component
            _slidingTransition = instance.GetComponent<SlidingTransitionScreen>();
        }

        private void SetOptionCanvas()
        {
            LogManager.LogProgress();
            
            var key = DataManager.GameObjectData.UI.OptionScreen;
            var original = ResourceManager.GameObjectResource.UI[key];
            Instantiate(original, transform, true);
        }

        private void SetPauseCanvas()
        {
            LogManager.LogProgress();
            
            var key = DataManager.GameObjectData.UI.PauseScreen;
            var original = ResourceManager.GameObjectResource.UI[key];
            var instance = Instantiate(original, transform, true);
            instance.SetActive(false);

            _pauseScreen = instance;
        }

        private void SetLoadingMessageCanvas()
        {
            LogManager.LogProgress();
            
            var key = DataManager.GameObjectData.UI.LoadingMessageScreen;
            var original = ResourceManager.GameObjectResource.UI[key];
            var instance = Instantiate(original, transform, true);
            instance.SetActive(false);

            _loadingMessageScreen = instance;
        }
        
        #endregion

        #region STATIC METHOD API

        public static void OnInstantiateAllUIObjects()
        {
            LogManager.LogProgress();
            
            Instance.InstantiateAllUIPrefabs();
        }

        public static void OnEnablePauseScreen()
        {
            LogManager.LogProgress();
            
            Instance._pauseScreen.SetActive(true);
        }

        public static void OnDisablePauseScreen()
        {
            LogManager.LogProgress();
            
            Instance._pauseScreen.SetActive(false);
        }

        public static void OnEnableLoadingMessageScreen()
        {
            LogManager.LogProgress();
            
            Instance._loadingMessageScreen.SetActive(true);
        }
        
        public static void OnDisableLoadingMessageScreen()
        {
            LogManager.LogProgress();
            
            Instance._loadingMessageScreen.SetActive(false);
        }

        public static ITransitionable GetTransitionByMode(TransitionMode mode)
        {
            ITransitionable transition = null;
            
            try
            {
                switch (mode)
                {
                    case TransitionMode.None:
                        break;
                    case TransitionMode.Slide:
                        transition = Instance._slidingTransition;
                        break;
                    case TransitionMode.Gate:
                        //TODO: You must fix this code. Add gate transition. 
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
                }
            }
            catch (ArgumentOutOfRangeException exception)
            {
                LogManager.LogError(exception.Message);
            }

            return transition;
        }

        #endregion
    }
}
