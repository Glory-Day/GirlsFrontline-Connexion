using UnityEngine;
using Object.Manager;
using Util.Manager;
using Util.Log;

namespace Object.UI.Option.Controller.Master
{
    public class Slider : MonoBehaviour
    {
        #region COMPONENT FIELD API

        private UnityEngine.UI.Slider slider;

        #endregion

        #region CONSTANT FIELD API

        private const string ParameterName = "Master";

        #endregion

        // Start is called before the first frame update
        private void Start()
        {
            LogManager.OnDebugLog(
                Label.Called, 
                typeof(Slider), 
                "Start()");
            
            slider = GetComponent<UnityEngine.UI.Slider>();
        }

        public void OnValueChanged()
        {
            if (SoundManager.MasterAudioMixer == null)
            {
                return;
            }
            
            SoundManager.MasterAudioMixer.SetFloat(ParameterName,
                Mathf.Clamp(slider.value, slider.minValue, slider.maxValue));
        }
    }
}
