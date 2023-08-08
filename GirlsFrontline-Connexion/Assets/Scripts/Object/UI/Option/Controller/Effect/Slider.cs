using UnityEngine;
using Object.Manager;
using Util.Manager;

namespace Object.UI.Option.Controller.Effect
{
    public class Slider : MonoBehaviour
    {
        #region COMPONENT FIELD API

        private UnityEngine.UI.Slider slider;

        #endregion

        #region CONSTANT FIELD API

        private const string ParameterName = "Effect";

        #endregion

        // Start is called before the first frame update
        private void Start()
        {
            LogManager.LogProgress();
            
            slider = GetComponent<UnityEngine.UI.Slider>();
        }

        public void OnValueChanged()
        {
            if (SoundManager.EffectAudioMixer == null)
            {
                return;
            }
            
            SoundManager.EffectAudioMixer.SetFloat(ParameterName,
                Mathf.Clamp(slider.value, slider.minValue, slider.maxValue));
        }
    }
}
