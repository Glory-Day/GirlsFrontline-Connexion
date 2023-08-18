using JetBrains.Annotations;
using Utility.Manager.Data.Json;
using Utility.Manager.Data.Stream;

namespace Utility.Manager
{
    [PublicAPI]
    public class DataManager : Singleton<DataManager>
    {
        private IDataStream<AudioSourceData> audioSourceDataStream;
        private IDataStream<PrefabData>      prefabDataStream;
        private IDataStream<UserData>        userDataStream;

        private AudioSourceData audioSourceData;
        private PrefabData      prefabData;
        private UserData        userData;
        
        private DataManager()
        {
            LogManager.LogProgress();

            audioSourceDataStream = new AudioSourceDataStream();
            prefabDataStream = new PrefabDataStream();
            userDataStream = new UserDataStream();
        }
        
        private void LoadAudioSourceData()
        {
            LogManager.LogProgress();
            
            audioSourceData = audioSourceDataStream.Load();
        }
        
        private void LoadPrefabData()
        {
            LogManager.LogProgress();
            
            prefabData = prefabDataStream.Load();
        }
        
        private void LoadUserData()
        {
            LogManager.LogProgress();
            
            userData = userDataStream.Load();
        }
        
        private void SaveUserData()
        {
            LogManager.LogProgress();
            
            (userDataStream as UserDataStream)?.Save(userData);
        }

        #region STATIC METHOD API
        
        /// <summary>
        /// Load all data for application
        /// </summary>
        public static void OnLoadAllData()
        {
            LogManager.LogProgress();
            
            Instance.LoadAudioSourceData();
            Instance.LoadPrefabData();
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

        public static AudioSourceData AudioSourceData => Instance.audioSourceData;
        public static PrefabData PrefabData => Instance.prefabData;
        public static UserData UserData => Instance.userData;

        #endregion
    }
}
