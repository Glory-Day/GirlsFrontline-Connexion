using System;
using Manager;
using Manager.Log;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// Events for screen transition
    /// </summary>
    public class ScreenTransitionEvent : MonoBehaviour
    {
        /// <summary>
        /// When scene transition animation is left, load scene by <b>CurrentSceneName</b>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> Out of range exception in <b>SceneName</b> </exception>
        public void OnLoadSceneWhenSceneTransitionToLeft()
        {
            LogManager.OnDebugLog(Label.LabelType.Event, typeof(ScreenTransitionEvent), 
                $"<b>Left Scene Transition Animation</b> event is activated");
            
            switch (SceneManager.CurrentSceneName)
            {
                case SceneManager.SceneName.MainScene:
                    SceneManager.OnLoadScene(SceneManager.SceneName.SelectionScene);
                    break;
                case SceneManager.SceneName.SelectionScene:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        /// <summary>
        /// When scene transition animation is right, load scene by <b>CurrentSceneName</b>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"> Out of range exception in <b>SceneName</b> </exception>
        public void OnLoadSceneWhenSceneTransitionToRight()
        {
            LogManager.OnDebugLog(Label.LabelType.Event, typeof(ScreenTransitionEvent), 
                $"<b>Right Scene Transition Animation</b> event is activated");
            
            switch (SceneManager.CurrentSceneName)
            {
                case SceneManager.SceneName.MainScene:
                    break;
                case SceneManager.SceneName.SelectionScene:
                    SceneManager.OnLoadScene(SceneManager.SceneName.MainScene);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
