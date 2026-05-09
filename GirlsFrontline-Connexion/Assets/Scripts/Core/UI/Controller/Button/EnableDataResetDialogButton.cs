using GloryDay.Debug;
using UnityEngine;
using Core.Utility.Management;
using Sirenix.OdinInspector;

namespace Core.UI.Controller.Button
{
    public class EnableDataResetDialogButton : ButtonBase
    {
        #region SERIALIZED FIELD API

        [Title("Audio")]
        [SerializeField] private AudioClip openDialogSound;

        [Title("UI")]
        [SerializeField] private GameObject dialogObject;

        #endregion

        protected override void Click()
        {
            Console.LogMessage("<b>Enable Dialog Button</b> is clicked");

            base.Click();

            SoundManager.PlayEffectAudioSource(openDialogSound);

            dialogObject.SetActive(true);
        }
    }
}
