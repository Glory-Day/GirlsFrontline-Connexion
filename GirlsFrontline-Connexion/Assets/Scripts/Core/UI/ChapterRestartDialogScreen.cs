using GloryDay.Animation;
using GloryDay.Debug;
using GloryDay.UI;
using UnityEngine;
using Core.Utility.Management;
using Core.Utility.Management.Resource;

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

            _openDialogSound = AssetManager.Asset.Audio.UI[AddressableAssetKeys.Assets_External_Audios_Effect_UI_Open_Dialog_Wav];
        }
        
        public void Open()
        {
            Console.LogProgress();
            
            SoundManager.PlayEffectAudioSource(_openDialogSound);
            
            _animation.Play(_animationNames[0]);
        }
    }
}
