using GloryDay.Debug;
using GloryDay.UI;
using Core.UI.Controller.Toggle;
using UnityEngine.InputSystem;
using Core.Utility.Management;
using Core.Utility.Management.Resource;

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

            OpenPopUpSound = AssetManager.Asset.Audio.UI[AddressableAssetKeys.Assets_External_Audios_Effect_UI_Open_Pop_Up_Wav];
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
                SoundManager.PlayEffectAudioSource(OpenPopUpSound);

                ScreenObject.SetActive(true);

                GameManager.OnApplicationPause();
            }
        }

        public ToggleBase[] DisplayToggles { get; } = new ToggleBase[4];
    }
}
