using System.Threading.Tasks;

using Manager.Data;
using Manager.Data.Category;

namespace Manager
{
    /// <summary>
    /// Manager that manages the entire data used in the game application
    /// </summary>
    public class DataManager : Singleton<DataManager>
    {
        protected DataManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }

        #region LOAD DATA API

        /// <summary>
        /// Load stored game data with <b>DataLoader</b>
        /// </summary>
        private static void LoadGameData()
        {
            LogManager.OnDebugLog(typeof(DataManager), 
                $"LoadGameData()");

            GameData = DataLoader<GameData>.OnLoadData(JsonLocalPath.GameDataPath);
        }

        /// <summary>
        /// Load Scene information data with <b>DataLoader</b>
        /// </summary>
        private static void LoadSceneData()
        {
            LogManager.OnDebugLog(typeof(DataManager), 
                $"LoadSceneData()");

            SceneData = DataLoader<SceneData>.OnLoadData(JsonLocalPath.SceneDataPath);
        }

        /// <summary>
        /// Load resource information data with <b>DataLoader</b>
        /// </summary>
        private static void LoadResourceData()
        {
            LogManager.OnDebugLog(typeof(DataManager), 
                $"LoadResourceData()");

            ResourceData = DataLoader<ResourceData>.OnLoadData(JsonLocalPath.ResourceDataPath);
        }

        /// <summary>
        /// Load addressable asset label data with <b>DataLoader</b>
        /// </summary>
        private static void LoadAddressableLabelData()
        {
            LogManager.OnDebugLog(typeof(DataManager), 
                $"LoadAddressableLabelData()");

            AddressableLabelData = DataLoader<AddressableLabelData>.OnLoadData(
                JsonLocalPath.AddressableLabelDataPath);
        }

        #endregion

        /// <summary>
        /// Stored game data
        /// </summary>
        public static GameData GameData { get; private set; }
        
        /// <summary>
        /// Scene information data needed for loading scene
        /// </summary>
        public static SceneData SceneData { get; private set; }
        
        /// <summary>
        /// Resource information data needed for using key of resource
        /// </summary>
        public static ResourceData ResourceData { get; private set; }
        
        /// <summary>
        /// Label data to load assets using <b>Addressable</b>
        /// </summary>
        public static AddressableLabelData AddressableLabelData { get; private set; }

        /// <summary>
        /// Load all data related to running game application
        /// </summary>
        public static void OnLoadAllData()
        {
            LogManager.OnDebugLog(typeof(DataManager), 
                $"OnLoadAllData()");
            
            LoadGameData();
            LoadAddressableLabelData();
            LoadResourceData();
            LoadSceneData();
        }
    }
}
