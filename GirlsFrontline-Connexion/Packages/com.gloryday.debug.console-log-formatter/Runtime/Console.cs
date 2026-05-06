using System.IO;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace GloryDay.Debug
{
    public static class Console
    {
        #region CONSTANT FIELD API

#if DEVELOPMENT_BUILD

        private const string OutputFileName = "/Build.log";

#endif

        private const string UnityEditor = "UNITY_EDITOR";
        private const string DevelopmentBuild = "DEVELOPMENT_BUILD";

        #endregion

#if UNITY_EDITOR

        /// <summary>
        /// Build log for checking progress of application.
        /// </summary>
        /// <param name="className">Name of class to which the log is called.</param>
        /// <param name="methodName">Name of method to which the log is called.</param>
        private static string Build(string className, string methodName)
        {
            var text = LogLevel.Progress.GetText();
            var color = LogLevel.Progress.GetColor();

            return $"<color={color}><b>[{text}]</b></color>\n<b>Class: </b>{className}\n<b>Method: </b>{methodName}()\n\n";
        }

        /// <summary>
        /// Build specify log for checking progress of application.
        /// </summary>
        /// <param name="level"><see cref="LogLevel"/> to distinguish between types of logs.</param>
        /// <param name="message">Additional explanation of progress.</param>
        /// <param name="className">Name of class to which the log is called.</param>
        /// <param name="methodName">Name of method to which the log is called.</param>
        private static string Build(LogLevel level, string message, string className, string methodName)
        {
            var text = level.GetText();
            var color = level.GetColor();

            var log = $"<color={color}><b>[{text}]</b></color>\n<b>Class: </b>{className}\n<b>Method: </b>{methodName}()\n<b>Message: </b>{message}\n";

            return log;
        }

#elif DEVELOPMENT_BUILD

        private static string Build(string className, string methodName)
        {
            var text = LogLevel.Progress.GetText();

            return $"{text}|{className}|{methodName}()";
        }

        private static string Build(LogLevel level, string message, string className, string methodName)
        {
            var text = level.GetText();

            return $"{text}|{className}|{methodName}()|{message}";
        }

#endif

        /// <summary>
        /// Log progress of application for checking.
        /// </summary>
        /// <param name="methodName">Name of the method, property, or event from which the call originated.</param>
        /// <param name="filePath">Full path of the file which the call originated.</param>
        [Conditional(UnityEditor), Conditional(DevelopmentBuild)]
        public static void LogProgress([CallerMemberName] string methodName = "",
                                       [CallerFilePath] string filePath = "")
        {
            var className = Path.GetFileNameWithoutExtension(filePath);

#if UNITY_EDITOR

            UnityEngine.Debug.Log(Build(className, methodName));

#elif DEVELOPMENT_BUILD

            using (var writer = new StreamWriter(UnityEngine.Application.persistentDataPath + OutputFileName, true))
            {
                writer.WriteLine(Build(className, methodName));
            }

#endif
        }

        /// <summary>
        /// Log message with administrator level.
        /// </summary>
        /// <param name="message">Additional explanation of progress.</param>
        /// <param name="methodName">Name of the method, property, or event from which the call originated.</param>
        /// <param name="filePath">Full path of the file which the call originated.</param>
        [Conditional(UnityEditor), Conditional(DevelopmentBuild)]
        public static void LogAsAdministrator(string message,
                                              [CallerMemberName] string methodName = "",
                                              [CallerFilePath] string filePath = "")
        {
            var className = Path.GetFileNameWithoutExtension(filePath);

#if UNITY_EDITOR

            UnityEngine.Debug.LogWarning(Build(LogLevel.Administrator, message, className, methodName));

#elif DEVELOPMENT_BUILD

            using (var writer = new StreamWriter(UnityEngine.Application.persistentDataPath + OutputFileName, true))
            {
                writer.WriteLine(Build(LogLevel.Administrator, message, className, methodName));
            }

#endif
        }

        /// <summary>
        /// Log message for checking application.
        /// </summary>
        /// <param name="message">Additional explanation of progress.</param>
        /// <param name="methodName">Name of the method, property, or event from which the call originated.</param>
        /// <param name="filePath">Full path of the file which the call originated.</param>
        [Conditional(UnityEditor), Conditional(DevelopmentBuild)]
        public static void LogMessage(string message,
                                      [CallerMemberName] string methodName = "",
                                      [CallerFilePath] string filePath = "")
        {
            var className = Path.GetFileNameWithoutExtension(filePath);

#if UNITY_EDITOR

            UnityEngine.Debug.Log(Build(LogLevel.Message, message, className, methodName));

#elif DEVELOPMENT_BUILD

            using (var writer = new StreamWriter(UnityEngine.Application.persistentDataPath + OutputFileName, true))
            {
                writer.WriteLine(Build(LogLevel.Message, message, className, methodName));
            }

#endif
        }

        /// <summary>
        /// Log message for checking application event.
        /// </summary>
        /// <param name="message">Additional explanation of progress.</param>
        /// <param name="methodName">Name of the method, property, or event from which the call originated.</param>
        /// <param name="filePath">Full path of the file which the call originated.</param>
        [Conditional(UnityEditor), Conditional(DevelopmentBuild)]
        public static void LogEventMessage(string message,
                                           [CallerMemberName] string methodName = "",
                                           [CallerFilePath] string filePath = "")
        {
            var className = Path.GetFileNameWithoutExtension(filePath);

#if UNITY_EDITOR

            UnityEngine.Debug.Log(Build(LogLevel.Event, message, className, methodName));

#elif DEVELOPMENT_BUILD

            using (var writer = new StreamWriter(UnityEngine.Application.persistentDataPath + OutputFileName, true))
            {
                writer.WriteLine(Build(LogLevel.Event, message, className, methodName));
            }

#endif
        }

        /// <summary>
        /// Log error message for checking application.
        /// </summary>
        /// <param name="message">Additional explanation of progress.</param>
        /// <param name="methodName">Name of the method, property, or event from which the call originated.</param>
        /// <param name="filePath">Full path of the file which the call originated.</param>
        [Conditional(UnityEditor), Conditional(DevelopmentBuild)]
        public static void LogError(string message,
                                    [CallerMemberName] string methodName = "",
                                    [CallerFilePath] string filePath = "")
        {
            var className = Path.GetFileNameWithoutExtension(filePath);

#if UNITY_EDITOR

            UnityEngine.Debug.LogError(Build(LogLevel.Error, message, className, methodName));

#elif DEVELOPMENT_BUILD

            using (var writer = new StreamWriter(UnityEngine.Application.persistentDataPath + OutputFileName, true))
            {
                writer.WriteLine(Build(LogLevel.Error, message, className, methodName));
            }

#endif
        }

        /// <summary>
        /// Log warning message for checking application.
        /// </summary>
        /// <param name="message">Additional explanation of progress.</param>
        /// <param name="methodName">Name of the method, property, or event from which the call originated.</param>
        /// <param name="filePath">Full path of the file which the call originated.</param>
        [Conditional(UnityEditor), Conditional(DevelopmentBuild)]
        public static void LogWarning(string message,
                                    [CallerMemberName] string methodName = "",
                                    [CallerFilePath] string filePath = "")
        {
            var className = Path.GetFileNameWithoutExtension(filePath);

#if UNITY_EDITOR

            UnityEngine.Debug.LogWarning(Build(LogLevel.Warning, message, className, methodName));

#elif DEVELOPMENT_BUILD

            using (var writer = new StreamWriter(UnityEngine.Application.persistentDataPath + OutputFileName, true))
            {
                writer.WriteLine(Build(LogLevel.Warning, message, className, methodName));
            }

#endif
        }

        /// <summary>
        /// Log success message for checking application.
        /// </summary>
        /// <param name="message">Additional explanation of progress.</param>
        /// <param name="methodName">Name of the method, property, or event from which the call originated.</param>
        /// <param name="filePath">Full path of the file which the call originated.</param>
        [Conditional(UnityEditor), Conditional(DevelopmentBuild)]
        public static void LogSuccess(string message,
                                      [CallerMemberName] string methodName = "",
                                      [CallerFilePath] string filePath = "")
        {
            var className = Path.GetFileNameWithoutExtension(filePath);

#if UNITY_EDITOR

            UnityEngine.Debug.Log(Build(LogLevel.Success, message, className, methodName));

#elif DEVELOPMENT_BUILD

            using (var writer = new StreamWriter(UnityEngine.Application.persistentDataPath + OutputFileName, true))
            {
                writer.WriteLine(Build(LogLevel.Success, message, className, methodName));
            }

#endif
        }
    }
}
