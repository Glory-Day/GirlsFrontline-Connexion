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
        /// Scene information data needed for loading scene
        /// </summary>
        public static Data.Category.SceneInformation SceneInformation { get; private set; }
        
        /// <summary>
        /// Initialize Scene information data with <b>DataLoader</b> class
        /// </summary>
        public static void OnInitializeSceneInformationData()
        {
            LogManager.OnDebugLog(typeof(DataManager), 
                $"OnInitializeSceneInformationData()");

            SceneInformation = DataLoader<Data.Category.SceneInformation>.OnLoadData(
                JsonLocalPath.SceneInformation);
        }

        #endregion

        #region RESOURCE INFORMATION DATA

        /// <summary>
        /// Resource information data needed for using key of resource
        /// </summary>
        public static Data.Category.ResourceInformation ResourceInformation { get; private set; }
        
        /// <summary>
        /// Initialize resource information data with <b>DataLoader</b> class
        /// </summary>
        public static void OnInitializeResourceInformationData()
        {
            LogManager.OnDebugLog(typeof(DataManager), 
                $"OnInitializeResourceInformationData()");

            ResourceInformation = DataLoader<Data.Category.ResourceInformation>.OnLoadData(
                JsonLocalPath.ResourceInformation);
        }

        #endregion
        
        #region ADDRESSIBLE LABEL DATA

        /// <summary>
        /// Label data to load assets using <b>Addressable</b>
        /// </summary>
        public static Data.Category.AddressableLabel AddressableLabel { get; private set; }
        
        /// <summary>
        /// Initialize addressable asset label data with <b>DataLoader</b> class
        /// </summary>
        public static void OnInitializeAddressableLabelData()
        {
            LogManager.OnDebugLog(typeof(DataManager), 
                $"OnInitializeAddressableLabelData()");

            AddressableLabel = DataLoader<Data.Category.AddressableLabel>.OnLoadData(
                JsonLocalPath.AddressableLabel);
        }

        #endregion

        #endregion

    }
}
