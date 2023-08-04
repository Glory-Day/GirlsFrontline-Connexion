using System.IO;
using UnityEngine;
using Util.Log;

namespace Util.Manager.Data
{
    public class DataLoader
    {
        public static T OnLoadData<T>(string path) where T : class
        {
            LogManager.LogCalled();

            T data;

            try
            {
                data = JsonUtility.FromJson<T>(File.ReadAllText(Application.streamingAssetsPath + path));

                LogManager.LogSuccess($"<b>{typeof(T).Name}</b> is loaded from <b>{typeof(T).Name}.json</b>");
            }
            catch (DirectoryNotFoundException error)
            {
                LogManager.LogError(error.Message);

                // Directory not found exception error
                return null;
            }

            return data;
        }
    }
}
