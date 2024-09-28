using GloryDay.Log;
using GloryDay.UI;
using UI.Controller.Toggle;
using UnityEngine.InputSystem;
using Utility.Manager;

namespace UI
{
    public class OptionPopUpScreen : PopUpScreenBase
    {
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();
            
            SetInputActionCallbackName(typeof(OptionPopUpScreen), "Toggle");
            SetInputAction("escape");

            DisplayToggles[0] = GetComponentInChildren<ChapterRankDisplayToggle>();
            DisplayToggles[1] = GetComponentInChildren<EnemyCountDisplayToggle>();
            DisplayToggles[2] = GetComponentInChildren<ElapsedTimeDisplayToggle>();
            DisplayToggles[3] = GetComponentInChildren<ChapterScoreDisplayToggle>();
            
            var key = DataManager.AudioData.Effect[2];
            var clip = ResourceManager.AudioClipResource.Effect[key];
            OpenPopUpSound = clip;
        }

        protected override void Start()
        {
            LogManager.LogProgress();
            
            base.Start();
            
            ScreenObject.SetActive(false);
        }
        
        protected override void Toggle(InputAction.CallbackContext context)
        {
            Toggle();
        }

        public void Toggle()
        {
            LogManager.LogProgress();
            
            if (ScreenObject.activeSelf)
            {
                ScreenObject.SetActive(false);
                
                GameManager.OnApplicationPlay();
            }
            else
            {
                SoundManager.OnPlayEffectAudioSource(OpenPopUpSound);
                
                ScreenObject.SetActive(true);
                
                GameManager.OnApplicationPause();
            }
        }

        public UIToggleBase[] DisplayToggles { get; } = new UIToggleBase[4];
    }
}