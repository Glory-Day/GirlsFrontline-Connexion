using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Utility.Manager.Asset.Addressable
{
    public class TextAddressables : IAddressables
    {
        private struct AsyncOperationHandler
        {
            public AsyncOperationHandle<IList<UnityEngine.TextAsset>> data;
        }

        private AsyncOperationHandler asyncOperationHandler;

        public TextAddressables()
        {
            LogManager.LogProgress();
            
            asyncOperationHandler = new AsyncOperationHandler();
        }
        
        public void Load()
        {
            LogManager.LogProgress();
            
            asyncOperationHandler.data = Addressables.LoadAssetsAsync(AssetLabel.Text.Data,
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
        /// Load data assets using addressables
        /// </summary>
        /// <param name="asset"> Loaded asset </param>
        private static void LoadData(UnityEngine.TextAsset asset)
        {
            LogManager.LogProgress();
            
            AssetManager.TextAssets.Data.Add(asset.name, asset);

            LogManager.LogSuccess($"<b>{string.Concat(asset.name.Select(c => char.IsUpper(c) ? " " + c : c.ToString())).Substring(1)}</b> is loaded");
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
        
        /// <summary>
        /// Check data assets is loaded
        /// </summary>
        private bool IsDataLoadedDone => 
            asyncOperationHandler.data.IsValid() && asyncOperationHandler.data.IsDone;
    }
}
