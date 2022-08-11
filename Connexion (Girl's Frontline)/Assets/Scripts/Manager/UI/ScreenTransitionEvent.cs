#region NAMESPACE API

using System;
using UnityEngine;
using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace Manager.UI
{
    /// <summary>
    /// Events for screen transition
    /// </summary>
    public class ScreenTransitionEvent : MonoBehaviour
    {
        #region ANIMATION EVENT API

        /// <summary>
        /// When scene transition <see cref="Animation"/> is left,
        /// load scene by <see cref="SceneManager.CurrentSceneName"/>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Out of range exception in <see cref="SceneManager.SceneName"/>
        /// </exception>
        public void OnLoadSceneWhenSceneTransitionToLeft()
        {
            LogManager.OnDebugLog(LabelType.Event, typeof(ScreenTransitionEvent),
                $"<b>Scene Transition Animation Event</b> is activated. Transition direction is <b>Left</b>");

            switch (SceneManager.CurrentSceneName)
            {
                case SceneManager.SceneName.MainScene:
                    SceneManager.OnLoadSceneByName(SceneManager.SceneName.SelectionScene);
                    break;
                case SceneManager.SceneName.SelectionScene:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// When scene transition <see cref="Animation"/> is right,
        /// load scene by <see cref="SceneManager.CurrentSceneName"/>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Out of range exception in <see cref="SceneManager.SceneName"/>
        /// </exception>
        public void OnLoadSceneWhenSceneTransitionToRight()
        {
            LogManager.OnDebugLog(LabelType.Event, typeof(ScreenTransitionEvent),
                $"<b>Scene Transition Animation Event</b> is activated. Transition direction is <b>Right</b>");

            switch (SceneManager.CurrentSceneName)
            {
                case SceneManager.SceneName.MainScene:
                    break;
                case SceneManager.SceneName.SelectionScene:
                    SceneManager.OnLoadSceneByName(SceneManager.SceneName.MainScene);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion
    }
}
