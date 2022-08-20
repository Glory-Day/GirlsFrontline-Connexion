﻿#region NAMESPACE API

using Manager.Data;
using Manager.Data.Category;
using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace Manager
{
    /// <summary>
    /// Manager that manages data used in <b>Game Application</b>
    /// </summary>
    public class DataManager : Singleton<DataManager>
    {
        private GameData             gameData;
        private SceneData            sceneData;
        private AssetData            assetData;
        private AddressableLabelData addressableLabelData;
        
        protected DataManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }

        #region LOAD DATA API

        /// <summary>
        /// Load stored game data with <see cref="DataLoader"/>
        /// </summary>
        private void LoadGameData()
        {
            LogManager.OnDebugLog(
                typeof(DataManager),
                $"LoadGameData()");

            gameData = DataLoader.OnLoadData<GameData>(JsonFilePath.GameDataPath);
        }

        /// <summary>
        /// Load scene data with <see cref="DataLoader"/>
        /// </summary>
        private void LoadSceneData()
        {
            LogManager.OnDebugLog(
                typeof(DataManager),
                $"LoadSceneData()");

            sceneData = DataLoader.OnLoadData<SceneData>(JsonFilePath.SceneDataPath);
        }

        /// <summary>
        /// Load asset data with <see cref="DataLoader"/>
        /// </summary>
        private void LoadAssetData()
        {
            LogManager.OnDebugLog(
                typeof(DataManager),
                $"LoadAssetData()");

            assetData = DataLoader.OnLoadData<AssetData>(JsonFilePath.AssetDataPath);
        }

        /// <summary>
        /// Load addressable label data with <see cref="DataLoader"/>
        /// </summary>
        private void LoadAddressableLabelData()
        {
            LogManager.OnDebugLog(
                typeof(DataManager),
                $"LoadAddressableLabelData()");

            addressableLabelData = DataLoader.OnLoadData<AddressableLabelData>(
                JsonFilePath.AddressableLabelDataPath);
        }

        #endregion

        /// <summary>
        /// Load all data related to running <b>Game Application</b>
        /// </summary>
        public static void OnLoadAllData()
        {
            LogManager.OnDebugLog(
                typeof(DataManager),
                $"OnLoadAllData()");
            
            Instance.LoadGameData();
            Instance.LoadAddressableLabelData();
            Instance.LoadAssetData();
            Instance.LoadSceneData();

            LogManager.OnDebugLog(
                LabelType.Success, 
                typeof(DataManager),
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
