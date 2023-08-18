using UnityEngine;
using Object.Manager;
using Utility.Manager;

namespace Object.UI.Option.Controller.Voice
{
    public class Slider : MonoBehaviour
    {
        #region COMPONENT FIELD API

        private UnityEngine.UI.Slider slider;

        #endregion

        #region CONSTANT FIELD API

        private const string ParameterName = "Voice";

        #endregion

        // Start is called before the first frame update
        private void Start()
        {
            LogManager.LogProgress();
            
            slider = GetComponent<UnityEngine.UI.Slider>();
        }

        public void OnValueChanged()
        {
            SoundManager.VoiceAudioMixer.SetFloat(ParameterName,
                Mathf.Clamp(slider.value, slider.minValue, slider.maxValue));
        }
    }
}
