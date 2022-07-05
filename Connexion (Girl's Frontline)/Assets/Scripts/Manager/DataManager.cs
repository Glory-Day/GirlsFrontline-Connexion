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

        #region INITIALIZE API

        /// <summary>
        /// Initialize previously saved game data with <b>DataLoader</b> class
        /// </summary>
        private static void InitializeGameData()
        {
            LogManager.OnDebugLog(typeof(DataManager), 
                $"InitializeGameData()");

            GameData = DataLoader<Data.Category.GameData>.OnLoadData(JsonLocalPath.GameData);
        }

        /// <summary>
        /// Initialize Scene information data with <b>DataLoader</b> class
        /// </summary>
        private static void InitializeSceneInformationData()
        {
            LogManager.OnDebugLog(typeof(DataManager), 
                $"InitializeSceneInformationData()");

            SceneInformation = DataLoader<Data.Category.SceneInformation>.OnLoadData(
                JsonLocalPath.SceneInformation);
        }

        /// <summary>
        /// Initialize resource information data with <b>DataLoader</b> class
        /// </summary>
        private static void InitializeResourceInformationData()
        {
            LogManager.OnDebugLog(typeof(DataManager), 
                $"InitializeResourceInformationData()");

            ResourceInformation = DataLoader<Data.Category.ResourceInformation>.OnLoadData(
                JsonLocalPath.ResourceInformation);
        }

        /// <summary>
        /// Initialize addressable asset label data with <b>DataLoader</b> class
        /// </summary>
        private static void InitializeAddressableLabelData()
        {
            LogManager.OnDebugLog(typeof(DataManager), 
                $"InitializeAddressableLabelData()");

            AddressableLabel = DataLoader<Data.Category.AddressableLabel>.OnLoadData(
                JsonLocalPath.AddressableLabel);
        }

        #endregion

        /// <summary>
        /// Previously stored game data
        /// </summary>
        public static Data.Category.GameData GameData { get; private set; }
        
        /// <summary>
        /// Scene information data needed for loading scene
        /// </summary>
        public static Data.Category.SceneInformation SceneInformation { get; private set; }
        
        /// <summary>
        /// Resource information data needed for using key of resource
        /// </summary>
        public static Data.Category.ResourceInformation ResourceInformation { get; private set; }
        
        /// <summary>
        /// Label data to load assets using <b>Addressable</b>
        /// </summary>
        public static Data.Category.AddressableLabel AddressableLabel { get; private set; }

        /// <summary>
        /// Initialize all data related to running game programs
        /// </summary>
        public static void OnInitializeAllData()
        {
            LogManager.OnDebugLog(typeof(DataManager), 
                $"OnInitializeAllData()");
            
            InitializeGameData();
            InitializeAddressableLabelData();
            InitializeResourceInformationData();
            InitializeSceneInformationData();
        }
    }
}
