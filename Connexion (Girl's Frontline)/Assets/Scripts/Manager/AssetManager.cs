using Manager.Asset;

namespace Manager
{
    /// <summary>
    /// Manager that manages <b>Asset</b> used in <b>Game Application</b>
    /// </summary>
    public class AssetManager : Singleton<AssetManager>
    {
        private AudioAssetLoader  audioAssetLoader;
        private PrefabAssetLoader prefabAssetLoader;

        protected AssetManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }

        /// <summary>
        /// Initialize <see cref="AudioAssetLoader"/> and <see cref="PrefabAssetLoader"/>
        /// </summary>
        private void InitializeAssetLoaders()
        {
            LogManager.OnDebugLog(typeof(AssetManager),
                $"InitializeAssetLoaders()");

            audioAssetLoader  = new AudioAssetLoader();
            prefabAssetLoader = new PrefabAssetLoader();
        }

        #region AUDIO ASSET API

        /// <summary>
        /// Load audio assets using <see cref="AudioAssetLoader"/>
        /// </summary>
        private void LoadAudioAssets()
        {
            LogManager.OnDebugLog(typeof(AssetManager),
                $"LoadAudioAssets()");

            SoundManager.OnInitializeComponents();
            SoundManager.OnInitializeAudioClips();

            audioAssetLoader.LoadMasterAudioMixerAsset();
            audioAssetLoader.LoadBackgroundAudioClipAssets();
        }
        
        //DEBUG: This code is not working yet
        // Resources with labels "effect" and "voice" are available after registration
        /*
        private void LoadAudioAssets()
        {
            LogManager.OnDebugLog(typeof(AssetManager),
                $"LoadAudioAssets()");

            SoundManager.OnInitializeComponents();
            SoundManager.OnInitializeAudioClips();

            audioAssetLoader.LoadMasterAudioMixerAsset();
            audioAssetLoader.LoadBackgroundAudioClipAssets();
            audioAssetLoader.LoadEffectAudioAssets();
            audioAssetLoader.LoadVoiceAudioAssets();
        }
        */
        
        /// <summary>
        /// Unload audio assets using <see cref="AudioAssetLoader"/>
        /// </summary>
        private void UnloadAudioAssets()
        {
            LogManager.OnDebugLog(typeof(AssetManager),
                $"UnloadAudioAssets()");

            audioAssetLoader.UnloadMasterAudioMixerAsset();
            audioAssetLoader.UnloadBackgroundAudioClipAssets();
        }
        
        //DEBUG: This code is not working yet
        // Resources with labels "effect" and "voice" are available after registration
        /*
        private void UnloadAudioAssets()
        {
            LogManager.OnDebugLog(typeof(AssetManager),
                $"UnloadAudioAssets()");

            audioAssetLoader.UnloadMasterAudioMixerAsset();
            audioAssetLoader.UnloadBackgroundAudioClipAssets();
            audioAssetLoader.UnloadEffectAudioClipAssets();
            audioAssetLoader.UnloadVoiceAudioClipAssets();
        }
        */
        
        /// <summary>
        /// Check audio assets loaded is done
        /// </summary>
        private bool IsLoadedAudioAssetsDone()
        {
            return audioAssetLoader.IsLoadedAudioMixerAssetDone() &&
                   audioAssetLoader.IsLoadedBackgroundAudioClipAssetsDone();
        }

        //DEBUG: This code is not working yet
        // Resources with labels "effect" and "voice" are available after registration
        /*
        private bool IsAudioAssetsLoaded()
        {
            return audioAssetLoader.IsBackgroundAudioMixerAssetLoaded() &&
                   audioAssetLoader.IsBackgroundAudioClipAssetsLoaded() &&
                   audioAssetLoader.IsEffectAudioClipAssetsLoaded() &&
                   audioAssetLoader.IsVoiceAudioClipAssetsLoaded();
        }
        */

        #endregion

        #region PREFAB ASSET API

        /// <summary>
        /// Load prefab assets using <see cref="PrefabAssetLoader"/>
        /// </summary>
        private void LoadPrefabAssets()
        {
            LogManager.OnDebugLog(typeof(AssetManager),
                $"LoadPrefabAssets()");

            UIManager.OnInitializeUIPrefabs();

            prefabAssetLoader.LoadUIPrefabAssets();
        }

        /// <summary>
        /// Unload prefab assets using <see cref="PrefabAssetLoader"/>
        /// </summary>
        private void UnloadPrefabAssets()
        {
            LogManager.OnDebugLog(typeof(AssetManager),
                $"UnloadPrefabAssets()");

            prefabAssetLoader.UnloadUIPrefabAssets();
        }

        /// <summary>
        /// Check prefab assets loaded is done
        /// </summary>
        private bool IsLoadedPrefabAssetsDone()
        {
            return prefabAssetLoader.IsLoadedUIPrefabAssetsDone();
        }

        #endregion

        /// <summary>
        /// Load all asset resources
        /// </summary>
        public static void OnLoadAllAssets()
        {
            LogManager.OnDebugLog(typeof(AssetManager),
                $"OnLoadAllAssets()");

            if (Instance.audioAssetLoader == null || Instance.prefabAssetLoader == null)
                Instance.InitializeAssetLoaders();

            Instance.LoadAudioAssets();
            Instance.LoadPrefabAssets();
        }

        /// <summary>
        /// Unload all asset resources
        /// </summary>
        public static void OnUnloadAllAssets()
        {
            LogManager.OnDebugLog(typeof(AssetManager),
                $"OnUnloadAllAssets()");

            Instance.UnloadAudioAssets();
            Instance.UnloadPrefabAssets();
        }

        /// <summary>
        /// Check all asset resources loaded is done
        /// </summary>
        public static bool IsLoadedAllAssetsDone()
        {
            return Instance.IsLoadedAudioAssetsDone() && Instance.IsLoadedPrefabAssetsDone();
        }
    }
}
