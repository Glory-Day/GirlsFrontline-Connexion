using System;
using System.Collections;
using GloryDay.Animation;
using GloryDay.Debug;
using UnityEngine;
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/InformationDisplay.cs
using Core.Utility;

using Console = GloryDay.Debug.Console;

namespace Core.UI
========
using Backend.Utility;

namespace Backend.Object.UI
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/InformationDisplay.cs
{
    public class InformationDisplay : MonoBehaviour, IDisplayable
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

        public void StartDisplaying()
        {
            Console.LogProgress();

            StartCoroutine(TurnOn());
        }

        public void StopDisplaying()
        {
            Console.LogProgress();

            StartCoroutine(TurnOff());
        }

        private IEnumerator TurnOn()
        {
            Console.LogProgress();

            _animation.Play(_animationNames[0]);
            while (_animation.isPlaying)
            {
                yield return null;
            }

            IsDisplaying = true;
        }

        private IEnumerator TurnOff()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/InformationDisplay.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/InformationDisplay.cs
            _animation.Play(_animationNames[1]);
            while (_animation.isPlaying)
            {
                yield return null;
            }

            IsDisplaying = false;
        }

        public bool IsDisplaying { get; private set; }
    }
}
