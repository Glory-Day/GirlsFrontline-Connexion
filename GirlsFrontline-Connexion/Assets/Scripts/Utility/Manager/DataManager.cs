using JetBrains.Annotations;
using Utility.Manager.Data;
using Utility.Manager.Data.Converter;
using Utility.Manager.Data.Stream;

namespace Utility.Manager
{
    [PublicAPI]
    public class DataManager : Singleton<DataManager>
    {
        private IDataConverter<AudioClipData> audioSourceDataStream;
        private IDataConverter<PrefabData>      prefabDataStream;
        private IDataStream<UserData>        userDataStream;

        private AudioClipData audioClipData;
        private PrefabData      prefabData;
        private UserData        userData;
        
        private DataManager()
        {
            LogManager.LogProgress();

            audioSourceDataStream = new AudioSourceDataStream();
            prefabDataStream = new PrefabDataStream();
            userDataStream = new UserDataStream();
        }
        
        private void SetAudioClipData()
        {
            LogManager.LogProgress();
            
            audioClipData = audioSourceDataStream.ToObject();
        }
        
        private void SetPrefabData()
        {
            LogManager.LogProgress();
            
            prefabData = prefabDataStream.ToObject();
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
            
            Instance.SetAudioClipData();
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

        public static AudioClipData AudioClipData => Instance.audioClipData;
        public static PrefabData PrefabData => Instance.prefabData;
        public static UserData UserData => Instance.userData;

        #endregion
    }
}
