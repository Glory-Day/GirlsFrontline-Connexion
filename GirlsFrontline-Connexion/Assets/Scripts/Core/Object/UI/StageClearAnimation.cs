using GloryDay.Animation;
using GloryDay.Debug;
using UnityEngine;

<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/StageClearAnimation.cs
namespace Core.UI
========
namespace Backend.Object.UI
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/StageClearAnimation.cs
{
    public class StageClearAnimation : MonoBehaviour
    {
        #region COMPONENT FIELD API

        private Animation _animation;

        #endregion

        private AnimationNameList _animationNames;

        private void Awake()
        {
            Console.LogProgress();

            _animation = GetComponent<Animation>();
            _animationNames = new AnimationNameList(_animation);
        }

        public void Play()
        {
            Console.LogProgress();

            _animation.Play(_animationNames[0]);
        }
    }
}
