using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

using LabelType = Manager.Log.Label.LabelType;

namespace Manager.Resource
{
    public static class PrefabAssetLoader
    {
        private static AsyncOperationHandle<IList<GameObject>> _uiPrefabAssetHandle;

        /// <summary>
        /// Load UI prefab assets
        /// </summary>
        public static void OnLoadUIPrefabAssets()
        {
            LogManager.OnDebugLog(typeof(PrefabAssetLoader), 
                $"OnLoadUIPrefabAssets()");

            void Loaded(GameObject loadedGameObject)
            {
                UIManager.AddUIPrefabs(loadedGameObject);
                
                LogManager.OnDebugLog(LabelType.Event, typeof(PrefabAssetLoader),
                    $"<b>{loadedGameObject.name}</b> prefab is loaded");
            }
            
            _uiPrefabAssetHandle = Addressables.LoadAssetsAsync(DataManager.AddressableLabel.prefabs[0],
                (Action<GameObject>)Loaded);
        }
        
        /// <summary>
        /// Unload UI prefab assets
        /// </summary>
        public static void OnUnloadUIPrefabAssets()
        {
            LogManager.OnDebugLog(typeof(AudioAssetLoader), 
                $"OnUnloadUIPrefabAssets()");
            
            Addressables.Release(_uiPrefabAssetHandle);
            
            LogManager.OnDebugLog(LabelType.Event, typeof(AudioAssetLoader),
                $"<b>All UI prefabs</b> are unloaded");
        }
        
        /// <summary>
        /// Check UI prefab assets load is done
        /// </summary>
        public static bool IsUIPrefabAssetsLoaded() => _uiPrefabAssetHandle.IsDone;
    }
}
