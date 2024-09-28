using System;
using System.Collections;
using GloryDay.Animations;
using GloryDay.Log;
using UnityEngine;
using Utility;

namespace UI
{
    public class InformationDisplay : MonoBehaviour, IDisplayable
    {
        #region COMPONENT FIELD API

        private Animation _animation;

        #endregion

        private AnimationNameList _animationNames;
        
        private void Awake()
        {
            LogManager.LogProgress();

            _animation = GetComponent<Animation>();
            _animationNames = new AnimationNameList(_animation);
        }

        public void StartDisplaying()
        {
            LogManager.LogProgress();

            StartCoroutine(TurnOn());
        }

        public void StopDisplaying()
        {
            LogManager.LogProgress();

            StartCoroutine(TurnOff());
        }

        private IEnumerator TurnOn()
        {
            LogManager.LogProgress();

            _animation.Play(_animationNames[0]);
            while (_animation.isPlaying)
            {
                yield return null;
            }

            IsDisplaying = true;
        }

        private IEnumerator TurnOff()
        {
            LogManager.LogProgress();
            
            _animation.Play(_animationNames[1]);
            while (_animation.isPlaying)
            {
                yield return null;
            }

            IsDisplaying = false;
        }

        public bool IsDisplaying { get; private set; }
    }
}