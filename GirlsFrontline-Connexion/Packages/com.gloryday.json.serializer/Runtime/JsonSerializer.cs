using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace GloryDay.Json.Serialization
{
    public static class JsonSerializer
    {
        private static readonly JsonSerializerSettings _settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };

        /// <summary>
        /// Reads an external Json file and deserializes it.
        /// </summary>
        /// <param name="path"> External Json file path. </param>
        /// <typeparam name="T"> Serializable Json data type. </typeparam>
        /// <returns> Deserialized data type instances. </returns>
        public static T Deserialize<T>(string path)
        {
            var text = File.ReadAllText(path);
            var data = JsonConvert.DeserializeObject<T>(text);

            return data;
        }

        /// <summary>
        /// Serializes a Json data instance and writes the file to an external path.
        /// </summary>
        /// <param name="path"> External Json file path. </param>
        /// <param name="data"> Data instances to serialize. </param>
        /// <typeparam name="T"> Serializable Json data type. </typeparam>
        public static void Serialize<T>(string path, T data)
        {
            var text = JsonConvert.SerializeObject(data, Formatting.Indented, _settings);

            File.WriteAllText(path, text);
        }
    }
}
