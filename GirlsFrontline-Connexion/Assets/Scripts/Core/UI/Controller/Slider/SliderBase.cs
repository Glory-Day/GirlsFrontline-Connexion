using UnityEngine;
using GloryDay.Debug;

namespace GloryDay.UI.Controller.Slider
{
    public abstract class SliderBase : MonoBehaviour
    {
        protected UnityEngine.UI.Slider Slider;

        public virtual void Initialize()
        {
            Console.LogProgress();

            Slider = GetComponent<UnityEngine.UI.Slider>();
            Slider.onValueChanged.AddListener(ValueChanged);
        }

        protected abstract void ValueChanged(float value);
    }
}
