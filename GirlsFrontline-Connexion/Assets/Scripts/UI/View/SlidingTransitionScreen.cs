using GloryDay.Animations;
using GloryDay.Log;
using GloryDay.UI.View;
using UnityEngine;

namespace UI.View
{
    public class SlidingTransitionScreen : ScreenBase, ITransitionable
    {
        private Animation      _animation;
        private AnimationNames _animationNames;
        
        protected override void Start()
        {
            base.Start();

            _animation = GetComponentInChildren<Animation>();
            _animationNames = new AnimationNames(_animation);
        }

        public void Open()
        {
            LogManager.LogProgress();
            
            _animation.clip = _animation.GetClip(_animationNames[0]);
            _animation.Play();
        }

        public void Close()
        {
            _animation.clip = _animation.GetClip(_animationNames[1]);
            _animation.Play();
        }

        public bool IsOpening => _animation.isPlaying;
    }
}