using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object.Manager;
using Util.Data.Addressable;
using Util.Manager;

namespace Util.Asset
{
    public class PrefabAssetLoader
    {
        private AsyncOperationHandle<IList<GameObject>> uiPrefabAssetsHandle;
        
        public PrefabAssetLoader()
        {
            LogManager.LogProgress();
            
            uiPrefabAssetsHandle = new AsyncOperationHandle<IList<GameObject>>();
        }
        
        public void LoadUIPrefabAssets()
        {
            LogManager.LogProgress();

            void Loaded(GameObject loadedGameObject)
            {
                UIManager.UIPrefabs.Add(loadedGameObject.name, loadedGameObject);

                LogManager.LogSuccess($"<b>{loadedGameObject.name}</b> is loaded");
            }

            uiPrefabAssetsHandle = Addressables.LoadAssetsAsync(DataManager.AddressableLabelData.prefabAsset.labels[0],
                (Action<GameObject>)Loaded);
        }
        
        public void UnloadUIPrefabAssets()
        {
            LogManager.LogProgress();

            Addressables.Release(uiPrefabAssetsHandle);

            LogManager.LogSuccess("<b>All UI Prefabs</b> are unloaded");
        }

        public bool IsLoadedUIPrefabAssetsDone()
        {
            return uiPrefabAssetsHandle.IsValid() && uiPrefabAssetsHandle.IsDone;
        }
    }
}
