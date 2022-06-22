using Manager.Data;
using Manager.Log;

namespace Manager.Resource
{
    /// <summary>
    /// Class to manage resource needed for the game
    /// </summary>
    public class ResourceManager : Singleton<ResourceManager>
    {
        protected ResourceManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }

        /// <summary>
        /// Initialize audio assets
        /// </summary>
        private static void InitializeAudioAssets()
        {
#if UNITY_EDITOR

            LogManager.OnDebugLog(
                typeof(ResourceManager), 
                $"Called InitializeAudioAssets()");

#endif
            
            AudioAssetLoader.OnLoadBackgroundAudioAssets();
            
            //DEBUG: This code is not working yet
            // Resources with labels "effect" and "voice" are available after registration
            // AudioAssetLoader.OnLoadEffectAudioAssets();
            // AudioAssetLoader.OnLoadVoiceAudioAssets();
        }

        #region STATIC API
        
        /// <summary>
        /// After initializing the audio related label, the audio assets are initialized
        /// </summary>
        public static void OnInitializeAudioAssets()
        {
#if UNITY_EDITOR

            LogManager.OnDebugLog(
                typeof(ResourceManager), 
                $"Called OnInitializeAudioAssets()");

#endif
            
            DataManager.OnInitializeAudioLabelData();
            
            InitializeAudioAssets();
        }

        #endregion
    }
}
