using UnityEngine;
using Object.Manager;
using Util.Manager;
using Util.Log;

namespace Object.UI.Option.Controller.Background
{
    public class Slider : MonoBehaviour
    {
        #region COMPONENT FIELD API

        private UnityEngine.UI.Slider slider;

        #endregion

        #region CONSTANT FIELD API

        private const string ParameterName = "Background";

        #endregion

        // Start is called before the first frame update
        private void Start()
        {
            LogManager.LogCalled();
            
            slider = GetComponent<UnityEngine.UI.Slider>();
        }

        public void OnValueChanged()
        {
            if (SoundManager.BackgroundAudioMixer == null)
            {
                return;
            }
            
            SoundManager.BackgroundAudioMixer.SetFloat(ParameterName,
                Mathf.Clamp(slider.value, slider.minValue, slider.maxValue));
        }
    }
}
