#region NAMESPACE API

using System.IO;
using UnityEngine;
using Util.Manager.Log;

#endregion

namespace Util.Manager.Data
{
    public class DataLoader
    {
        public static T OnLoadData<T>(string path) where T : class
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(DataLoader),
                $"OnLoadData<{typeof(T).Name}>()");

            T data;

            try
            {
                data = JsonUtility.FromJson<T>(File.ReadAllText(Application.streamingAssetsPath + path));

                LogManager.OnDebugLog(
                    Label.Success, 
                    typeof(DataLoader),
                    $"<b>{typeof(T).Name}</b> is loaded from <b>{typeof(T).Name}.json</b>");
            }
            catch (DirectoryNotFoundException error)
            {
                LogManager.OnDebugLog(
                    Label.Error, 
                    typeof(DataLoader),
                    error.Message);

                // Directory not found exception error
                return null;
            }

            return data;
        }
    }
}
