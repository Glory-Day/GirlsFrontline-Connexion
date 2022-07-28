#region NAMESPACE API

using System.IO;
using UnityEngine;
using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace Manager.Data
{
    /// <summary>
    /// Management Loading data according to the Json file format
    /// </summary>
    /// <typeparam name="T"> Json file format in namespace <b>Data.Category</b> </typeparam>
    public static class DataLoader<T> where T : class
    {
        /// <summary>
        /// Load data according to the Json file format
        /// </summary>
        /// <param name="path"> Json file local path </param>
        /// <returns> Loaded data in Json file </returns>
        public static T OnLoadData(string path)
        {
            LogManager.OnDebugLog(typeof(DataLoader<T>),
                $"OnLoadData<{typeof(T).Name}>()");

            T data;

            try
            {
                data = JsonUtility.FromJson<T>(File.ReadAllText(Application.streamingAssetsPath + path));

                LogManager.OnDebugLog(LabelType.Success, typeof(DataLoader<T>),
                    $"<b>{typeof(T).Name}</b> is loaded from <b>{typeof(T).Name}.json</b> successfully");
            }
            catch (DirectoryNotFoundException error)
            {
                LogManager.OnDebugLog(LabelType.Error, typeof(DataLoader<T>),
                    error.Message);

                // Directory not found exception error
                return null;
            }

            return data;
        }
    }
}
