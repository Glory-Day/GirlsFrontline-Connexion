using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using GloryDay.Log;

namespace Utility.Manager.Resource.Addressable
{
    public class TextResourceLoader : IResourceLoader
    {
        private AsyncOperationHandle<IList<UnityEngine.TextAsset>> _dataResourceHandle;
        
        public void Load()
        {
            LogManager.LogProgress();
            
            _dataResourceHandle = Addressables.LoadAssetsAsync(
                AddressableGroup.Text.Data, (Action<UnityEngine.TextAsset>)LoadDataResources);
        }

        public void Unload()
        {
            LogManager.LogProgress();
            
            UnloadDataResources();
        }
        
        /// <summary>
        /// Load data assets using addressables
        /// </summary>
        /// <param name="resource"> Loaded asset </param>
        private static void LoadDataResources(UnityEngine.TextAsset resource)
        {
            LogManager.LogProgress();
            
            ResourceManager.TextResource.Data.Add(resource.name, resource);

            var name = string.Concat(
                resource.name.Select(ch => char.IsUpper(ch) ? " " + ch : ch.ToString())).Substring(1);
            
            LogManager.LogSuccess($"<b>{name}</b> is loaded");
        }
        
        /// <summary>
        /// Unload data assets using addressables
        /// </summary>
        private void UnloadDataResources()
        {
            LogManager.LogProgress();
            
            Addressables.Release(_dataResourceHandle);

            LogManager.LogSuccess("<b>All Data</b> are unloaded");
        }
        
        public bool IsLoadedDone => _dataResourceHandle.IsValid() && _dataResourceHandle.IsDone;
    }
}
