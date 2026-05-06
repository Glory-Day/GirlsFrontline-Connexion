using GloryDay.Animation;
using GloryDay.Debug;
using GloryDay.UI;
using UnityEngine;
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/StageResultScreen.cs
using Core.Utility.Manager;

namespace Core.UI
========
using Backend.Utility.Management;

namespace Backend.Object.UI
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/StageResultScreen.cs
{
    public class StageResultScreen : ScreenBase
    {
        #region COMPONENT FIELD API

        protected Animation Animation;

        #endregion

        private AnimationNameList _animationNames;

        private GameObject _backgroundImageObject;

        protected AudioClip BackgroundSound;

        protected override void Awake()
        {
            Console.LogProgress();

            base.Awake();

            Animation = GetComponent<Animation>();
            _animationNames = new AnimationNameList(Animation);

            _backgroundImageObject = transform.GetChild(0).gameObject;
        }

        public virtual void Play()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/StageResultScreen.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/StageResultScreen.cs
            _backgroundImageObject.SetActive(true);

            SoundManager.OnPlayBackgroundAudioSource(BackgroundSound);

            Animation.Play(_animationNames[0]);
        }
    }
}
