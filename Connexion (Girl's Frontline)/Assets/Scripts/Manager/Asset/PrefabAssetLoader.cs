#region NAMESPACE API

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Label = Manager.Log.Label;

#endregion

namespace Manager.Asset
{
    public class PrefabAssetLoader
    {
        private AsyncOperationHandle<IList<GameObject>> uiPrefabAssetsHandle;
        
        public PrefabAssetLoader()
        {
            LogManager.OnDebugLog(
                typeof(AudioAssetLoader),
                "PrefabAssetLoader()");
            
            uiPrefabAssetsHandle = new AsyncOperationHandle<IList<GameObject>>();
        }

        #region LOAD METHOD API
        
        public void LoadUIPrefabAssets()
        {
            LogManager.OnDebugLog(
                typeof(PrefabAssetLoader),
                $"LoadUIPrefabAssets()");

            void Loaded(GameObject loadedGameObject)
            {
                UIManager.UIPrefabs.Add(loadedGameObject.name, loadedGameObject);

                LogManager.OnDebugLog(
                    Label.Success, 
                    typeof(PrefabAssetLoader),
                    $"<b>{loadedGameObject.name}</b> is loaded successfully");
            }

            uiPrefabAssetsHandle = Addressables.LoadAssetsAsync(DataManager.AddressableLabelData.prefabAsset.labels[0],
                (Action<GameObject>)Loaded);
        }

        #endregion

        #region UNLOAD METHOD API
        
        public void UnloadUIPrefabAssets()
        {
            LogManager.OnDebugLog(
                typeof(AudioAssetLoader),
                $"UnloadUIPrefabAssets()");

            Addressables.Release(uiPrefabAssetsHandle);

            LogManager.OnDebugLog(
                Label.Success, 
                typeof(AudioAssetLoader),
                $"<b>All UI Prefabs</b> are unloaded successfully");
        }

        #endregion

        #region CHECK METHOD API

        public bool IsLoadedUIPrefabAssetsDone()
        {
            return uiPrefabAssetsHandle.IsValid() && uiPrefabAssetsHandle.IsDone;
        }

        #endregion
    }
}
