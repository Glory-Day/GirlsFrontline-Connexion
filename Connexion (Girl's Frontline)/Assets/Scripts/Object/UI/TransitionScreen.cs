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
        #region COMPONENT FIELD API

        private Animation transitionAnimation;

        #endregion

        #region CONSTANT FIELD API

        private const string TransitionDirectionToLeft  = "Screen Transition To Left Animation";
        private const string TransitionDirectionToRight = "Screen Transition To Right Animation";

        #endregion

        private void Start()
        {
            transitionAnimation = GetComponent<Animation>();
        }

        public void SetTransitionDirectionToLeft()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(TransitionScreen),
                $"SetTransitionDirectionToLeft()");

            transitionAnimation.clip = transitionAnimation.GetClip(TransitionDirectionToLeft);
        }

        public void SetTransitionDirectionToRight()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(TransitionScreen),
                $"SetTransitionDirectionToRight()");

            transitionAnimation.clip = transitionAnimation.GetClip(TransitionDirectionToRight);
        }

        public void PlayScreenTransition()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(TransitionScreen),
                $"PlayScreenTransition()");

            transitionAnimation.Play();

            LogManager.OnDebugLog(
                Label.Event, 
                typeof(TransitionScreen),
                $"Play <b>{transitionAnimation.clip.name}</b>");
        }
        
        #region ANIMATION EVENT API

        public void OnLoadSceneWhenSceneTransitionToLeft()
        {
            LogManager.OnDebugLog(
                Label.Event, 
                typeof(TransitionScreen),
                $"<b>Transition Screen Animation Event</b> is activated. Transition direction is <b>Left</b>");

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
                $"<b>Transition Screen Animation Event</b> is activated. Transition direction is <b>Right</b>");

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
