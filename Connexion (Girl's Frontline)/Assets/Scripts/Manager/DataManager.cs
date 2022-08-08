﻿#region NAMESPACE API

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

        private GameData             gameData;
        private SceneData            sceneData;
        private AssetData            assetData;
        private AddressableLabelData addressableLabelData;

        #region LOAD DATA API

        /// <summary>
        /// Load stored game data with <b>DataLoader</b>
        /// </summary>
        private void LoadGameData()
        {
            LogManager.OnDebugLog(typeof(DataManager),
                $"LoadGameData()");

            gameData = DataLoader.OnLoadData<GameData>(JsonPath.GameDataPath);
        }

        /// <summary>
        /// Load scene data with <b>DataLoader</b>
        /// </summary>
        private void LoadSceneData()
        {
            LogManager.OnDebugLog(typeof(DataManager),
                $"LoadSceneData()");

            sceneData = DataLoader.OnLoadData<SceneData>(JsonPath.SceneDataPath);
        }

        /// <summary>
        /// Load asset data with <b>DataLoader</b>
        /// </summary>
        private void LoadAssetData()
        {
            LogManager.OnDebugLog(typeof(DataManager),
                $"LoadAssetData()");

            assetData = DataLoader.OnLoadData<AssetData>(JsonPath.AssetDataPath);
        }

        /// <summary>
        /// Load addressable label data with <b>DataLoader</b>
        /// </summary>
        private void LoadAddressableLabelData()
        {
            LogManager.OnDebugLog(typeof(DataManager),
                $"LoadAddressableLabelData()");

            addressableLabelData = DataLoader.OnLoadData<AddressableLabelData>(
                JsonPath.AddressableLabelDataPath);
        }

        #endregion

        /// <summary>
        /// Load all data related to running <b>Game Application</b>
        /// </summary>
        public static void OnLoadAllData()
        {
            LogManager.OnDebugLog(typeof(DataManager),
                $"OnLoadAllData()");
            
            Instance.LoadGameData();
            Instance.LoadAddressableLabelData();
            Instance.LoadAssetData();
            Instance.LoadSceneData();

            LogManager.OnDebugLog(LabelType.Success, typeof(DataManager),
                "<b>All Data</b> is loaded successfully");
        }
        
        /// <summary>
        /// Stored game data
        /// </summary>
        public static GameData GameData => Instance.gameData;

        /// <summary>
        /// Scene data needed for loading scene
        /// </summary>
        public static SceneData SceneData => Instance.sceneData;

        /// <summary>
        /// Asset data needed for using key of resource
        /// </summary>
        public static AssetData AssetData => Instance.assetData;

        /// <summary>
        /// Label data to load assets using <b>Addressable</b>
        /// </summary>
        public static AddressableLabelData AddressableLabelData => Instance.addressableLabelData;
    }
}
