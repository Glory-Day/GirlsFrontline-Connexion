using System;
using System.Collections;
using GloryDay.Animation;
using GloryDay.Debug;
using TMPro;
using Core.UI.Utility.Input;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Core.Utility.Extension;
using Core.Utility.Management;

using Console = GloryDay.Debug.Console;
using Core.Utility.Management.Resource;

namespace Core.UI
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
            Console.LogProgress();
            
            base.Awake();

            _actions = new UIControls().VictoryResult;
            
            var child = transform.GetChild(4);
            _pointTexts[0] = child.GetChild(1).GetChild(3).GetComponent<TMP_Text>();
            _pointTexts[1] = child.GetChild(2).GetChild(3).GetComponent<TMP_Text>();
            _pointTexts[2] = child.GetChild(3).GetChild(3).GetComponent<TMP_Text>();
            _totalPointText = child.GetChild(4).GetChild(3).GetComponent<TMP_Text>();

            _resultRankDisplay = GetComponentInChildren<ResultRankDisplay>();
            
            _transitionScreen = FindObjectOfType<TransitionScreen>();

            BackgroundSound = ResourceManager.AudioClipResource.Background[AddressableAssetKeys.Assets_External_Audios_Background_Chapter_Victory_Background_Wav];
            
            _displayTextSound = ResourceManager.AudioClipResource.Effect[AddressableAssetKeys.Assets_External_Audios_Effect_UI_Display_Text_Wav];
        }

        private void OnEnable()
        {
            Console.LogProgress();
            
            _actions.ReturnToTitle.performed += ReturnToTitle;
        }

        private void OnDisable()
        {
            Console.LogProgress();
            
            _actions.Disable();
            _actions.ReturnToTitle.performed -= ReturnToTitle;
        }

        public void SetKillCount(int count)
        {
            Console.LogProgress();
            
            _pointTexts[0].text = count.ToString();
        }

        public void SetTime(string time)
        {
            Console.LogProgress();
            
            _pointTexts[1].text = time;
        }

        public void SetLifeCount(int count)
        {
            Console.LogProgress();
            
            _lifeCount = count;
            _pointTexts[2].text = count.ToString();
        }

        public void SetChapterScore(int score)
        {
            Console.LogProgress();
            
            _score = score;
            _totalPointText.text = score.ToString();
        }

        private void UnlockNextChapter()
        {
            Console.LogProgress();
            
            var index = SceneManager.CurrentSceneIndex - 3;
            if (index + 1 < 5)
            {
                DataManager.UserData.Chapter[index + 1].IsLocked = false;
            }
            
            Console.LogSuccess("Next chapter is unlocked.");
        }

        public override void Play()
        {
            Console.LogProgress();

            UnlockNextChapter();
            
            StartCoroutine(Playing());
        }

        private IEnumerator Playing()
        {
            Console.LogProgress();
            
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
            Console.LogProgress();
            
            _transitionScreen.Transition(2, TransitionType.Gate);
        }

        public void PlayTextEffectSound()
        {
            Console.LogProgress();
            
            SoundManager.PlayEffectAudioSource(_displayTextSound);
        }
    }
}
