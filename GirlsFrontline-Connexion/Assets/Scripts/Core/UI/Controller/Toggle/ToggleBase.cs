using Core.Utility.Management;
using Core.Utility.Management.Resource;
using GloryDay.Debug;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.UI.Controller.Toggle
{
    public abstract class ToggleBase : MonoBehaviour, IPointerEnterHandler
    {
        protected AudioClip HoverSound;
        protected AudioClip ClickSound;

        protected UnityEngine.UI.Toggle Toggle;

        public virtual void Initialize()
        {
            Console.LogProgress();

            //TODO: You must fix it! Change audio clip resource to UI.
            HoverSound = ResourceManager.AudioClipResource.Effect[AddressableAssetKeys.Assets_External_Audios_Effect_UI_Hover_Button_Wav];
            ClickSound = ResourceManager.AudioClipResource.Effect[AddressableAssetKeys.Assets_External_Audios_Effect_UI_Click_Button_Wav];

            Toggle = GetComponent<UnityEngine.UI.Toggle>();
            Toggle.onValueChanged.AddListener(ValueChanged);

            if (IsOn)
            {
                Toggle.Select();
            }
        }

        protected virtual void ValueChanged(bool value)
        {
            Console.LogProgress();

            SoundManager.PlayEffectAudioSource(ClickSound);
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            Console.LogProgress();

            if (Toggle.IsActive() && Toggle.IsInteractable())
            {
                SoundManager.PlayEffectAudioSource(HoverSound);
            }
        }

        public UnityEngine.UI.Toggle.ToggleEvent OnValueChanged => Toggle.onValueChanged;

        public bool IsOn
        {
            get => Toggle.isOn;
            set => Toggle.isOn = value;
        }
    }
}