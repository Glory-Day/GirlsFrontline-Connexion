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
        /// Initialize audio assets using <b>AudioAssetLoader</b> class
        /// </summary>
        public static void OnInitializeAudioAssets()
        {
            LogManager.OnDebugLog(typeof(ResourceManager), 
                $"InitializeAudioAssets()");
            
            SoundManager.OnInitializeAudioClips();
            
            Resource.AudioAssetLoader.OnLoadBackgroundAudioMixerAsset();
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
        public static void OnUnloadAudioAssets()
        {
            LogManager.OnDebugLog(typeof(ResourceManager), 
                $"OnUnloadAudioAssets()");
            
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
        /// Initialize prefab assets using <b>PrefabAssetLoader</b> class
        /// </summary>
        public static void OnInitializePrefabAssets()
        {
            LogManager.OnDebugLog(typeof(ResourceManager), 
                $"OnInitializePrefabAssets()");
            
            UIManager.OnInitializeUIPrefabs();
            
            Resource.PrefabAssetLoader.OnLoadUIPrefabAssets();
        }

        /// <summary>
        /// Unload all the prefab related assets using <b>PrefabAssetLoader</b> class
        /// </summary>
        public static void OnUnloadPrefabAssets()
        {
            LogManager.OnDebugLog(typeof(ResourceManager), 
                $"OnUnloadPrefabAssets()");
            
            Resource.PrefabAssetLoader.OnUnloadUIPrefabAssets();
        }

        /// <summary>
        /// Check prefab asset load is done
        /// </summary>
        private static bool IsPrefabAssetsLoaded() =>
            Resource.PrefabAssetLoader.IsUIPrefabAssetsLoaded();

        #endregion

        /// <summary>
        /// Check all asset resource load is done
        /// </summary>
        public static bool IsAllResourceLoaded() =>
            IsAudioAssetsLoaded() &&
            IsPrefabAssetsLoaded();
    }
}
