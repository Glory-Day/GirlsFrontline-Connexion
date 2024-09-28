using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using GloryDay.Log;

namespace Utility.Manager.Resource.Addressable
{
    public class UIResourceLoader : IResourceLoader
    {
        private AsyncOperationHandle<IList<GameObject>> _transitionScreenResourceHandle;
        private AsyncOperationHandle<IList<GameObject>> _optionScreenResourceHandle;
        private AsyncOperationHandle<IList<GameObject>> _pauseScreenResourceHandle;
        
        public void Load()
        {
            LogManager.LogProgress();
            
            _transitionScreenResourceHandle = Addressables.LoadAssetsAsync(
                AddressableLabelGroup.UI.TransitionScreen, (Action<GameObject>)LoadTransitionScreenResources);
            _optionScreenResourceHandle = Addressables.LoadAssetsAsync(
                AddressableLabelGroup.UI.OptionScreen, (Action<GameObject>)LoadOptionScreenResources);
            _pauseScreenResourceHandle = Addressables.LoadAssetsAsync(
                AddressableLabelGroup.UI.PauseScreen, (Action<GameObject>)LoadPauseScreenResources);
        }

        public void Unload()
        {
            LogManager.LogProgress();
            
            UnloadUIResources();
        }
        
        /// <summary>
        /// Load transition screen prefab assets using addressables
        /// </summary>
        /// <param name="resource"> Loaded assets </param>
        private static void LoadTransitionScreenResources(GameObject resource)
        {
            ResourceManager.UIResource.TransitionScreen = resource;

            LogManager.LogSuccess($"<b>{resource.name}</b> is loaded");
        }
        
        /// <summary>
        /// Load option screen prefab assets using addressables
        /// </summary>
        /// <param name="resource"> Loaded assets </param>
        private static void LoadOptionScreenResources(GameObject resource)
        {
            ResourceManager.UIResource.OptionScreen = resource;

            LogManager.LogSuccess($"<b>{resource.name}</b> is loaded");
        }
        
        /// <summary>
        /// Load pause screen prefab assets using addressables
        /// </summary>
        /// <param name="resource"> Loaded assets </param>
        private static void LoadPauseScreenResources(GameObject resource)
        {
            ResourceManager.UIResource.PauseScreen = resource;

            LogManager.LogSuccess($"<b>{resource.name}</b> is loaded");
        }

        /// <summary>
        /// Unload UI prefab assets using addressables
        /// </summary>
        private void UnloadUIResources()
        {
            LogManager.LogProgress();
            
            Addressables.Release(_transitionScreenResourceHandle);
            Addressables.Release(_optionScreenResourceHandle);
            Addressables.Release(_pauseScreenResourceHandle);

            LogManager.LogSuccess("<b>UI Prefabs</b> are unloaded");
        }
        
        public bool IsLoadedDone => IsTransitionScreenResourceLoadedDone &&
                                    IsOptionScreenResourceLoadedDone &&
                                    IsPauseScreenResourceLoadedDone;
        
        private bool IsTransitionScreenResourceLoadedDone => 
            _transitionScreenResourceHandle.IsValid() && _transitionScreenResourceHandle.IsDone;
        
        private bool IsOptionScreenResourceLoadedDone => 
            _optionScreenResourceHandle.IsValid() && _optionScreenResourceHandle.IsDone;
        
        private bool IsPauseScreenResourceLoadedDone => 
            _pauseScreenResourceHandle.IsValid() && _pauseScreenResourceHandle.IsDone;
    }
}