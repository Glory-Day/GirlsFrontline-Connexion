#region NAMESPACE API

using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace Manager.Resource
{
    public static class PrefabAssetLoader
    {
        private static AsyncOperationHandle<IList<GameObject>> _uiPrefabAssetHandle;

        #region LOAD ASSET API

        /// <summary>
        /// Load UI prefab assets using <b>DataManager.AddressableLabelData</b>
        /// </summary>
        public static void OnLoadUIPrefabAssets()
        {
            LogManager.OnDebugLog(typeof(PrefabAssetLoader), 
                $"OnLoadUIPrefabAssets()");

            void Loaded(GameObject loadedGameObject)
            {
                UIManager.AddUIPrefabs(loadedGameObject.name, loadedGameObject);
                
                LogManager.OnDebugLog(LabelType.Event, typeof(PrefabAssetLoader),
                    $"<b>{loadedGameObject.name}</b> is loaded");
            }
            
            _uiPrefabAssetHandle = Addressables.LoadAssetsAsync(DataManager.AddressableLabelData.prefabs[0],
                (Action<GameObject>)Loaded);
        }

        #endregion

        #region UNLOAD ASSET API
        
        /// <summary>
        /// Unload UI prefab assets using <b>DataManager.AddressableLabelData</b>
        /// </summary>
        public static void OnUnloadUIPrefabAssets()
        {
            LogManager.OnDebugLog(typeof(AudioAssetLoader), 
                $"OnUnloadUIPrefabAssets()");
            
            Addressables.Release(_uiPrefabAssetHandle);
            
            LogManager.OnDebugLog(LabelType.Event, typeof(AudioAssetLoader),
                $"<b>All UI prefabs</b> are unloaded");
        }

        #endregion

        /// <summary>
        /// Check all UI prefab assets loaded is done
        /// </summary>
        public static bool IsLoadedUIPrefabAssetsDone() => 
            _uiPrefabAssetHandle.IsValid() && _uiPrefabAssetHandle.IsDone;
    }
}
