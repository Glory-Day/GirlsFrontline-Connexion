using GloryDay.Animations;
using GloryDay.Log;
using GloryDay.UI;
using UnityEngine;
using Utility.Manager;

namespace UI
{
    public class StageResultScreen : ScreenBase
    {
        #region COMPONENT FIELD API

        protected Animation Animation;

        #endregion

        private AnimationNameList _animationNames;
        
        private GameObject _backgroundImageObject;

        protected AudioClip BackgroundSound;
        
        protected override void Awake()
        {
            LogManager.LogProgress();

            base.Awake();
            
            Animation = GetComponent<Animation>();
            _animationNames = new AnimationNameList(Animation);
            
            _backgroundImageObject = transform.GetChild(0).gameObject;
        }

        public virtual void Play()
        {
            LogManager.LogProgress();
            
            _backgroundImageObject.SetActive(true);
            
            SoundManager.OnPlayBackgroundAudioSource(BackgroundSound);
            
            Animation.Play(_animationNames[0]);
        }
    }
}