using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.CompilerServices;

#if UNITY_EDITOR || DEVELOPMENT_BUILD

using Util.Log;

#endif

using Debug = UnityEngine.Debug;

namespace Util.Manager
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
        
#if UNITY_EDITOR || DEVELOPMENT_BUILD
        
        /// <summary>
        /// Get name of <see cref="Label"/>, which is the value of <see cref="Enum"/> with all upper case
        /// </summary>
        /// <param name="label"> <see cref="Label"/> to distinguish between types of logs </param>
        /// <returns> Name of <see cref="Label"/> </returns>
        private static string GetName(this Label label)
        {
            return Enum.GetName(typeof(Label), label)?.ToUpper();
        }

#endif

#if UNITY_EDITOR
        
        /// <summary>
        /// Build log for checking progress of application
        /// </summary>
        /// <param name="className"> Name of class to which the log is called </param>
        /// <param name="methodName"> Name of method to which the log is called </param>
        /// <returns> Log of progress </returns>
        private static string Build(string className, string methodName)
        {
            return "<color=#F8F8FF><b>[PROGRESS]</b></color>\n" +
                   $"<b>Class: </b>{className}\n<b>Method: </b>{methodName}()\n\n";
        }

        /// <summary>
        /// Build specify log for checking progress of application
        /// </summary>
        /// <param name="label"> <see cref="Label"/> to distinguish between types of logs </param>
        /// <param name="className"> Name of class to which the log is called </param>
        /// <param name="methodName"> Name of method to which the log is called </param>
        /// <param name="message"> Additional explanation of progress </param>
        /// <returns> Specify log of progress </returns>
        private static string Build(Label label, string className, string methodName, string message)
        {
            string log;
            
            switch (label)
            {
                case Label.Administrator:
                    log = $"<color=#F7E600><b>[{label.GetName()}]</b></color>\n" +
                          $"<b>Class: </b>{className}\n<b>Method: </b>{methodName}()\n<b>Message: </b>{message}\n";
                    break;
                case Label.Message:
                    log = $"<color=#F8F8FF><b>[{label.GetName()}]</b></color>\n" +
                          $"<b>Class: </b>{className}\n<b>Method: </b>{methodName}()\n<b>Message: </b>{message}\n";
                    break;
                case Label.Error:
                    log = $"<color=#DC143C><b>[{label.GetName()}]</b></color>\n<b>" +
                          $"Class: </b>{className}\n<b>Method: </b>{methodName}()\n<b>Message: </b>{message}\n";
                    break;
                case Label.Success:
                    log = $"<color=#39FF14><b>[{label.GetName()}]</b></color>\n<b>" +
                          $"Class: </b>{className}\n<b>Method: </b>{methodName}()\n<b>Message: </b>{message}\n";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(label), label, null);
            }

            return log;
        }
        
#elif DEVELOPMENT_BUILD

        private static string Build(string className, string methodName)
        {
            return $"PROGRESS|{className}|{methodName}()";
        }
        
        private static string Build(Label label, string className, string methodName, string message)
        {
            return $"{label.GetName()}|{className}|{methodName}()|{message}";
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
            
            Debug.Log(Build(className, methodName));
            

#elif DEVELOPMENT_BUILD

            using (var writer = new StreamWriter(UnityEngine.Application.persistentDataPath + LogFileName, true))
            {
                writer.WriteLine(Build(className, methodName));
            }
            
#endif
        }
        
        /// <summary>
        /// Log progress of application with administrator permission
        /// </summary>
        /// <param name="message"> Message for checking </param>
        /// <param name="methodName"> Name of the method, property, or event from which the call originated </param>
        /// <param name="filePath"> Full path of the file which the call originated </param>
        [Conditional(UnityEditor), Conditional(DevelopmentBuild)]
        public static void LogAsAdministrator(string message,
                                              [CallerMemberName] string methodName = "",
                                              [CallerFilePath] string filePath = "")
        {
            var className = Path.GetFileNameWithoutExtension(filePath);
            
#if UNITY_EDITOR
            
            Debug.LogWarning(Build(Label.Administrator, className, methodName, message));

#elif DEVELOPMENT_BUILD

            using (var writer = new StreamWriter(UnityEngine.Application.persistentDataPath + LogFileName, true))
            {
                writer.WriteLine(Build(Label.Administrator, className, methodName, message));
            }
            
#endif
        }

        /// <summary>
        /// Log message for checking application
        /// </summary>
        /// <param name="message"> Message for checking </param>
        /// <param name="methodName"> Name of the method, property, or event from which the call originated </param>
        /// <param name="filePath"> Full path of the file which the call originated </param>
        [Conditional(UnityEditor), Conditional(DevelopmentBuild)]
        public static void LogMessage(string message, 
                                      [CallerMemberName] string methodName = "", 
                                      [CallerFilePath] string filePath = "")
        {
            var className = Path.GetFileNameWithoutExtension(filePath);
            
#if UNITY_EDITOR
            
            Debug.Log(Build(Label.Message, className, methodName, message));

#elif DEVELOPMENT_BUILD

            using (var writer = new StreamWriter(UnityEngine.Application.persistentDataPath + LogFileName, true))
            {
                writer.WriteLine(Build(Label.Message, className, methodName, message));
            }
            
#endif
        }

        /// <summary>
        /// Log error message in application
        /// </summary>
        /// <param name="message"> Message for checking </param>
        /// <param name="methodName"> Name of the method, property, or event from which the call originated </param>
        /// <param name="filePath"> Full path of the file which the call originated </param>
        [Conditional(UnityEditor), Conditional(DevelopmentBuild)]
        public static void LogError(string message, 
                                    [CallerMemberName] string methodName = "", 
                                    [CallerFilePath] string filePath = "")
        {
            var className = Path.GetFileNameWithoutExtension(filePath);
            
#if UNITY_EDITOR
            
            Debug.LogError(Build(Label.Error, className, methodName, message));

#elif DEVELOPMENT_BUILD

            using (var writer = new StreamWriter(UnityEngine.Application.persistentDataPath + LogFileName, true))
            {
                writer.WriteLine(Build(Label.Error, className, methodName, message));
            }
            
#endif
        }
        
        /// <summary>
        /// Log success message in application
        /// </summary>
        /// <param name="message"> Message for checking </param>
        /// <param name="methodName"> Name of the method, property, or event from which the call originated </param>
        /// <param name="filePath"> Full path of the file which the call originated </param>
        [Conditional(UnityEditor), Conditional(DevelopmentBuild)]
        public static void LogSuccess(string message,
                                      [CallerMemberName] string methodName = "",
                                      [CallerFilePath] string filePath = "")
        {
            var className = Path.GetFileNameWithoutExtension(filePath);
            
#if UNITY_EDITOR
            
            Debug.Log(Build(Label.Success, className, methodName, message));

#elif DEVELOPMENT_BUILD

            using (var writer = new StreamWriter(UnityEngine.Application.persistentDataPath + LogFileName, true))
            {
                writer.WriteLine(Build(Label.Success, className, methodName, message));
            }
            
#endif
        }
    }
}
