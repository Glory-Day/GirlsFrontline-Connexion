using System;
using System.Collections;
using GloryDay.Animation;
using GloryDay.Debug;
using TMPro;
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/VictoryResultScreen.cs
using Core.UI.Utility.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Core.Utility.Extension;
using Core.Utility.Manager;

using Console = GloryDay.Debug.Console;

namespace Core.UI
========
using Backend.Utility.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Backend.Utility.Extension;
using Backend.Utility.Management;

namespace Backend.Object.UI
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/VictoryResultScreen.cs
{
    public class VictoryResultScreen : StageResultScreen
    {
        #region COMPONENT FIELD API

        private readonly TMP_Text[] _pointTexts = new TMP_Text[3];

        private TMP_Text _totalPointText;

        private ResultRankDisplay _resultRankDisplay;

        #endregion

        private int _killCount;
        private int _time;
        private int _lifeCount;
        private int _score;

        private UIControls.VictoryResultActions _actions;

        private TransitionScreen _transitionScreen;

        private AudioClip _displayTextSound;

        protected override void Awake()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/VictoryResultScreen.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/VictoryResultScreen.cs
            base.Awake();

            _actions = new UIControls().VictoryResult;

            var child = transform.GetChild(4);
            _pointTexts[0] = child.GetChild(1).GetChild(3).GetComponent<TMP_Text>();
            _pointTexts[1] = child.GetChild(2).GetChild(3).GetComponent<TMP_Text>();
            _pointTexts[2] = child.GetChild(3).GetChild(3).GetComponent<TMP_Text>();
            _totalPointText = child.GetChild(4).GetChild(3).GetComponent<TMP_Text>();

            _resultRankDisplay = GetComponentInChildren<ResultRankDisplay>();

            _transitionScreen = FindObjectOfType<TransitionScreen>();

            var key = DataManager.AudioData.Background[9];
            BackgroundSound = ResourceManager.AudioClipResource.Background[key];

            key = DataManager.AudioData.Effect[7];
            _displayTextSound = ResourceManager.AudioClipResource.Effect[key];
        }

        private void OnEnable()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/VictoryResultScreen.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/VictoryResultScreen.cs
            _actions.ReturnToTitle.performed += ReturnToTitle;
        }

        private void OnDisable()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/VictoryResultScreen.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/VictoryResultScreen.cs
            _actions.Disable();
            _actions.ReturnToTitle.performed -= ReturnToTitle;
        }

        public void SetKillCount(int count)
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/VictoryResultScreen.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/VictoryResultScreen.cs
            _pointTexts[0].text = count.ToString();
        }

        public void SetTime(string time)
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/VictoryResultScreen.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/VictoryResultScreen.cs
            _pointTexts[1].text = time;
        }

        public void SetLifeCount(int count)
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/VictoryResultScreen.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/VictoryResultScreen.cs
            _lifeCount = count;
            _pointTexts[2].text = count.ToString();
        }

        public void SetChapterScore(int score)
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/VictoryResultScreen.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/VictoryResultScreen.cs
            _score = score;
            _totalPointText.text = score.ToString();
        }

        private void UnlockNextChapter()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/VictoryResultScreen.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/VictoryResultScreen.cs
            var index = SceneManager.CurrentSceneIndex - 3;
            if (index + 1 < 5)
            {
                DataManager.UserData.Chapter[index + 1].IsLocked = false;
            }
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/VictoryResultScreen.cs
            
            Console.LogSuccess("Next chapter is unlocked.");
========

            LogManager.LogSuccess("Next chapter is unlocked.");
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/VictoryResultScreen.cs
        }

        public override void Play()
        {
            Console.LogProgress();

            UnlockNextChapter();

            StartCoroutine(Playing());
        }

        private IEnumerator Playing()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/VictoryResultScreen.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/VictoryResultScreen.cs
            var total = _killCount * 2 + _time + _lifeCount * 5 + _score;
            var index = SceneManager.CurrentSceneIndex - 3;
            DataManager.UserData.Chapter[index].Score = total;
            DataManager.OnSaveUserData();

            _resultRankDisplay.SetRank(total);

            base.Play();
            while (Animation.isPlaying)
            {
                yield return null;
            }

            for (var i = _score + 1; i <= total; i++)
            {
                _totalPointText.text = i.ToString();

                yield return null;
            }

            _resultRankDisplay.Play();
            while (_resultRankDisplay.IsPlaying)
            {
                yield return null;
            }

            _actions.Enable();
        }

        private void ReturnToTitle(InputAction.CallbackContext context)
        {
            Console.LogProgress();

            ReturnToTitle();
        }

        private void ReturnToTitle()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/VictoryResultScreen.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/VictoryResultScreen.cs
            _transitionScreen.Transition(2, TransitionType.Gate);
        }

        public void PlayTextEffectSound()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/VictoryResultScreen.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/VictoryResultScreen.cs
            SoundManager.OnPlayEffectAudioSource(_displayTextSound);
        }
    }
}
