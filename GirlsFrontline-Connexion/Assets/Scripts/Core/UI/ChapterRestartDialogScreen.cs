using GloryDay.Animation;
using GloryDay.Debug;
using GloryDay.UI;
using UnityEngine;
using Core.Utility.Management;

namespace Core.UI
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
            Console.LogProgress();
            
            base.Awake();
            
            _animation = GetComponent<Animation>();
            _animationNames = new AnimationNameList(_animation);

            var key = DataManager.AudioData.Effect[2];
            _openDialogSound = ResourceManager.AudioClipResource.Effect[key];
        }
        
        public void Open()
        {
            Console.LogProgress();
            
            SoundManager.OnPlayEffectAudioSource(_openDialogSound);
            
            _animation.Play(_animationNames[0]);
        }
    }
}
