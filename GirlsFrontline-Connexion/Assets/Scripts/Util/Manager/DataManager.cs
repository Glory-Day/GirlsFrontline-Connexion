using Util.Manager.Data;
using Util.Manager.Data.Json;
using Util.Log;

namespace Util.Manager
{
    public class DataManager : Singleton<DataManager>
    {
        private GameData             gameData;
        private SceneData            sceneData;
        private AssetData            assetData;
        private AddressableLabelData addressableLabelData;
        
        #region LOAD DATA METHOD API

        private void LoadGameData()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(DataManager),
                $"LoadGameData()");

            gameData = DataLoader.OnLoadData<GameData>(JsonFilePath.GameDataPath);
        }

        private void LoadSceneData()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(DataManager),
                $"LoadSceneData()");

            sceneData = DataLoader.OnLoadData<SceneData>(JsonFilePath.SceneDataPath);
        }

        private void LoadAssetData()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(DataManager),
                $"LoadAssetData()");

            assetData = DataLoader.OnLoadData<AssetData>(JsonFilePath.AssetDataPath);
        }

        private void LoadAddressableLabelData()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(DataManager),
                $"LoadAddressableLabelData()");

            addressableLabelData = DataLoader.OnLoadData<AddressableLabelData>(
                JsonFilePath.AddressableLabelDataPath);
        }

        #endregion

        #region STATIC METHOD API

        public static void OnLoadAllData()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(DataManager),
                $"OnLoadAllData()");
            
            Instance.LoadGameData();
            Instance.LoadAddressableLabelData();
            Instance.LoadAssetData();
            Instance.LoadSceneData();

            LogManager.OnDebugLog(
                Label.Success, 
                typeof(DataManager),
                "<b>All Data</b> is loaded");
        }

        #endregion

        #region STATIC PROPERTIES API

        public static GameData GameData => Instance.gameData;

        public static SceneData SceneData => Instance.sceneData;

        public static AssetData AssetData => Instance.assetData;

        public static AddressableLabelData AddressableLabelData => Instance.addressableLabelData;

        #endregion
    }
}
