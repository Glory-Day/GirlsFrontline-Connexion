using System;
using System.Collections;
using GloryDay.Animation;
using GloryDay.Debug.Log;
using TMPro;
using UI.Utility.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Utility.Extension;
using Utility.Manager;

namespace UI
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
            LogManager.LogProgress();
            
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
            LogManager.LogProgress();
            
            _actions.ReturnToTitle.performed += ReturnToTitle;
        }

        private void OnDisable()
        {
            LogManager.LogProgress();
            
            _actions.Disable();
            _actions.ReturnToTitle.performed -= ReturnToTitle;
        }

        public void SetKillCount(int count)
        {
            LogManager.LogProgress();
            
            _pointTexts[0].text = count.ToString();
        }

        public void SetTime(string time)
        {
            LogManager.LogProgress();
            
            _pointTexts[1].text = time;
        }

        public void SetLifeCount(int count)
        {
            LogManager.LogProgress();
            
            _lifeCount = count;
            _pointTexts[2].text = count.ToString();
        }

        public void SetChapterScore(int score)
        {
            LogManager.LogProgress();
            
            _score = score;
            _totalPointText.text = score.ToString();
        }

        private void UnlockNextChapter()
        {
            LogManager.LogProgress();
            
            var index = SceneManager.CurrentSceneIndex - 3;
            if (index + 1 < 5)
            {
                DataManager.UserData.Chapter[index + 1].IsLocked = false;
            }
            
            LogManager.LogSuccess("Next chapter is unlocked.");
        }

        public override void Play()
        {
            LogManager.LogProgress();

            UnlockNextChapter();
            
            StartCoroutine(Playing());
        }

        private IEnumerator Playing()
        {
            LogManager.LogProgress();
            
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
            LogManager.LogProgress();

            ReturnToTitle();
        }

        private void ReturnToTitle()
        {
            LogManager.LogProgress();
            
            _transitionScreen.Transition(2, TransitionType.Gate);
        }

        public void PlayTextEffectSound()
        {
            LogManager.LogProgress();
            
            SoundManager.OnPlayEffectAudioSource(_displayTextSound);
        }
    }
}