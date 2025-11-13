using System.IO;
using System.Text;
using GloryDay.Debug.Log;
using UnityEngine;

namespace GloryDay.Data.File.Stream
{
    /// <summary>
    /// Provides a stream for a user data file, supporting read and write operations
    /// </summary>
    public class SaveFileStream
    {
        private readonly string _savePath = Application.persistentDataPath + "/Data/Save.json";

        public string Read()
        {
            LogManager.LogProgress();

            string data;
            using (var reader = new StreamReader(_savePath))
            {
                data = reader.ReadToEnd();
            }

            return data;
        }

        public void Write(string data)
        {
            LogManager.LogProgress();
            
            using (var writer = new StreamWriter(_savePath, false, Encoding.UTF8))
            {
                writer.WriteLine(data);
            }
        }

        public bool IsSaveFileExisted => System.IO.File.Exists(_savePath);
    }
}
