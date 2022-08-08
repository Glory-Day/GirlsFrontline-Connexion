#region NAMESPACE API

using System.IO;
using UnityEngine;
using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace Manager.Data
{
    /// <summary>
    /// Json file format data loader
    /// </summary>
    public class DataLoader
    {
        /// <summary>
        /// Load data according to the Json file format
        /// </summary>
        /// <param name="path"> Json file local path </param>
        /// <typeparam name="T"> Type of Json file format in <see cref="Data.Category"/> </typeparam>
        /// <returns> Loaded data in Json file </returns>
        public static T OnLoadData<T>(string path) where T : class
        {
            LogManager.OnDebugLog(typeof(DataLoader),
                $"OnLoadData<{typeof(T).Name}>()");

            T data;

            try
            {
                data = JsonUtility.FromJson<T>(File.ReadAllText(Application.streamingAssetsPath + path));

                LogManager.OnDebugLog(LabelType.Success, typeof(DataLoader),
                    $"<b>{typeof(T).Name}</b> is loaded from <b>{typeof(T).Name}.json</b> successfully");
            }
            catch (DirectoryNotFoundException error)
            {
                LogManager.OnDebugLog(LabelType.Error, typeof(DataLoader),
                    error.Message);

                // Directory not found exception error
                return null;
            }

            return data;
        }
    }
}
