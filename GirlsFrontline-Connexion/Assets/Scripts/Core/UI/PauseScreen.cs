using GloryDay.Debug;
using GloryDay.UI;
using UnityEngine;
using Core.Utility.Management;

namespace Core.UI
{
    public class PauseScreen : ScreenBase
    {
        private GameObject _screenObject;

        protected override void Awake()
        {
            Console.LogProgress();

            _screenObject = transform.GetChild(0).gameObject;
        }
        
        public override void TurnOn()
        {
            Console.LogProgress();
            
            _screenObject.SetActive(true);
            
            GameManager.OnApplicationPause();
        }
        
        public override void TurnOff()
        {
            Console.LogProgress();
            
            _screenObject.SetActive(false);
            
            GameManager.OnApplicationPlay();
        }
    }
}
