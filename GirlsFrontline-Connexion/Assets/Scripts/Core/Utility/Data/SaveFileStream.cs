using System.IO;
using System.Text;
using GloryDay.Debug;
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
            Console.LogProgress();

            if (IsSaveFileExisted == false)
            {
                return string.Empty;
            }

            string data;
            using (var reader = new StreamReader(_savePath))
            {
                data = reader.ReadToEnd();
            }

            return data;
        }

        public void Write(string data)
        {
            Console.LogProgress();

            var directory = Path.GetDirectoryName(_savePath);
            if (Directory.Exists(directory) == false)
            {
                Directory.CreateDirectory(directory);
            }

            using (var writer = new StreamWriter(_savePath, false, Encoding.UTF8))
            {
                writer.WriteLine(data);
            }
        }

        public bool IsSaveFileExisted => System.IO.File.Exists(_savePath);
    }
}
