using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Utility.Manager.Asset.Addressable
{
    public class PrefabAddressables : IAddressables
    {
        private struct AsyncOperationHandler
        {
            public AsyncOperationHandle<IList<GameObject>> ui;
        }

        private AsyncOperationHandler asyncOperationHandler;
        
        public PrefabAddressables()
        {
            LogManager.LogProgress();

            asyncOperationHandler = new AsyncOperationHandler();
        }

        public void Load()
        {
            LogManager.LogProgress();
            
            asyncOperationHandler.ui = Addressables.LoadAssetsAsync(AssetLabel.Prefab.UI,
                (Action<GameObject>)LoadUIPrefabs);
        }

        public void Unload()
        {
            LogManager.LogProgress();
            
            UnloadUIPrefabs();
        }

        public bool Check()
        {
            return asyncOperationHandler.ui.IsValid() && asyncOperationHandler.ui.IsDone;
        }
        
        /// <summary>
        /// Load UI prefab assets using addressables
        /// </summary>
        /// <param name="asset"> Loaded assets </param>
        private static void LoadUIPrefabs(GameObject asset)
        {
            AssetManager.PrefabReference.UI.Add(asset.name, asset);

            LogManager.LogSuccess($"<b>{asset.name}</b> is loaded");
        }

        /// <summary>
        /// Unload UI prefab assets using addressables
        /// </summary>
        private void UnloadUIPrefabs()
        {
            LogManager.LogProgress();

            Addressables.Release(asyncOperationHandler.ui);

            LogManager.LogSuccess("<b>All UI Prefabs</b> are unloaded");
        }
    }
}
