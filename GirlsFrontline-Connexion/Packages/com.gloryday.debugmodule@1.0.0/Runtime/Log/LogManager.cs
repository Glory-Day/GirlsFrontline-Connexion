using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace GloryDay.Debug.Log
{
    public static class LogManager
    {
        #region CONSTANT FIELD API

#if DEVELOPMENT_BUILD

        private const string LogFileName = "/Build.log";

#endif
        
        private const string UnityEditor      = "UNITY_EDITOR";
        private const string DevelopmentBuild = "DEVELOPMENT_BUILD";
        
        #endregion

#if UNITY_EDITOR
        
        /// <summary>
        /// Build log for checking progress of application
        /// </summary>
        /// <param name="className"> Name of class to which the log is called </param>
        /// <param name="methodName"> Name of method to which the log is called </param>
        private static string Build(string className, string methodName)
        {
            return "<color=#F8F8FF><b>[PROGRESS]</b></color>\n" +
                   $"<b>Class: </b>{className}\n<b>Method: </b>{methodName}()\n\n";
        }

        /// <summary>
        /// Build specify log for checking progress of application
        /// </summary>
        /// <param name="type"> <see cref="LogMessageType"/> to distinguish between types of logs </param>
        /// <param name="message"> Additional explanation of progress </param>
        /// <param name="className"> Name of class to which the log is called </param>
        /// <param name="methodName"> Name of method to which the log is called </param>
        private static string Build(LogMessageType type, string message, string className, string methodName)
        {
            string log;
            
            switch (type)
            {
                case LogMessageType.Administrator:
                    log = $"<color=#F7E600><b>[{type.GetName()}]</b></color>\n" +
                          $"<b>Class: </b>{className}\n<b>Method: </b>{methodName}()\n<b>Message: </b>{message}\n";
                    break;
                case LogMessageType.Message:
                    log = $"<color=#F8F8FF><b>[{type.GetName()}]</b></color>\n" +
                          $"<b>Class: </b>{className}\n<b>Method: </b>{methodName}()\n<b>Message: </b>{message}\n";
                    break;
                case LogMessageType.Error:
                    log = $"<color=#DC143C><b>[{type.GetName()}]</b></color>\n<b>" +
                          $"Class: </b>{className}\n<b>Method: </b>{methodName}()\n<b>Message: </b>{message}\n";
                    break;
                case LogMessageType.Success:
                    log = $"<color=#39FF14><b>[{type.GetName()}]</b></color>\n<b>" +
                          $"Class: </b>{className}\n<b>Method: </b>{methodName}()\n<b>Message: </b>{message}\n";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return log;
        }
        
#elif DEVELOPMENT_BUILD

        private static string Build(string className, string methodName)
        {
            return $"PROGRESS|{className}|{methodName}()";
        }
        
        private static string Build(LogMessageType type, string className, string methodName, string message)
        {
            return $"{type.GetName()}|{className}|{methodName}()|{message}";
        }

#endif
        
        /// <summary>
        /// Log progress of application for checking
        /// </summary>
        /// <param name="methodName"> Name of the method, property, or event from which the call originated </param>
        /// <param name="filePath"> Full path of the file which the call originated </param>
        [Conditional(UnityEditor), Conditional(DevelopmentBuild)]
        public static void LogProgress([CallerMemberName] string methodName = "",
                                       [CallerFilePath] string filePath = "")
        {
            var className = Path.GetFileNameWithoutExtension(filePath);

#if UNITY_EDITOR
            
            UnityEngine.Debug.Log(Build(className, methodName));
            

#elif DEVELOPMENT_BUILD

            using (var writer = new StreamWriter(UnityEngine.Application.persistentDataPath + LogFileName, true))
            {
                writer.WriteLine(Build(className, methodName));
            }
            
#endif
        }
        
        /// <summary>
        /// Log message with administrator permission
        /// </summary>
        /// <param name="message"> Additional explanation of progress </param>
        /// <param name="methodName"> Name of the method, property, or event from which the call originated </param>
        /// <param name="filePath"> Full path of the file which the call originated </param>
        [Conditional(UnityEditor), Conditional(DevelopmentBuild)]
        public static void LogAsAdministrator(string message,
                                              [CallerMemberName] string methodName = "",
                                              [CallerFilePath] string filePath = "")
        {
            var className = Path.GetFileNameWithoutExtension(filePath);
            
#if UNITY_EDITOR
            
            UnityEngine.Debug.LogWarning(Build(LogMessageType.Administrator, message, className, methodName));

#elif DEVELOPMENT_BUILD

            using (var writer = new StreamWriter(UnityEngine.Application.persistentDataPath + LogFileName, true))
            {
                writer.WriteLine(Build(LogMessageType.Administrator, message, className, methodName));
            }
            
#endif
        }

        /// <summary>
        /// Log message for checking application
        /// </summary>
        /// <param name="message"> Additional explanation of progress </param>
        /// <param name="methodName"> Name of the method, property, or event from which the call originated </param>
        /// <param name="filePath"> Full path of the file which the call originated </param>
        [Conditional(UnityEditor), Conditional(DevelopmentBuild)]
        public static void LogMessage(string message, 
                                      [CallerMemberName] string methodName = "", 
                                      [CallerFilePath] string filePath = "")
        {
            var className = Path.GetFileNameWithoutExtension(filePath);
            
#if UNITY_EDITOR
            
            UnityEngine.Debug.Log(Build(LogMessageType.Message, message, className, methodName));

#elif DEVELOPMENT_BUILD

            using (var writer = new StreamWriter(UnityEngine.Application.persistentDataPath + LogFileName, true))
            {
                writer.WriteLine(Build(LogMessageType.Message, message, className, methodName));
            }
            
#endif
        }

        /// <summary>
        /// Log error message in application
        /// </summary>
        /// <param name="message"> Additional explanation of progress </param>
        /// <param name="methodName"> Name of the method, property, or event from which the call originated </param>
        /// <param name="filePath"> Full path of the file which the call originated </param>
        [Conditional(UnityEditor), Conditional(DevelopmentBuild)]
        public static void LogError(string message, 
                                    [CallerMemberName] string methodName = "", 
                                    [CallerFilePath] string filePath = "")
        {
            var className = Path.GetFileNameWithoutExtension(filePath);
            
#if UNITY_EDITOR
            
            UnityEngine.Debug.LogError(Build(LogMessageType.Error, message, className, methodName));

#elif DEVELOPMENT_BUILD

            using (var writer = new StreamWriter(UnityEngine.Application.persistentDataPath + LogFileName, true))
            {
                writer.WriteLine(Build(LogMessageType.Error, message, className, methodName));
            }
            
#endif
        }
        
        /// <summary>
        /// Log success message in application
        /// </summary>
        /// <param name="message"> Additional explanation of progress </param>
        /// <param name="methodName"> Name of the method, property, or event from which the call originated </param>
        /// <param name="filePath"> Full path of the file which the call originated </param>
        [Conditional(UnityEditor), Conditional(DevelopmentBuild)]
        public static void LogSuccess(string message,
                                      [CallerMemberName] string methodName = "",
                                      [CallerFilePath] string filePath = "")
        {
            var className = Path.GetFileNameWithoutExtension(filePath);
            
#if UNITY_EDITOR
            
            UnityEngine.Debug.Log(Build(LogMessageType.Success, message, className, methodName));

#elif DEVELOPMENT_BUILD

            using (var writer = new StreamWriter(UnityEngine.Application.persistentDataPath + LogFileName, true))
            {
                writer.WriteLine(Build(LogMessageType.Success, message, className, methodName));
            }
            
#endif
        }
    }
}