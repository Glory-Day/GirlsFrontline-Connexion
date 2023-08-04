using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object.Manager;
using Util.Manager;
using Util.Log;

namespace Util.Asset
{
    public class PrefabAssetLoader
    {
        private AsyncOperationHandle<IList<GameObject>> uiPrefabAssetsHandle;
        
        public PrefabAssetLoader()
        {
            LogManager.LogCalled();
            
            uiPrefabAssetsHandle = new AsyncOperationHandle<IList<GameObject>>();
        }

        #region LOAD ASSET METHOD API
        
        public void LoadUIPrefabAssets()
        {
            LogManager.LogCalled();

            void Loaded(GameObject loadedGameObject)
            {
                UIManager.UIPrefabs.Add(loadedGameObject.name, loadedGameObject);

                LogManager.LogSuccess($"<b>{loadedGameObject.name}</b> is loaded");
            }

            uiPrefabAssetsHandle = Addressables.LoadAssetsAsync(DataManager.AddressableLabelData.prefabAsset.labels[0],
                (Action<GameObject>)Loaded);
        }

        #endregion

        #region UNLOAD ASSET METHOD API
        
        public void UnloadUIPrefabAssets()
        {
            LogManager.LogCalled();

            Addressables.Release(uiPrefabAssetsHandle);

            LogManager.LogSuccess("<b>All UI Prefabs</b> are unloaded");
        }

        #endregion

        #region CHECK ASSET METHOD API

        public bool IsLoadedUIPrefabAssetsDone()
        {
            return uiPrefabAssetsHandle.IsValid() && uiPrefabAssetsHandle.IsDone;
        }

        #endregion
    }
}
