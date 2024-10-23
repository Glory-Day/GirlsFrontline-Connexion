using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using GloryDay;
using GloryDay.Debug.Log;
using UnityEngine;
using SceneManagement = UnityEngine.SceneManagement;

namespace Utility.Manager
{
    public class SceneManager : Singleton<SceneManager>
    {
        private readonly List<string> _sceneNames = new List<string>();

        private int _currentSceneIndex;
        
        /// <summary>
        /// To check the status of asynchronous scene load operations.
        /// </summary>
        private AsyncOperation _asyncOperation;
        
        private SceneManager()
        {
            LogManager.LogProgress();
            
            // Initialize the names of the built scenes.
            for (var i = 0; i < SceneManagement.SceneManager.sceneCountInBuildSettings; i++)
            {
                var scenePath = SceneManagement.SceneUtility.GetScenePathByBuildIndex(i);
                _sceneNames.Add(Path.GetFileNameWithoutExtension(scenePath));
            }

            _currentSceneIndex = 0;
        }

        private IEnumerator LoadingScene(string sceneName)
        {
            LogManager.LogProgress();
            LogManager.LogMessage($"{sceneName} is loading...");

            IsSceneLoaded = false;
            
            _asyncOperation = SceneManagement.SceneManager.LoadSceneAsync(sceneName);
            while (_asyncOperation?.isDone == false)
            {
                yield return null;
            }
            
            IsSceneLoaded = true;
            
            LogManager.LogSuccess($"<b>{sceneName}</b> is loaded");
        }

        private void LoadSceneByIndex(int index)
        {
            LogManager.LogProgress();
            
            try
            {
                _currentSceneIndex = index;
                
                var sceneName  = _sceneNames[_currentSceneIndex];
                var audioSourceName = DataManager.AudioData.Background[_currentSceneIndex];
                if (SoundManager.IsBackgroundAudioSourcePlaying(audioSourceName))
                {
                    StaticCoroutine.Start(LoadingScene(sceneName));
                }
                else
                {
                    SoundManager.OnStopBackgroundMusic();
                    
                    StaticCoroutine.Start(LoadingScene(sceneName));
                    
                    var clip = ResourceManager.AudioClipResource.Background[audioSourceName];
                    SoundManager.OnPlayBackgroundAudioSource(clip);
                }
            }
            catch (IndexOutOfRangeException exception)
            {
                LogManager.LogError(exception.Message);
            }
        }
        
        #region STATIC METHOD API

        /// <summary>
        /// Load the scene asynchronously by index.
        /// </summary>
        /// <param name="index"> Number of scene index. </param>
        public static void OnLoadSceneByIndex(int index) => Instance.LoadSceneByIndex(index);

        #endregion

        #region STATIC PROPERTIES API

        public static bool IsSceneLoaded { get; private set; }

        public static int CurrentSceneIndex => Instance._currentSceneIndex;

        #endregion
    }
}
