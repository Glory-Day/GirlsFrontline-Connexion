#region NAMESPACE API

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace Manager.Asset
{
    /// <summary>
    /// Prefab asset loader with <see cref="Addressables"/>
    /// </summary>
    public class PrefabAssetLoader
    {
        private AsyncOperationHandle<IList<GameObject>> uiPrefabAssetsHandle;

        /// <summary>
        /// <see cref="PrefabAssetLoader"/> constructor
        /// </summary>
        public PrefabAssetLoader()
        {
            uiPrefabAssetsHandle = new AsyncOperationHandle<IList<GameObject>>();
        }

        #region LOAD ASSET API

        /// <summary>
        /// Load all UI prefab assets using label in <see cref="DataManager.AddressableLabelData"/>
        /// </summary>
        public void LoadUIPrefabAssets()
        {
            LogManager.OnDebugLog(
                typeof(PrefabAssetLoader),
                $"LoadUIPrefabAssets()");

            void Loaded(GameObject loadedGameObject)
            {
                UIManager.AddUIPrefabs(loadedGameObject.name, loadedGameObject);

                LogManager.OnDebugLog(
                    LabelType.Success, 
                    typeof(PrefabAssetLoader),
                    $"<b>{loadedGameObject.name}</b> is loaded successfully");
            }

            uiPrefabAssetsHandle = Addressables.LoadAssetsAsync(DataManager.AddressableLabelData.prefabAsset.labels[0],
                (Action<GameObject>)Loaded);
        }

        #endregion

        #region UNLOAD ASSET API

        /// <summary>
        /// Unload all UI prefab assets
        /// </summary>
        public void UnloadUIPrefabAssets()
        {
            LogManager.OnDebugLog(
                typeof(AudioAssetLoader),
                $"UnloadUIPrefabAssets()");

            Addressables.Release(uiPrefabAssetsHandle);

            LogManager.OnDebugLog(
                LabelType.Success, 
                typeof(AudioAssetLoader),
                $"<b>All UI Prefabs</b> are unloaded successfully");
        }

        #endregion

        /// <summary>
        /// Check all UI prefab assets loaded is done
        /// </summary>
        public bool IsLoadedUIPrefabAssetsDone()
        {
            return uiPrefabAssetsHandle.IsValid() && uiPrefabAssetsHandle.IsDone;
        }
    }
}
