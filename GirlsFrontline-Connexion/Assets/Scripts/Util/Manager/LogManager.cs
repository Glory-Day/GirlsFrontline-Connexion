#if UNITY_EDITOR

using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;
using Util.Log;
using Util.Log.Component;

namespace Util.Manager
{
    public static class LogManager
    {
        public static void LogCalled([CallerMemberName] string methodName = "",
                                     [CallerFilePath] string filePath = "")
        {
            var className = Path.GetFileNameWithoutExtension(filePath);
            Debug.Log(Builder.Build(className, methodName));
        }

        public static void LogAdministrator(string message, 
                                            [CallerMemberName] string methodName = "", 
                                            [CallerFilePath] string filePath = "")
        {
            var className = Path.GetFileNameWithoutExtension(filePath);
            Debug.LogWarning(Builder.Build(Label.Administrator, message, className, methodName));
        }

        public static void LogMessage(string message, 
                                      [CallerMemberName] string methodName = "", 
                                      [CallerFilePath] string filePath = "")
        {
            var className = Path.GetFileNameWithoutExtension(filePath);
            Debug.Log(Builder.Build(Label.Message, message, className, methodName));
        }

        public static void LogError(string message, 
                                    [CallerMemberName] string methodName = "", 
                                    [CallerFilePath] string filePath = "")
        {
            var className = Path.GetFileNameWithoutExtension(filePath);
            Debug.LogError(Builder.Build(Label.Error, message, className, methodName));
        }

        public static void LogSuccess(string message, 
                                      [CallerMemberName] string methodName = "", 
                                      [CallerFilePath] string filePath = "")
        {
            var className = Path.GetFileNameWithoutExtension(filePath);
            Debug.Log(Builder.Build(Label.Success, message, className, methodName));
        }
    }
}

#elif DEVELOPMENT_BUILD

using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;
using Util.Log;
using Util.Log.Component;

namespace Util.Manager
{
    public static class LogManager
    {
        private const string LogFilePath = @"/Build.log";

        public static void LogCalled([CallerMemberName] string methodName = "",
                                     [CallerFilePath] string filePath = "")
        {
            var className = Path.GetFileNameWithoutExtension(filePath);
            using (var writer = new StreamWriter(Application.persistentDataPath + LogFilePath, true))
            {
                writer.WriteLine(Builder.Build(className, methodName));
            }
        }

        public static void LogAdministrator(string message, 
                                            [CallerMemberName] string methodName = "", 
                                            [CallerFilePath] string filePath = "")
        {
            var className = Path.GetFileNameWithoutExtension(filePath);
            using (var writer = new StreamWriter(Application.persistentDataPath + LogFilePath, true))
            {
                writer.WriteLine(Builder.Build(Label.Administrator, message, className, methodName));
            }
        }

        public static void LogMessage(string message, 
                                      [CallerMemberName] string methodName = "", 
                                      [CallerFilePath] string filePath = "")
        {
            var className = Path.GetFileNameWithoutExtension(filePath);
            using (var writer = new StreamWriter(Application.persistentDataPath + LogFilePath, true))
            {
                writer.WriteLine(Builder.Build(Label.Message, message, className, methodName));
            }
        }

        public static void LogError(string message, 
                                    [CallerMemberName] string methodName = "", 
                                    [CallerFilePath] string filePath = "")
        {
            var className = Path.GetFileNameWithoutExtension(filePath);
            using (var writer = new StreamWriter(Application.persistentDataPath + LogFilePath, true))
            {
                writer.WriteLine(Builder.Build(Label.Error, message, className, methodName));
            }
        }

        public static void LogSuccess(string message, 
                                      [CallerMemberName] string methodName = "", 
                                      [CallerFilePath] string filePath = "")
        {
            var className = Path.GetFileNameWithoutExtension(filePath);
            using (var writer = new StreamWriter(Application.persistentDataPath + LogFilePath, true))
            {
                writer.WriteLine(Builder.Build(Label.Success, message, className, methodName));
            }
        }
    }
}

#endif