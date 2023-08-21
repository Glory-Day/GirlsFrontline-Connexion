using System;
using System.IO;
using System.Collections.Generic;
using JetBrains.Annotations;
using Object.Manager;
using Utility.Singleton;
using SceneManagement = UnityEngine.SceneManagement;

namespace Utility.Manager
{
    [PublicAPI]
    public class SceneManager : NotMonoBehavioural<SceneManager>
    {
        public List<string> sceneNames;
        
        private SceneManager()
        {
            LogManager.LogProgress();
            
            sceneNames = new List<string>();
            
            SetSceneNames();
        }

        private void SetSceneNames()
        {
            LogManager.LogProgress();
            
            for (var i = 0; i < SceneManagement.SceneManager.sceneCountInBuildSettings; i++)
            {
                var scenePath = SceneManagement.SceneUtility.GetScenePathByBuildIndex(i);
                sceneNames.Add(Path.GetFileNameWithoutExtension(scenePath));
            }
        }

        private void LoadNextScene()
        {
            LogManager.LogProgress();

            try
            {
                var sceneIndex = CurrentSceneIndex + 1;
                var sceneName  = sceneNames[sceneIndex];
                SceneManagement.SceneManager.LoadScene(sceneName);
                SoundManager.OnChangeBackgroundAudioClip(sceneIndex);
            
                LogManager.LogSuccess($"<b>{sceneName}</b> is loaded");
            }
            catch (IndexOutOfRangeException exception)
            {
                LogManager.LogError(exception.Message);
            }
        }

        private void LoadPreviewScene()
        {
            try
            {
                var sceneIndex = CurrentSceneIndex - 1;
                var sceneName  = sceneNames[sceneIndex];
                SceneManagement.SceneManager.LoadScene(sceneName);
                SoundManager.OnChangeBackgroundAudioClip(sceneIndex);
            
                LogManager.LogSuccess($"<b>{sceneName}</b> is loaded");
            }
            catch (IndexOutOfRangeException exception)
            {
                LogManager.LogError(exception.Message);
            }
        }
        
        private int CurrentSceneIndex => SceneManagement.SceneManager.GetActiveScene().buildIndex;
        
        #region STATIC METHOD API

        /// <summary>
        /// Load the current scene to next scene
        /// </summary>
        public static void OnLoadNextScene()
        {
            LogManager.LogProgress();
            
            Instance.LoadNextScene();
        }

        /// <summary>
        /// Load the current scene to preview scene
        /// </summary>
        public static void OnLoadPreviewScene()
        {
            LogManager.LogProgress();
            
            Instance.LoadPreviewScene();
        }

        #endregion
    }
}
