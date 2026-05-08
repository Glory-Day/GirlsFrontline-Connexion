using Core.Utility.Management;
using GloryDay.Debug;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.UI.Controller.Button
{
    public abstract class ButtonBase : MonoBehaviour, IPointerEnterHandler
    {
        #region SERIALIZABLE FIELD API

        [Title("Audio")]
        [SerializeField] private AudioClip hoverSound;
        [SerializeField] private AudioClip clickSound;

        #endregion

        protected UnityEngine.UI.Button Button;

        protected virtual void Awake()
        {
            Console.LogProgress();

            Button = GetComponent<UnityEngine.UI.Button>();
            Button.onClick.AddListener(Click);
        }

        /// <summary>
        /// Invokes when a user clicks the button and releases it
        /// </summary>
        protected virtual void Click()
        {
            Console.LogProgress();

            SoundManager.OnPlayEffectAudioSource(clickSound);
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            Console.LogProgress();

            if (Button.IsActive() && Button.IsInteractable())
            {
                SoundManager.OnPlayEffectAudioSource(hoverSound);
            }
        }

        public UnityEngine.UI.Button.ButtonClickedEvent OnClick => Button.onClick;
    }
}
