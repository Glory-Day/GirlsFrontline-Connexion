using System;
using System.Collections;
using GloryDay.Animation;
using GloryDay.Debug.Log;
using GloryDay.UI;
using UnityEngine;
using Utility.Manager;

namespace UI
{
    public class TransitionScreen : ScreenBase, ITransitionable
    {
        #region COMPONENT FIELD API

        private Animation _animation;

        #endregion
        
        private AnimationNameList _animationNames;

        private AudioClip _openSound;
        private AudioClip _closeSound;
        
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();

            if (TryGetComponent(out _animation) == false)
            {
                _animation = GetComponentInChildren<Animation>();
            }
            
            _animationNames = new AnimationNameList(_animation);
        }

        public void Transition(int index, TransitionType type)
        {
            LogManager.LogProgress();
            
            StartCoroutine(Transitioning(index, type));
        }

        private IEnumerator Transitioning(int index, TransitionType type)
        {
            string openingAnimationName;
            string closingAnimationName;
            switch (type)
            {
                case TransitionType.Gate:
                    var key = DataManager.AudioData.Effect[4];
                    _openSound = ResourceManager.AudioClipResource.Effect[key];
                    
                    key = DataManager.AudioData.Effect[5];
                    _closeSound = ResourceManager.AudioClipResource.Effect[key];
                    
                    openingAnimationName = _animationNames[0];
                    closingAnimationName = _animationNames[1];
                    break;
                case TransitionType.Slide:
                    _openSound = null;
                    _closeSound = null;
                    
                    openingAnimationName = _animationNames[2];
                    closingAnimationName = _animationNames[3];
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
            
            SoundManager.OnPlayEffectAudioSource(_openSound);
            
            _animation.Play(closingAnimationName);
            while (_animation.isPlaying)
            {
                yield return null;
            }
            
            SceneManager.OnLoadSceneByIndex(index);
            while (SceneManager.IsSceneLoaded == false)
            {
                yield return null;
            }
            
            SoundManager.OnPlayEffectAudioSource(_closeSound);
            
            _animation.Play(openingAnimationName);
        }
    }
}