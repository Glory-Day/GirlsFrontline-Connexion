using GloryDay.Animations;
using GloryDay.Log;
using UnityEngine;

namespace UI
{
    public class StageClearAnimation : MonoBehaviour
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

        public void Play()
        {
            LogManager.LogProgress();

            _animation.Play(_animationNames[0]);
        }
    }
}