using GloryDay.Animation;
using GloryDay.Debug;
using GloryDay.UI;
using UnityEngine;
using Core.Utility.Manager;

namespace Core.UI
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
            Console.LogProgress();

            base.Awake();
            
            Animation = GetComponent<Animation>();
            _animationNames = new AnimationNameList(Animation);
            
            _backgroundImageObject = transform.GetChild(0).gameObject;
        }

        public virtual void Play()
        {
            Console.LogProgress();
            
            _backgroundImageObject.SetActive(true);
            
            SoundManager.OnPlayBackgroundAudioSource(BackgroundSound);
            
            Animation.Play(_animationNames[0]);
        }
    }
}