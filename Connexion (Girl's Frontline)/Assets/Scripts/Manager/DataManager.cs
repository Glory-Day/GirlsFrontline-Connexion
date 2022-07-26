#region NAMESPACE API

using Manager.Data;
using Manager.Data.Category;
using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace Manager
{
    /// <summary>
    /// Manager that manages the entire data used in <b>Game Application</b>
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
        /// Load scene data with <b>DataLoader</b>
        /// </summary>
        private static void LoadSceneData()
        {
            LogManager.OnDebugLog(typeof(DataManager), 
                $"LoadSceneData()");

            SceneData = DataLoader<SceneData>.OnLoadData(JsonLocalPath.SceneDataPath);
        }

        /// <summary>
        /// Load resource data with <b>DataLoader</b>
        /// </summary>
        private static void LoadResourceData()
        {
            LogManager.OnDebugLog(typeof(DataManager), 
                $"LoadResourceData()");

            ResourceData = DataLoader<ResourceData>.OnLoadData(JsonLocalPath.ResourceDataPath);
        }

        /// <summary>
        /// Load addressable label data with <b>DataLoader</b>
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
        /// Scene data needed for loading scene
        /// </summary>
        public static SceneData SceneData { get; private set; }
        
        /// <summary>
        /// Resource data needed for using key of resource
        /// </summary>
        public static ResourceData ResourceData { get; private set; }
        
        /// <summary>
        /// Label data to load assets using <b>Addressable</b>
        /// </summary>
        public static AddressableLabelData AddressableLabelData { get; private set; }

        /// <summary>
        /// Load all data related to running <b>Game Application</b>
        /// </summary>
        public static void OnLoadAllData()
        {
            LogManager.OnDebugLog(typeof(DataManager), 
                $"OnLoadAllData()");
            
            LoadGameData();
            LoadAddressableLabelData();
            LoadResourceData();
            LoadSceneData();
            
            LogManager.OnDebugLog(LabelType.Success, typeof(DataManager), 
                "<b>All data</b> is loaded");
        }
    }
}
