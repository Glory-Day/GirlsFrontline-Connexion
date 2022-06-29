using Manager.Data;

namespace Manager
{
    /// <summary>
    /// Manager that manages the entire data used in the game
    /// </summary>
    public class DataManager : Singleton<DataManager>
    {
        protected DataManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }

        #region STATIC API

        #region SCENE INFORMATION DATA

        /// <summary>
        /// Scene information needed for loading scene
        /// </summary>
        public static Data.Category.SceneInformation SceneInformation { get; private set; }
        
        /// <summary>
        /// Initialize Scene information with <b>DataLoader</b> class
        /// </summary>
        public static void OnInitializeSceneInformationData()
        {
            LogManager.OnDebugLog(typeof(DataManager), 
                $"OnInitializeSceneInformationData()");

            SceneInformation = DataLoader<Data.Category.SceneInformation>.OnLoadData(
                JsonLocalPath.SceneName);
        }

        #endregion
        
        #region AUDIO ASSET DATA

        /// <summary>
        /// Label to load audio assets using <b>Addressable</b>
        /// </summary>
        public static Data.Category.AddressableLabel AudioAddressableLabel { get; private set; }
        
        /// <summary>
        /// Initialize audio assets addressable label with <b>DataLoader</b> class
        /// </summary>
        public static void OnInitializeAudioAddressableLabelData()
        {
            LogManager.OnDebugLog(typeof(DataManager), 
                $"OnInitializeAudioAddressableLabelData()");

            AudioAddressableLabel = DataLoader<Data.Category.AddressableLabel>.OnLoadData(
                JsonLocalPath.AddressableLabel);
            
            SoundManager.OnInitializeAudioClips();
        }

        #endregion

        #endregion

    }
}
