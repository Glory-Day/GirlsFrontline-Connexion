using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using GloryDay.Log;

namespace Utility.Manager.Resource.Addressable
{
    public class GameObjectResourceLoader : IResourceLoader
    {
        private AsyncOperationHandle<IList<GameObject>> _uiResourceHandle;

        public void Load()
        {
            LogManager.LogProgress();
            
            _uiResourceHandle = Addressables.LoadAssetsAsync(
                AddressableGroup.GameObject.UI, (Action<GameObject>)LoadUIResources);
        }

        public void Unload()
        {
            LogManager.LogProgress();
            
            UnloadUIResources();
        }
        
        /// <summary>
        /// Load UI prefab assets using addressables
        /// </summary>
        /// <param name="resource"> Loaded assets </param>
        private static void LoadUIResources(GameObject resource)
        {
            ResourceManager.GameObjectResource.UI.Add(resource.name, resource);

            LogManager.LogSuccess($"<b>{resource.name}</b> is loaded");
        }

        /// <summary>
        /// Unload UI prefab assets using addressables
        /// </summary>
        private void UnloadUIResources()
        {
            LogManager.LogProgress();

            Addressables.Release(_uiResourceHandle);

            LogManager.LogSuccess("<b>UI Prefabs</b> are unloaded");
        }
        
        public bool IsLoadedDone => _uiResourceHandle.IsValid() && _uiResourceHandle.IsDone;
    }
}
