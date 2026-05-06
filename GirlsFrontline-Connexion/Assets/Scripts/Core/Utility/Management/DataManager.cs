using System.Collections.Generic;
using Backend.Utility.Management.Data;
using GloryDay.Data.File.Stream;
using GloryDay.Debug;
using GloryDay.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/DataManager.cs
using Core.Utility.Manager.Data;

namespace Core.Utility.Manager
========

namespace Backend.Utility.Management
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/DataManager.cs
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
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/DataManager.cs
            Console.LogProgress();
========
            LogManager.LogProgress();
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/DataManager.cs

            _saveFileStream = new SaveFileStream();
        }

        private void LoadAudioData()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/DataManager.cs
            Console.LogProgress();
========
            LogManager.LogProgress();
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/DataManager.cs

            var data = ResourceManager.TextResource.Data[nameof(AudioData)].text;
            _audioData = JsonConvert.DeserializeObject<AudioData>(data);
        }

        private void LoadUserData()
        {
            Console.LogProgress();

            // Create default user data file if save file isn't existed.
            if (_saveFileStream.IsSaveFileExisted == false)
            {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/DataManager.cs
                Console.LogMessage("Save file does not exist. Create default save file.");
========
                LogManager.LogMessage("Save file does not exist. Create default save file.");
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/DataManager.cs

                ResetUserData();
            }

            var data = _saveFileStream.Read();
            _userData = JsonConvert.DeserializeObject<UserData>(data);
        }

        private void SaveUserData()
        {
            Console.LogProgress();

            var data = JsonConvert.SerializeObject(_userData, Formatting.Indented, _settings);
            _saveFileStream.Write(data);
        }

        private void ResetUserData()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/DataManager.cs
            Console.LogProgress();

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
========
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
                Default = new Default { IsDisplayAllowed = new List<bool> { true, true, true, true } },
                Sound = new List<Sound>
                {
                    new Sound { IsMute = false, Volume = -30f },
                    new Sound { IsMute = false, Volume = -30f },
                    new Sound { IsMute = false, Volume = -30f }
                }
            };
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/DataManager.cs

            SaveUserData();
        }

        #region STATIC METHOD API

        /// <summary>
        /// Loads all data related to application running.
        /// </summary>
        public static void OnLoadAllData()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/DataManager.cs
            Console.LogProgress();
            Console.LogMessage("<b>All Data</b> is loading...");
========
            LogManager.LogProgress();
            LogManager.LogMessage("<b>All Data</b> is loading...");
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/DataManager.cs

            Instance.LoadAudioData();

            Console.LogSuccess("<b>All Data</b> is loaded");
        }

        /// <summary>
        /// Load user data stored in the local repository.
        /// </summary>
        public static void OnLoadUserData()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/DataManager.cs
            Console.LogProgress();

            Instance.LoadUserData();

            Console.LogSuccess("<b>User Data</b> is loaded");
========
            LogManager.LogProgress();

            Instance.LoadUserData();

            LogManager.LogSuccess("<b>User Data</b> is loaded");
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/DataManager.cs
        }

        /// <summary>
        /// Save the current user data stored in the application as a file.
        /// </summary>
        public static void OnSaveUserData()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/DataManager.cs
            Console.LogProgress();

            Instance.SaveUserData();

            Console.LogSuccess("<b>User Data</b> is saved");
========
            LogManager.LogProgress();

            Instance.SaveUserData();

            LogManager.LogSuccess("<b>User Data</b> is saved");
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/DataManager.cs
        }

        /// <summary>
        /// Reset the current user data stored in the application and save it in a local repository.
        /// </summary>
        public static void OnResetUserData()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/DataManager.cs
            Console.LogProgress();

            Instance.ResetUserData();

            Console.LogSuccess("<b>User Data</b> is reset");
========
            LogManager.LogProgress();

            Instance.ResetUserData();

            LogManager.LogSuccess("<b>User Data</b> is reset");
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/DataManager.cs
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
