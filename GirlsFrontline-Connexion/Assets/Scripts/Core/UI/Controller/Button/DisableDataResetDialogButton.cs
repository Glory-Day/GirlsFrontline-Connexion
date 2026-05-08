using GloryDay.Debug;
using UnityEngine;

namespace Core.UI.Controller.Button
{
    public class DisableDataResetDialogButton : ButtonBase
    {
        private GameObject _dialogObject;

        // Awake is called when the script instance is being loaded.
        protected override void Awake()
        {
            Console.LogProgress();

            base.Awake();

            _dialogObject = transform.parent.gameObject;
        }

        protected override void Click()
        {
            Console.LogMessage("<b>Disable Dialog Button</b> is clicked");

            base.Click();

            _dialogObject.SetActive(false);
        }
    }
}
