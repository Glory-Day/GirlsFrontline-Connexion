using Manager.Data;
using Manager.Log;

namespace Manager.Resource
{
    public class ResourceManager : Singleton<ResourceManager>
    {
        protected ResourceManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }

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

        private static void InitializeAudioAssets()
        {
#if UNITY_EDITOR

            LogManager.OnDebugLog(
                typeof(ResourceManager), 
                $"Called InitializeAudioAssets()");

#endif
            
            AudioAssetLoader.OnLoadBackgroundAudioResources();
            
            //DEBUG: This code is not working yet
            // Resources with labels "effect" and "voice" are available after registration
            // AudioAssetLoader.OnLoadEffectAudioResources();
            // AudioAssetLoader.OnLoadVoiceAudioResources();
        }

        #region STATIC API
        
        

        #endregion
    }
}
