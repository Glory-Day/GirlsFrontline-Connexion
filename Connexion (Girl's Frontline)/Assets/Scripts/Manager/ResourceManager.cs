namespace Manager
{
    /// <summary>
    /// Manager that manages the entire resources used in the game
    /// </summary>
    public class ResourceManager : Singleton<ResourceManager>
    {
        protected ResourceManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }
        
        #region AUDIO ASSET API
        
        /// <summary>
        /// Load audio assets using <b>AudioAssetLoader</b> class
        /// </summary>
        private static void LoadAudioAssets()
        {
            LogManager.OnDebugLog(typeof(ResourceManager), 
                $"LoadAudioAssets()");
            
            SoundManager.OnInitializeAudioClips();
            
            Resource.AudioAssetLoader.OnLoadAudioMixerAssets();
            Resource.AudioAssetLoader.OnLoadBackgroundAudioClipAssets();
            
            //DEBUG: This code is not working yet
            // Resources with labels "effect" and "voice" are available after registration
            /*
            AudioAssetLoader.OnLoadEffectAudioAssets();
            AudioAssetLoader.OnLoadVoiceAudioAssets();
            */
        }

        /// <summary>
        /// Unload all the audio related assets using <b>AudioAssetLoader</b> class
        /// </summary>
        private static void UnloadAudioAssets()
        {
            LogManager.OnDebugLog(typeof(ResourceManager), 
                $"UnloadAudioAssets()");
            
            Resource.AudioAssetLoader.OnUnloadBackgroundAudioMixerAsset();
            Resource.AudioAssetLoader.OnUnloadBackgroundAudioClipAssets();
            
            //DEBUG: This code is not working yet
            // Resources with labels "effect" and "voice" are available after registration
            /*
            Resource.AudioAssetLoader.OnUnloadEffectAudioClipAssets();
            Resource.AudioAssetLoader.OnUnloadVoiceAudioClipAssets();
            */
        }

        /// <summary>
        /// Check audio asset load is done
        /// </summary>
        private static bool IsAudioAssetsLoaded() =>
            Resource.AudioAssetLoader.IsBackgroundAudioMixerAssetLoaded() &&
            Resource.AudioAssetLoader.IsBackgroundAudioClipAssetsLoaded();

        //DEBUG: This code is not working yet
        // Resources with labels "effect" and "voice" are available after registration
        /*
        private static bool IsAudioAssetsLoaded() =>
            Resource.AudioAssetLoader.IsBackgroundAudioMixerAssetLoaded() &&
            Resource.AudioAssetLoader.IsBackgroundAudioClipAssetsLoaded() &&
            Resource.AudioAssetLoader.IsEffectAudioClipAssetsLoaded() &&
            Resource.AudioAssetLoader.IsVoiceAudioClipAssetsLoaded();
        */

        #endregion

        #region PREFAB ASSET API

        /// <summary>
        /// Load prefab assets using <b>PrefabAssetLoader</b> class
        /// </summary>
        private static void LoadPrefabAssets()
        {
            LogManager.OnDebugLog(typeof(ResourceManager), 
                $"LoadPrefabAssets()");
            
            UIManager.OnInitializeUIPrefabs();
            
            Resource.PrefabAssetLoader.OnLoadUIPrefabAssets();
        }

        /// <summary>
        /// Unload all the prefab related assets using <b>PrefabAssetLoader</b> class
        /// </summary>
        private static void UnloadPrefabAssets()
        {
            LogManager.OnDebugLog(typeof(ResourceManager), 
                $"UnloadPrefabAssets()");
            
            Resource.PrefabAssetLoader.OnUnloadUIPrefabAssets();
        }

        /// <summary>
        /// Check prefab asset load is done
        /// </summary>
        private static bool IsPrefabAssetsLoaded() =>
            Resource.PrefabAssetLoader.IsUIPrefabAssetsLoaded();

        #endregion

        /// <summary>
        /// Load all asset resources
        /// </summary>
        public static void OnLoadAllResources()
        {
            LogManager.OnDebugLog(typeof(ResourceManager), 
                $"OnLoadAllResources()");
            
            LoadAudioAssets();
            LoadPrefabAssets();
        }

        /// <summary>
        /// Unload all asset resources
        /// </summary>
        public static void OnUnloadAllResources()
        {
            LogManager.OnDebugLog(typeof(ResourceManager), 
                $"OnUnloadAllResources()");
            
            UnloadAudioAssets();
            UnloadPrefabAssets();
        }

        /// <summary>
        /// Check all asset resource load is done
        /// </summary>
        public static bool IsAllResourceLoaded() =>
            IsAudioAssetsLoaded() &&
            IsPrefabAssetsLoaded();
    }
}
