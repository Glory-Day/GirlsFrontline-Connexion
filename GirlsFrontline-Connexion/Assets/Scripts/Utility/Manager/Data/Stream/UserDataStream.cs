using System.IO;
using System.Text;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Utility.Manager.Data.Json;

namespace Utility.Manager.Data.Stream
{
    public class UserDataStream : IDataStream<UserData>
    {
        private static readonly string FullFilePath = Application.persistentDataPath + "/Data/Save.json";

        private readonly JsonSerializerSettings settings = 
            new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };

        /// <summary>
        /// Check user data file is existed
        /// </summary>
        private static bool IsExisted()
        {
            return File.Exists(FullFilePath);
        }
        
        public UserData Load()
        {
            LogManager.LogProgress();
            
            if (IsExisted() == false)
            {
                Save(new UserData());
            }

            UserData data;
            
            using (var reader = new StreamReader(FullFilePath))
            {
                var json = reader.ReadToEnd();
                data = JsonConvert.DeserializeObject<UserData>(json);
            }

            return data;
        }

        /// <summary>
        /// Save current user data to file
        /// </summary>
        /// <param name="userData"> User data to save </param>
        public void Save(UserData userData)
        {
            LogManager.LogProgress();
            
            using (var writer = new StreamWriter(FullFilePath,false, Encoding.UTF8))
            {
                var json = JsonConvert.SerializeObject(userData, Formatting.Indented, settings);
                writer.WriteLine(json);
            }
        }
    }
}
