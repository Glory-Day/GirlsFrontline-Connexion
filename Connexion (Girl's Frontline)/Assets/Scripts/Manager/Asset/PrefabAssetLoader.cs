﻿#region NAMESPACE API

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace Manager.Asset
{
    public class PrefabAssetLoader
    {
        private AsyncOperationHandle<IList<GameObject>> uiPrefabAssetHandle;

        public PrefabAssetLoader()
        {
            uiPrefabAssetHandle = new AsyncOperationHandle<IList<GameObject>>();
        }

        #region LOAD ASSET API

        /// <summary>
        /// Load UI prefab assets using <b>DataManager.AddressableLabelData</b>
        /// </summary>
        public void LoadUIPrefabAssets()
        {
            LogManager.OnDebugLog(typeof(PrefabAssetLoader),
                $"LoadUIPrefabAssets()");

            void Loaded(GameObject loadedGameObject)
            {
                UIManager.AddUIPrefabs(loadedGameObject.name, loadedGameObject);

                LogManager.OnDebugLog(LabelType.Success, typeof(PrefabAssetLoader),
                    $"<b>{loadedGameObject.name}</b> is loaded successfully");
            }

            uiPrefabAssetHandle = Addressables.LoadAssetsAsync(DataManager.AddressableLabelData.prefabAsset.names[0],
                (Action<GameObject>)Loaded);
        }

        #endregion

        #region UNLOAD ASSET API

        /// <summary>
        /// Unload UI prefab assets using <b>DataManager.AddressableLabelData</b>
        /// </summary>
        public void UnloadUIPrefabAssets()
        {
            LogManager.OnDebugLog(typeof(AudioAssetLoader),
                $"UnloadUIPrefabAssets()");

            Addressables.Release(uiPrefabAssetHandle);

            LogManager.OnDebugLog(LabelType.Success, typeof(AudioAssetLoader),
                $"<b>All UI Prefabs</b> are unloaded successfully");
        }

        #endregion

        /// <summary>
        /// Check all UI prefab assets loaded is done
        /// </summary>
        public bool IsLoadedUIPrefabAssetsDone()
        {
            return uiPrefabAssetHandle.IsValid() && uiPrefabAssetHandle.IsDone;
        }
    }
}