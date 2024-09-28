using GloryDay.Animations;
using GloryDay.Log;
using GloryDay.UI;
using UnityEngine;
using Utility.Manager;

namespace UI
{
    public class ChapterRestartDialogScreen : ScreenBase
    {
        #region COMPONENT FIELD API
        
        private Animation _animation;
        
        #endregion
        
        private AnimationNameList _animationNames;

        private AudioClip _openDialogSound;
        
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();
            
            _animation = GetComponent<Animation>();
            _animationNames = new AnimationNameList(_animation);

            var key = DataManager.AudioData.Effect[2];
            _openDialogSound = ResourceManager.AudioClipResource.Effect[key];
        }
        
        public void Open()
        {
            LogManager.LogProgress();
            
            SoundManager.OnPlayEffectAudioSource(_openDialogSound);
            
            _animation.Play(_animationNames[0]);
        }
    }
}