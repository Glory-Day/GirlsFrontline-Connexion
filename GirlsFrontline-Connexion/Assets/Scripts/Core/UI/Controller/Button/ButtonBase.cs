using Core.Utility.Management;
using Core.Utility.Management.Resource;
using GloryDay.Debug;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.UI.Controller.Button
{
    public abstract class ButtonBase : MonoBehaviour, IPointerEnterHandler
    {
        protected AudioClip HoverSound;
        protected AudioClip ClickSound;

        protected UnityEngine.UI.Button Button;

        protected virtual void Awake()
        {
            Console.LogProgress();

            //TODO: You must fix it! Change audio clip resource to UI.
            HoverSound = ResourceManager.AudioClipResource.Effect[AddressableAssetKeys.Assets_External_Audios_Effect_UI_Hover_Button_Wav];
            ClickSound = ResourceManager.AudioClipResource.Effect[AddressableAssetKeys.Assets_External_Audios_Effect_UI_Click_Button_Wav];

            Button = GetComponent<UnityEngine.UI.Button>();
            Button.onClick.AddListener(Click);
        }

        /// <summary>
        /// Invokes when a user clicks the button and releases it
        /// </summary>
        protected virtual void Click()
        {
            Console.LogProgress();

            SoundManager.PlayEffectAudioSource(ClickSound);
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            Console.LogProgress();

            if (Button.IsActive() && Button.IsInteractable())
            {
                SoundManager.PlayEffectAudioSource(HoverSound);
            }
        }

        public UnityEngine.UI.Button.ButtonClickedEvent OnClick => Button.onClick;
    }
}
