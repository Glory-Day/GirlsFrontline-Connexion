using GloryDay.Log;
using GloryDay.UI;
using UnityEngine;
using Utility.Manager;

namespace UI
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
            
            GameManager.OnApplicationPause();
        }
        
        public override void TurnOff()
        {
            LogManager.LogProgress();
            
            _screenObject.SetActive(false);
            
            GameManager.OnApplicationPlay();
        }
    }
}