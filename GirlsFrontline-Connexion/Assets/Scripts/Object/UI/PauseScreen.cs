using GloryDay.Debug.Log;
using GloryDay.UI;
using UnityEngine;
using Backend.Utility.Management;

namespace Backend.Object.UI
{
    public class PauseScreen : ScreenBase
    {
        private GameObject _screenObject;

        protected override void Awake()
        {
            LogManager.LogProgress();

            _screenObject = transform.GetChild(0).gameObject;
        }

        public override void TurnOn()
        {
            LogManager.LogProgress();

            _screenObject.SetActive(true);

            ApplicationManager.Pause();
        }

        public override void TurnOff()
        {
            LogManager.LogProgress();

            _screenObject.SetActive(false);

            ApplicationManager.Play();
        }
    }
}
