using System.Collections;
using GloryDay.Debug.Log;
using UI;
using UnityEngine;
using Utility.Data;

namespace Object.Map
{
    public class ChapterProgressHandler : MonoBehaviour
    {
        #region SERIALIZABLE FIELD API

        [SerializeField] private ChapterData chapterData;
        
        #endregion
        
        #region COMPONENT FIELD API

        private BackgroundAnimation _backgroundAnimation;

        private ChapterProgressTimer _progressTimer;
        private CharacterSpawner _spawner;
        
        #endregion

        private MainInterfaceScreen _mainInterfaceScreen;
        private VictoryResultScreen _victoryResultScreen;
        
        private void Awake()
        {
            LogManager.LogProgress();
            
            _mainInterfaceScreen = FindObjectOfType<MainInterfaceScreen>();
            _victoryResultScreen = FindObjectOfType<VictoryResultScreen>();
            
            _progressTimer = GetComponent<ChapterProgressTimer>();
            _progressTimer.OnProgressTimeTextChanged = _mainInterfaceScreen.DisplayChapterProgressTime;
            
            _spawner = GetComponent<CharacterSpawner>();
            _spawner.CreateCharacters(chapterData);
            
            // Initialize background image animation handler for chapter's background image animation.
            var child = transform.GetChild(6);
            _backgroundAnimation = child.GetComponent<BackgroundAnimation>();
        }

        private void Start()
        {
            LogManager.LogProgress();
            
            StartCoroutine(Progressing());
        }

        private IEnumerator Progressing()
        {
            _progressTimer.CountDown();
            
            _spawner.SpawnPlayerCharacter();
            while (_spawner.IsPlayerCharacterSpawning)
            {
                yield return null;
            }
            
            _backgroundAnimation.Play();
            
            _mainInterfaceScreen.InformationDisplayHandler.DisplayStageProgress();
            while (_mainInterfaceScreen.InformationDisplayHandler.IsDisplayingStageProgress)
            {
                yield return null;
            }
            
            _backgroundAnimation.Pause();
            
            _spawner.PlayerCharacterCache.EnablePlayerCharacterControls();
            _spawner.PlayerCharacterCache.SetWaitState();
            
            for (var i = 0; i < 5; i++)
            {
                var data = chapterData.StageData[i];
                _spawner.SpawnEnemyCharacters(data);
                while (_spawner.IsEnemyCharactersSpawning)
                {
                    yield return null;
                }
                
                _mainInterfaceScreen.DisplayClearState();

                _spawner.MovePlayerCharacter();
                while (_spawner.IsPlayerCharacterMoving)
                {
                    yield return null;
                }
                
                _backgroundAnimation.Play();
                
                _mainInterfaceScreen.InformationDisplayHandler.DisplayStageProgress();
                while (_mainInterfaceScreen.InformationDisplayHandler.IsDisplayingStageProgress)
                {
                    yield return null;
                }
                
                _backgroundAnimation.Pause();
                
                _spawner.PlayerCharacterCache.EnablePlayerCharacterControls();
                _spawner.PlayerCharacterCache.SetWaitState();
            }

            _spawner.MovePlayerCharacter();
            while (_spawner.IsPlayerCharacterMoving)
            {
                yield return null;
            }
            
            _spawner.PlayerCharacterCache.DisablePlayerCharacterControls();
            _spawner.PlayerCharacterCache.SetVictoryAnimation();
            
            _progressTimer.Stop();
            
            _mainInterfaceScreen.TurnOff();
            
            _victoryResultScreen.SetKillCount(_spawner.EnemyCharacterDeathCount);
            _victoryResultScreen.SetTime(_progressTimer.Text);
            _victoryResultScreen.SetLifeCount(_spawner.PlayerCharacterLifeCount);
            _victoryResultScreen.SetChapterScore(_spawner.ChapterScore);
            _victoryResultScreen.Play();
        }
    }
}