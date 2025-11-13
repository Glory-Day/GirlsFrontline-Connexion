using GloryDay.Debug.Log;
using UnityEngine;

namespace GloryDay.UI.Controller.InputField
{
    public abstract class InputFieldBase : MonoBehaviour
    {
        #region COMPONENT API

        protected UnityEngine.UI.InputField InputField;

        #endregion

        protected void Awake()
        {
            LogManager.LogProgress();

            InputField = GetComponent<UnityEngine.UI.InputField>();
            InputField.onValueChanged.AddListener(ChangeValue);
        }

        protected abstract void ChangeValue(string value);
    }
}