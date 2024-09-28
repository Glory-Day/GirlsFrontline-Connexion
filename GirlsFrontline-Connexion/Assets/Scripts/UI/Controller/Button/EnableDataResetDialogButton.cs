using GloryDay.Log;
using GloryDay.UI.Controller.Button;
using UnityEngine;
using UnityEngine.Serialization;
using Utility.Manager;

namespace UI.Controller.Button
{
    public class EnableDataResetDialogButton : UIButtonBase
    {
        #region SERIALIZED FIELD API
        
        [SerializeField] private GameObject dialogObject;

        #endregion
        
        private AudioClip _openDialogSound;
        
        // Awake is called when the script instance is being loaded.
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();
            
            SetHoverSound(0);
            SetClickSound(1);

            var key = DataManager.AudioData.Effect[3];
            _openDialogSound = ResourceManager.AudioClipResource.Effect[key];
        }

        protected override void Click()
        {
            LogManager.LogMessage("<b>Enable Dialog Button</b> is clicked");
            
            base.Click();
            
            SoundManager.OnPlayEffectAudioSource(_openDialogSound);
            
            dialogObject.SetActive(true);
        }
    }
}