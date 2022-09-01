#region NAMESPACE API

using System;
using UnityEngine;
using Manager;
using Label = Manager.Log.Label;

#endregion

namespace Object.UI
{
    public class TransitionScreen : MonoBehaviour
    {
        #region ANIMATION EVENT API

        public void OnLoadSceneWhenSceneTransitionToLeft()
        {
            LogManager.OnDebugLog(
                Label.Event, 
                typeof(TransitionScreen),
                $"<b>Scene Transition Animation Event</b> is activated. Transition direction is <b>Left</b>");

            switch (SceneManager.CurrentSceneLabel)
            {
                case Manager.Scene.Label.Main:
                    SceneManager.OnLoadSceneByLabel(Manager.Scene.Label.Selection);
                    break;
                case Manager.Scene.Label.Selection:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void OnLoadSceneWhenSceneTransitionToRight()
        {
            LogManager.OnDebugLog(
                Label.Event, 
                typeof(TransitionScreen),
                $"<b>Scene Transition Animation Event</b> is activated. Transition direction is <b>Right</b>");

            switch (SceneManager.CurrentSceneLabel)
            {
                case Manager.Scene.Label.Main:
                    break;
                case Manager.Scene.Label.Selection:
                    SceneManager.OnLoadSceneByLabel(Manager.Scene.Label.Main);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion
    }
}
