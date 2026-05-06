using GloryDay.Animation;
using GloryDay.Debug;
using GloryDay.UI;
using UnityEngine;
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/ChapterRestartDialogScreen.cs
using Core.Utility.Manager;

namespace Core.UI
========
using Backend.Utility.Management;

namespace Backend.Object.UI
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/ChapterRestartDialogScreen.cs
{
    public class ChapterRestartDialogScreen : ScreenBase
    {
        #region COMPONENT FIELD API

        private Animation _animation;

        #endregion

        private AnimationNameList _animationNames;

        private AudioClip _openDialogSound;

        protected override void Awake()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/ChapterRestartDialogScreen.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/ChapterRestartDialogScreen.cs
            base.Awake();

            _animation = GetComponent<Animation>();
            _animationNames = new AnimationNameList(_animation);

            var key = DataManager.AudioData.Effect[2];
            _openDialogSound = ResourceManager.AudioClipResource.Effect[key];
        }

        public void Open()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/ChapterRestartDialogScreen.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/ChapterRestartDialogScreen.cs
            SoundManager.OnPlayEffectAudioSource(_openDialogSound);

            _animation.Play(_animationNames[0]);
        }
    }
}
