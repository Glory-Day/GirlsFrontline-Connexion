using System;
using UnityEngine;
using Object.Manager;
using Util.Manager;

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
            LogManager.LogProgress();

            transitionAnimation.clip = transitionAnimation.GetClip(TransitionDirectionToLeft);
        }

        public void SetTransitionDirectionToRight()
        {
            LogManager.LogProgress();

            transitionAnimation.clip = transitionAnimation.GetClip(TransitionDirectionToRight);
        }

        public void PlayScreenTransition()
        {
            LogManager.LogProgress();

            transitionAnimation.Play();

            LogManager.LogMessage($"Play <b>{transitionAnimation.clip.name}</b>");
        }
        
        #region ANIMATION EVENT API

        public void OnLoadSceneWhenSceneTransitionToLeft()
        {
            LogManager.LogMessage("<b>Transition Screen Animation Event</b> is activated. Transition direction is <b>Left</b>");

            switch (SceneManager.CurrentSceneLabel)
            {
                case Util.Manager.Scene.Label.Main:
                    SceneManager.OnLoadSceneByLabel(Util.Manager.Scene.Label.Selection);
                    break;
                case Util.Manager.Scene.Label.Selection:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void OnLoadSceneWhenSceneTransitionToRight()
        {
            LogManager.LogMessage("<b>Transition Screen Animation Event</b> is activated. Transition direction is <b>Right</b>");

            switch (SceneManager.CurrentSceneLabel)
            {
                case Util.Manager.Scene.Label.Main:
                    break;
                case Util.Manager.Scene.Label.Selection:
                    SceneManager.OnLoadSceneByLabel(Util.Manager.Scene.Label.Main);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion
    }
}
