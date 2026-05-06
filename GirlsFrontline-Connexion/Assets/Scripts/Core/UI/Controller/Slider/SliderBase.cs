using UnityEngine;
using GloryDay.Debug;

namespace GloryDay.UI.Controller.Slider
{
    public abstract class SliderBase : MonoBehaviour
    {
        #region COMPONENT FIELD API

        protected UnityEngine.UI.Slider Slider;

        #endregion

        protected virtual void Awake()
        {
            Console.LogProgress();
            
            Slider = GetComponent<UnityEngine.UI.Slider>();
            Slider.onValueChanged.AddListener(ValueChanged);
        }

        protected abstract void ValueChanged(float value);
    }
}
