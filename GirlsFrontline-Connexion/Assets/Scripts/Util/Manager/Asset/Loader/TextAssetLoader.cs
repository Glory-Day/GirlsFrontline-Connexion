using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Util.Manager.Asset.Loader
{
    public class TextAssetLoader : IAssetLoader
    {
        private struct AsyncOperationHandler
        {
            public AsyncOperationHandle<IList<UnityEngine.TextAsset>> data;
        }

        private AsyncOperationHandler asyncOperationHandler;

        public TextAssetLoader()
        {
            LogManager.LogProgress();
            
            asyncOperationHandler = new AsyncOperationHandler();
        }
        
        /// <summary>
        /// Load data assets using addressables
        /// </summary>
        /// <param name="asset"> Loaded asset </param>
        private static void LoadData(UnityEngine.TextAsset asset)
        {
            LogManager.LogProgress();
            
            AssetManager.TextAsset.Data.Add(asset.name.GetName(), asset);
            
            LogManager.LogSuccess($"<b>{asset.name}</b> is loaded");
        }
        
        /// <summary>
        /// Unload data assets using addressables
        /// </summary>
        private void UnloadData()
        {
            LogManager.LogProgress();
            
            Addressables.Release(asyncOperationHandler.data);

            LogManager.LogSuccess("<b>All Data</b> are unloaded");
        }
        
        public void Load()
        {
            LogManager.LogProgress();
            
            asyncOperationHandler.data = Addressables.LoadAssetsAsync(AddressablesLabel.Text.Data,
                (Action<UnityEngine.TextAsset>)LoadData);
        }

        public void Unload()
        {
            LogManager.LogProgress();
            
            UnloadData();
        }

        public bool Check()
        {
            return IsDataLoadedDone;
        }
        
        /// <summary>
        /// Check data assets is loaded
        /// </summary>
        private bool IsDataLoadedDone => 
            asyncOperationHandler.data.IsValid() && asyncOperationHandler.data.IsDone;
    }
}
