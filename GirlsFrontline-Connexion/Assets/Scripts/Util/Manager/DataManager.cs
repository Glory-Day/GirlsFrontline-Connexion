using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using Util.Data;

namespace Util.Manager
{
    public class DataManager : Singleton<DataManager>
    {
        private GameData             gameData;
        private SceneData            sceneData;
        private AssetData            assetData;
        private AddressableLabelData addressableLabelData;
        
        private static T OnLoadData<T>(string fileName) where T : class
        {
            LogManager.LogProgress();

            T data;

            try
            {
                data = JsonUtility.FromJson<T>(File.ReadAllText(Application.persistentDataPath + fileName));

                LogManager.LogSuccess($"<b>{typeof(T).Name}</b> is loaded from <b>{typeof(T).Name}.json</b>");
            }
            catch (DirectoryNotFoundException error)
            {
                LogManager.LogError(error.Message);

                // Directory not found exception error
                return null;
            }

            return data;
        }
        
        #region LOAD DATA METHOD API

        private void LoadGameData()
        {
            LogManager.LogProgress();

            gameData = OnLoadData<GameData>(JsonFilePath.GameDataPath);
        }

        private void LoadSceneData()
        {
            LogManager.LogProgress();

            sceneData = OnLoadData<SceneData>(JsonFilePath.SceneDataPath);
        }

        private void LoadAssetData()
        {
            LogManager.LogProgress();

            assetData = OnLoadData<AssetData>(JsonFilePath.AssetDataPath);
        }

        private void LoadAddressableLabelData()
        {
            LogManager.LogProgress();

            addressableLabelData = OnLoadData<AddressableLabelData>(JsonFilePath.AddressableLabelDataPath);
        }

        #endregion

        #region STATIC METHOD API

        public static void OnLoadAllData()
        {
            LogManager.LogProgress();
            
            Instance.LoadGameData();
            Instance.LoadAddressableLabelData();
            Instance.LoadAssetData();
            Instance.LoadSceneData();

            LogManager.LogSuccess("<b>All Data</b> is loaded");
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
