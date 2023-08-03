﻿#region NAMESPACE API

using UnityEngine;
using Object.Manager;
using Util.Manager;
using Util.Manager.Log;

#endregion

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
            LogManager.OnDebugLog(
                Label.Called, 
                typeof(Slider), 
                "Start()");
            
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