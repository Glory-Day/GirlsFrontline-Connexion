using System.IO;
using UnityEngine;

using Manager.Log;
using LabelType = Manager.Log.Console.Label.LabelType;

namespace Manager.Data
{
    public static class DataLoader<T> where T : class
    {
        /// <summary>
        /// Read the Json file from the corresponding file path and save it in class format
        /// </summary>
        /// <param name="path"> Json file path </param>
        /// <returns> Json file stored in class format </returns>
        public static T OnLoadData(string path)
        {
            T data;

            try
            {
#if UNITY_EDITOR

                LogManager.OnDebugLog(
                    typeof(DataLoader<T>), 
                    $"Called OnLoadData<{typeof(T).Name}>()");

#endif
                
                data = JsonUtility.FromJson<T>(File.ReadAllText(Application.dataPath + path));
            }
            catch (DirectoryNotFoundException error)
            {
#if UNITY_EDITOR

                LogManager.OnDebugLog(
                    LabelType.Error,
                    typeof(DataLoader<T>),
                    error.Message);

#endif

                // Directory not found exception error
                return null;
            }
            
            return data;
        }
    }
}
