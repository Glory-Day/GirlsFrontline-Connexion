using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using GloryDay.Debug;

using Console = GloryDay.Debug.Console;

namespace Core.Utility.Manager.Resource.Addressable
{
    public class TextResourceLoader : IResourceLoader
    {
        private AsyncOperationHandle<IList<UnityEngine.TextAsset>> _dataResourceHandle;
        
        public void Load()
        {
            Console.LogProgress();
            
            _dataResourceHandle = Addressables.LoadAssetsAsync(
                AddressableLabelGroup.Text.Data, (Action<UnityEngine.TextAsset>)LoadDataResources);
        }

        public void Unload()
        {
            Console.LogProgress();
            
            UnloadDataResources();
        }
        
        /// <summary>
        /// Load data assets using addressables
        /// </summary>
        /// <param name="resource"> Loaded asset </param>
        private static void LoadDataResources(UnityEngine.TextAsset resource)
        {
            Console.LogProgress();
            
            ResourceManager.TextResource.Data.Add(resource.name, resource);

            var name = string.Concat(
                resource.name.Select(ch => char.IsUpper(ch) ? " " + ch : ch.ToString())).Substring(1);
            
            Console.LogSuccess($"<b>{name}</b> is loaded");
        }
        
        /// <summary>
        /// Unload data assets using addressables
        /// </summary>
        private void UnloadDataResources()
        {
            Console.LogProgress();
            
            Addressables.Release(_dataResourceHandle);

            Console.LogSuccess("<b>All Data</b> are unloaded");
        }
        
        public bool IsLoadedDone => _dataResourceHandle.IsValid() && _dataResourceHandle.IsDone;
    }
}
