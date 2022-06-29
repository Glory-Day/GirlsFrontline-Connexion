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

        /// <summary>
        /// Initialize audio assets using <b>AudioAssetLoader</b> class
        /// </summary>
        private static void InitializeAudioAssets()
        {
            LogManager.OnDebugLog(typeof(ResourceManager), 
                $"InitializeAudioAssets()");
            
            Resource.AudioAssetLoader.OnLoadBackgroundAudioMixerAsset();
            Resource.AudioAssetLoader.OnLoadBackgroundAudioClipAssets();
            
            //DEBUG: This code is not working yet
            // Resources with labels "effect" and "voice" are available after registration
            /*
            AudioAssetLoader.OnLoadEffectAudioAssets();
            AudioAssetLoader.OnLoadVoiceAudioAssets();
            */
        }

        #region STATIC API
        
        /// <summary>
        /// Before initializing the audio assets, initialize the audio related label
        /// </summary>
        public static void OnInitializeAudioAssets()
        {
            LogManager.OnDebugLog(typeof(ResourceManager), 
                $"OnInitializeAudioAssets()");

            DataManager.OnInitializeAudioAddressableLabelData();
            
            InitializeAudioAssets();
        }

        /// <summary>
        /// Unload all the audio related assets
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

        public static bool IsAudioAssetsLoaded() =>
            Resource.AudioAssetLoader.IsBackgroundAudioMixerAssetLoaded() &&
            Resource.AudioAssetLoader.IsBackgroundAudioClipAssetsLoaded();

        //DEBUG: This code is not working yet
        // Resources with labels "effect" and "voice" are available after registration
        /*
        public static bool IsAudioAssetsLoaded() =>
            Resource.AudioAssetLoader.IsBackgroundAudioMixerAssetLoaded() &&
            Resource.AudioAssetLoader.IsBackgroundAudioClipAssetsLoaded() &&
            Resource.AudioAssetLoader.IsEffectAudioClipAssetsLoaded() &&
            Resource.AudioAssetLoader.IsVoiceAudioClipAssetsLoaded();
        */

        #endregion

    }
}
