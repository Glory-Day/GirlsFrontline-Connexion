#region NAMESPACE API

using Manager.Data;
using Manager.Data.Category;
using Label = Manager.Log.Label;

#endregion

namespace Manager
{
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

        #region LOAD DATA METHOD API

        private void LoadGameData()
        {
            LogManager.OnDebugLog(
                typeof(DataManager),
                $"LoadGameData()");

            gameData = DataLoader.OnLoadData<GameData>(JsonFilePath.GameDataPath);
        }

        private void LoadSceneData()
        {
            LogManager.OnDebugLog(
                typeof(DataManager),
                $"LoadSceneData()");

            sceneData = DataLoader.OnLoadData<SceneData>(JsonFilePath.SceneDataPath);
        }

        private void LoadAssetData()
        {
            LogManager.OnDebugLog(
                typeof(DataManager),
                $"LoadAssetData()");

            assetData = DataLoader.OnLoadData<AssetData>(JsonFilePath.AssetDataPath);
        }

        private void LoadAddressableLabelData()
        {
            LogManager.OnDebugLog(
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
                typeof(DataManager),
                $"OnLoadAllData()");
            
            Instance.LoadGameData();
            Instance.LoadAddressableLabelData();
            Instance.LoadAssetData();
            Instance.LoadSceneData();

            LogManager.OnDebugLog(
                Label.Success, 
                typeof(DataManager),
                "<b>All Data</b> is loaded successfully");
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
