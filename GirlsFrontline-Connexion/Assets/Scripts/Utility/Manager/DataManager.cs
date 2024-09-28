using System.Collections.Generic;
using GloryDay.Data.File.Stream;
using GloryDay.Log;
using GloryDay.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Utility.Manager.Data;

namespace Utility.Manager
{
    public class DataManager : Singleton<DataManager>
    {
        private AudioData _audioData;
        private UserData _userData;
        
        private readonly SaveFileStream _saveFileStream;
        
        /// <summary>
        /// The setting that names the property with camel case when serializing the json file.
        /// </summary>
        private readonly JsonSerializerSettings _settings =
            new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
        
        private DataManager()
        {
            LogManager.LogProgress();
            
            _saveFileStream = new SaveFileStream();
        }
        
        private void LoadAudioData()
        {
            LogManager.LogProgress();
            
            var data = ResourceManager.TextResource.Data[nameof(AudioData)].text;
            _audioData = JsonConvert.DeserializeObject<AudioData>(data);
        }
        
        private void LoadUserData()
        {
            LogManager.LogProgress();

            // Create default user data file if save file isn't existed.
            if (_saveFileStream.IsSaveFileExisted == false)
            {
                LogManager.LogMessage("Save file does not exist. Create default save file.");
                
                ResetUserData();
            }

            var data = _saveFileStream.Read();
            _userData = JsonConvert.DeserializeObject<UserData>(data);
        }
        
        private void SaveUserData()
        {
            LogManager.LogProgress();

            var data = JsonConvert.SerializeObject(_userData, Formatting.Indented, _settings);
            _saveFileStream.Write(data);
        }

        private void ResetUserData()
        {
            LogManager.LogProgress();
            
            _userData = new UserData
                        {
                            Chapter = new List<Chapter>
                                      {
                                          new Chapter { IsLocked = false, Score = -1 }, 
                                          new Chapter { IsLocked = true, Score = -1 },
                                          new Chapter { IsLocked = true, Score = -1 },
                                          new Chapter { IsLocked = true, Score = -1 },
                                          new Chapter { IsLocked = true, Score = -1 }
                                      },
                            Default = new Default
                                      {
                                          IsDisplayAllowed = new List<bool> { true, true, true, true }
                                      },
                            Sound = new List<Sound>
                                    {
                                        new Sound { IsMute = false, Volume = -30f },
                                        new Sound { IsMute = false, Volume = -30f },
                                        new Sound { IsMute = false, Volume = -30f }
                                    }
                        };

            SaveUserData();
        }

        #region STATIC METHOD API
        
        /// <summary>
        /// Loads all data related to application running.
        /// </summary>
        public static void OnLoadAllData()
        {
            LogManager.LogProgress();
            LogManager.LogMessage("<b>All Data</b> is loading...");
            
            Instance.LoadAudioData();

            LogManager.LogSuccess("<b>All Data</b> is loaded");
        }

        /// <summary>
        /// Load user data stored in the local repository.
        /// </summary>
        public static void OnLoadUserData()
        {
            LogManager.LogProgress();
            
            Instance.LoadUserData();
            
            LogManager.LogSuccess("<b>User Data</b> is loaded");
        }
        
        /// <summary>
        /// Save the current user data stored in the application as a file.
        /// </summary>
        public static void OnSaveUserData()
        {
            LogManager.LogProgress();
            
            Instance.SaveUserData();
            
            LogManager.LogSuccess("<b>User Data</b> is saved");
        }

        /// <summary>
        /// Reset the current user data stored in the application and save it in a local repository.
        /// </summary>
        public static void OnResetUserData()
        {
            LogManager.LogProgress();
            
            Instance.ResetUserData();
            
            LogManager.LogSuccess("<b>User Data</b> is reset");
        }

        #endregion

        #region STATIC PROPERTIES API
        
        /// <summary>
        /// Data related to audio source.
        /// </summary>
        public static AudioData AudioData => Instance._audioData;
        
        /// <summary>
        /// Data related to user.
        /// </summary>
        public static UserData UserData => Instance._userData;

        #endregion
    }
}
