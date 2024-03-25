using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using GloryDay.Log;
using GloryDay.Threading;
using GloryDay.Utility;
using UnityEngine;
using Utility.Manager.UI;
using SceneManagement = UnityEngine.SceneManagement;

namespace Utility.Manager
{
    public class SceneManager : Singleton<SceneManager>
    {
        private readonly List<string> _sceneNames;

        /// <summary>
        /// To check the status of asynchronous scene load operations.
        /// </summary>
        private AsyncOperation _asyncOperation;
        
        private SceneManager()
        {
            LogManager.LogProgress();
            
            _sceneNames = new List<string>();
            
            SetSceneNames();
        }

        /// <summary>
        /// Set the names of the built scenes.
        /// </summary>
        private void SetSceneNames()
        {
            LogManager.LogProgress();
            
            for (var i = 0; i < SceneManagement.SceneManager.sceneCountInBuildSettings; i++)
            {
                var scenePath = SceneManagement.SceneUtility.GetScenePathByBuildIndex(i);
                _sceneNames.Add(Path.GetFileNameWithoutExtension(scenePath));
            }
        }

        private IEnumerator LoadScene(string sceneName, TransitionMode mode)
        {
            LogManager.LogProgress();
            LogManager.LogMessage($"{sceneName} is loading...");
            
            var transition = UIManager.GetTransitionByMode(mode);
            
            transition?.Open();
            
            if (transition != null)
            {
                while (transition.IsOpening)
                {
                    yield return null;
                }
            }

            UIManager.OnEnableLoadingMessageScreen();
            
            _asyncOperation = SceneManagement.SceneManager.LoadSceneAsync(sceneName);
            while (_asyncOperation.isDone == false)
            {
                yield return null;
            }
            
            UIManager.OnDisableLoadingMessageScreen();
            
            transition?.Close();
            
            LogManager.LogSuccess($"<b>{sceneName}</b> is loaded");
        }

        private void LoadSceneByIndex(int index, TransitionMode mode)
        {
            LogManager.LogProgress();
            
            try
            {
                var sceneName  = _sceneNames[index];
                var backgroundMusicName = DataManager.SceneData[index].BackgroundMusic;
                if (SoundManager.IsBackgroundMusicPlaying(backgroundMusicName))
                {
                    StaticCoroutine.StartCoroutine(LoadScene(sceneName, mode));
                }
                else
                {
                    SoundManager.OnStopBackgroundMusic();
                    StaticCoroutine.StartCoroutine(LoadScene(sceneName, mode));
                    SoundManager.OnPlayBackgroundMusic(backgroundMusicName);
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
        /// <param name="mode"> Mode of how to transition the scene. </param>
        public static void OnLoadSceneByIndex(int index, TransitionMode mode) => 
            Instance.LoadSceneByIndex(index, mode);

        #endregion
    }
}
