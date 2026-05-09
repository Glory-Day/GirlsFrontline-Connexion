using GloryDay.Debug;
using UnityEngine;

namespace Core.UI.Controller.Button
{
    public class DisableDataResetDialogButton : ButtonBase
    {
        private GameObject _dialogObject;

        public override void Initialize()
        {
            Console.LogProgress();

            base.Initialize();

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
