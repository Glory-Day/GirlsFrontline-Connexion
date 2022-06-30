using System;
using Manager;
using Manager.Log;
using UnityEngine;

namespace UI
{
    public class ScreenTransitionEvent : MonoBehaviour
    {
        public void OnLoadSceneWhenLeftTransition()
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
        
        public void OnLoadSceneWhenRightTransition()
        {
            LogManager.OnDebugLog(Label.LabelType.Event, typeof(ScreenTransitionEvent), 
                $"<b>Right Scene Transition Animation</b> event is activated");
            
            switch (SceneManager.CurrentSceneName)
            {
                case SceneManager.SceneName.MainScene:
                    break;
                case SceneManager.SceneName.SelectionScene:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
