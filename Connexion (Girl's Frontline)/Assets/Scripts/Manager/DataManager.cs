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

        #region LOAD DATA API

        /// <summary>
        /// Load previously saved game data with <b>DataLoader</b> class
        /// </summary>
        private static void LoadGameData()
        {
            LogManager.OnDebugLog(typeof(DataManager), 
                $"LoadGameData()");

            GameData = DataLoader<Data.Category.GameData>.OnLoadData(JsonLocalPath.GameDataPath);
        }

        /// <summary>
        /// Load Scene information data with <b>DataLoader</b> class
        /// </summary>
        private static void LoadSceneData()
        {
            LogManager.OnDebugLog(typeof(DataManager), 
                $"LoadSceneInformationData()");

            SceneData = DataLoader<Data.Category.SceneData>.OnLoadData(
                JsonLocalPath.SceneDataPath);
        }

        /// <summary>
        /// Load resource information data with <b>DataLoader</b> class
        /// </summary>
        private static void LoadResourceData()
        {
            LogManager.OnDebugLog(typeof(DataManager), 
                $"LoadResourceInformationData()");

            ResourceData = DataLoader<Data.Category.ResourceData>.OnLoadData(
                JsonLocalPath.ResourceDataPath);
        }

        /// <summary>
        /// Load addressable asset label data with <b>DataLoader</b> class
        /// </summary>
        private static void LoadAddressableLabelData()
        {
            LogManager.OnDebugLog(typeof(DataManager), 
                $"LoadAddressableLabelData()");

            AddressableLabelData = DataLoader<Data.Category.AddressableLabelData>.OnLoadData(
                JsonLocalPath.AddressableLabelDataPath);
        }

        #endregion

        /// <summary>
        /// Previously stored game data
        /// </summary>
        public static Data.Category.GameData GameData { get; private set; }
        
        /// <summary>
        /// Scene information data needed for loading scene
        /// </summary>
        public static Data.Category.SceneData SceneData { get; private set; }
        
        /// <summary>
        /// Resource information data needed for using key of resource
        /// </summary>
        public static Data.Category.ResourceData ResourceData { get; private set; }
        
        /// <summary>
        /// Label data to load assets using <b>Addressable</b>
        /// </summary>
        public static Data.Category.AddressableLabelData AddressableLabelData { get; private set; }

        /// <summary>
        /// Initialize all data related to running game programs
        /// </summary>
        public static void OnInitializeAllData()
        {
            LogManager.OnDebugLog(typeof(DataManager), 
                $"OnInitializeAllData()");
            
            LoadGameData();
            LoadAddressableLabelData();
            LoadResourceData();
            LoadSceneData();
        }
    }
}
