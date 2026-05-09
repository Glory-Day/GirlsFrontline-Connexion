using System.Collections.Generic;
using GloryDay.Data.File.Stream;
using GloryDay.Debug;
using GloryDay.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Core.Utility.Management.Data;

namespace Core.Utility.Management
{
    public class DataManager : Singleton<DataManager>
    {
        private UserData _userData;

        private readonly SaveFileStream _saveFileStream;

        /// <summary>
        /// The setting that names the property with camel case when serializing the json file.
        /// </summary>
        private readonly JsonSerializerSettings _settings =
            new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };

        private DataManager()
        {
            Console.LogProgress();

            _saveFileStream = new SaveFileStream();
        }

        private void LoadUserData_Internal()
        {
            Console.LogProgress();

            // Create default user data file if save file isn't existed.
            if (_saveFileStream.IsSaveFileExisted == false)
            {
                Console.LogMessage("Save file does not exist. Create default save file.");

                ResetUserData_Internal();
            }

            var data = _saveFileStream.Read();
            _userData = JsonConvert.DeserializeObject<UserData>(data);
        }

        private void SaveUserData_Internal()
        {
            Console.LogProgress();

            var data = JsonConvert.SerializeObject(_userData, Formatting.Indented, _settings);
            _saveFileStream.Write(data);
        }

        private void ResetUserData_Internal()
        {
            Console.LogProgress();

            _userData = new UserData
            {
                Chapter = new List<Chapter>
                {
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

            SaveUserData_Internal();
        }

        #region STATIC METHOD API

        /// <summary>
        /// Load user data stored in the local repository.
        /// </summary>
        public static void OnLoadUserData()
        {
            Console.LogProgress();

            Instance.LoadUserData_Internal();

            Console.LogSuccess("<b>User Data</b> is loaded");
        }

        /// <summary>
        /// Save the current user data stored in the application as a file.
        /// </summary>
        public static void OnSaveUserData()
        {
            Console.LogProgress();

            Instance.SaveUserData_Internal();

            Console.LogSuccess("<b>User Data</b> is saved");
        }

        /// <summary>
        /// Reset the current user data stored in the application and save it in a local repository.
        /// </summary>
        public static void OnResetUserData()
        {
            Console.LogProgress();

            Instance.ResetUserData_Internal();

            Console.LogSuccess("<b>User Data</b> is reset");
        }

        #endregion

        #region STATIC PROPERTIES API

        /// <summary>
        /// Data related to user.
        /// </summary>
        public static UserData UserData => Instance._userData;

        #endregion
    }
}
