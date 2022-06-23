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
                $"Called InitializeAudioAssets()");

            Resource.AudioAssetLoader.OnLoadBackgroundAudioAssets();
            
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
                $"Called OnInitializeAudioAssets()");

            DataManager.OnInitializeAudioAddressableLabelData();
            
            InitializeAudioAssets();
        }

        public static bool IsAudioAssetsLoaded() => Resource.AudioAssetLoader.IsBackgroundAudioAssetsLoaded();

        //DEBUG: This code is not working yet
        // Resources with labels "effect" and "voice" are available after registration
        /*
        public static bool IsAudioAssetsLoaded() =>
            AudioAssetLoader.IsBackgroundAudioAssetsLoaded() &&
            AudioAssetLoader.IsEffectAudioAssetsLoaded() &&
            AudioAssetLoader.IsVoiceAudioAssetsLoaded();
        */

        #endregion

    }
}
