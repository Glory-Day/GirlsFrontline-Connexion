using JetBrains.Annotations;
using Utility.Manager.Data;
using Utility.Manager.Data.Converter;
using Utility.Manager.Data.Stream;
using Utility.Singleton;

namespace Utility.Manager
{
    [PublicAPI]
    public class DataManager : NotMonoBehavioural<DataManager>
    {
        private IDataConverter<SceneData[]> sceneDataConverter;
        private IDataConverter<PrefabData>  prefabDataConverter;
        private IDataStream<UserData>       userDataStream;

        private SceneData[] sceneData;
        private PrefabData  prefabData;
        private UserData    userData;
        
        private DataManager()
        {
            LogManager.LogProgress();

            sceneDataConverter = new SceneDataConverter();
            prefabDataConverter = new PrefabDataConverter();
            userDataStream = new UserDataStream();
        }
        
        private void SetSceneData()
        {
            LogManager.LogProgress();
            
            sceneData = sceneDataConverter.ToObject();
        }
        
        private void SetPrefabData()
        {
            LogManager.LogProgress();
            
            prefabData = prefabDataConverter.ToObject();
        }
        
        private void LoadUserData()
        {
            LogManager.LogProgress();
            
            userData = userDataStream.Load();
        }
        
        private void SaveUserData()
        {
            LogManager.LogProgress();
            
            userDataStream.Save(userData);
        }

        #region STATIC METHOD API
        
        /// <summary>
        /// Load all data for application
        /// </summary>
        public static void OnLoadAllData()
        {
            LogManager.LogProgress();
            LogManager.LogMessage("<b>All Data</b> is loading...");
            
            Instance.SetSceneData();
            Instance.SetPrefabData();
            Instance.LoadUserData();

            LogManager.LogSuccess("<b>All Data</b> is loaded");
        }
        
        /// <summary>
        /// Save current user data to file
        /// </summary>
        public static void OnSaveUserData()
        {
            LogManager.LogProgress();
            
            Instance.SaveUserData();
            
            LogManager.LogSuccess("<b>User Data</b> is saved");
        }

        #endregion

        #region STATIC PROPERTIES API

        public static SceneData[] SceneData => Instance.sceneData;
        public static PrefabData PrefabData => Instance.prefabData;
        public static UserData UserData => Instance.userData;

        #endregion
    }
}
