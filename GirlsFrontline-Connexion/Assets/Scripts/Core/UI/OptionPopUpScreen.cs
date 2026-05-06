using GloryDay.Debug;
using GloryDay.UI;
using Core.UI.Controller.Toggle;
using UnityEngine.InputSystem;
using Core.Utility.Manager;

namespace Core.UI
{
    public class OptionPopUpScreen : PopUpScreenBase
    {
        protected override void Awake()
        {
            Console.LogProgress();
            
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
            Console.LogProgress();
            
            base.Start();
            
            ScreenObject.SetActive(false);
        }
        
        protected override void Toggle(InputAction.CallbackContext context)
        {
            Toggle();
        }

        public void Toggle()
        {
            Console.LogProgress();
            
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