﻿using System;
using System.IO;
using UnityEngine;

using Manager.Log;

namespace Manager
{
    /// <summary>
    /// Manager that manages the entire log for debugging
    /// </summary>
    public class LogManager : Singleton<LogManager>
    {
        private const string DevelopmentBuild = "DEVELOPMENT_BUILD";
        private const string UnityEditor = "UNITY_EDITOR";

        protected LogManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }

        #region EDITOR CONSOLE API

        /// <summary>
        /// Outputs a general log to the console in <b>Unity Editor</b>
        /// </summary>
        /// <param name="classType"> Type of the class where the log was called </param>
        /// <param name="contexts"> Contents of the log </param>
        [System.Diagnostics.Conditional(UnityEditor)]
        private static void EditorLog(Type classType, string contexts)
        {
#if UNITY_EDITOR
            Debug.Log(Log.Console.LogBuilder.OnBuild(classType, contexts));
#endif
        }

        /// <summary>
        /// Outputs a specific log to the console in <b>Unity Editor</b>
        /// </summary>
        /// <param name="type"> Type of Log </param>
        /// <param name="classType"> Type of the class where the log was called </param>
        /// <param name="contexts"> Contents of the log </param>
        /// <exception cref="ArgumentOutOfRangeException"> Out of range in <b>LabelType</b> </exception>
        [System.Diagnostics.Conditional(UnityEditor)]
        private static void EditorLog(Label.LabelType type, Type classType, string contexts)
        {
            var message = Log.Console.LogBuilder.OnBuild(type, classType, contexts);
            
            switch (type)
            {
                case Label.LabelType.Event:
#if UNITY_EDITOR
                    Debug.Log(message);
#endif
                    break;
                case Label.LabelType.Error:
#if UNITY_EDITOR
                    Debug.LogError(message);
#endif
                    break;
                case Label.LabelType.Warning:
#if UNITY_EDITOR
                    Debug.LogWarning(message);
#endif
                    break;
                case Label.LabelType.Success:
#if UNITY_EDITOR
                    Debug.Log(message);
#endif
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        #endregion

        #region DEVELOPMENT BUILD CONSOLE API

        private const string BuildLogPath = @"/Build.log";

        /// <summary>
        /// Outputs a general log to the console in <b>Unity Application</b> after built
        /// </summary>
        /// <param name="classType"> Type of the class where the log was called </param>
        /// <param name="contexts"> Contents of the log </param>
        [System.Diagnostics.Conditional(DevelopmentBuild)]
        private static void BuildLog(Type classType, string contexts)
        {
#if DEVELOPMENT_BUILD
            using (var writer = new StreamWriter(Application.persistentDataPath + BuildLogPath, append: true))
            {
                writer.WriteLine(Log.Build.LogBuilder.OnBuild(classType, contexts));
            }
#endif
        }

        /// <summary>
        /// Outputs a specific log to the console in <b>Unity Application</b> after built
        /// </summary>
        /// <param name="type"> Type of Log </param>
        /// <param name="classType"> Type of the class where the log was called </param>
        /// <param name="contexts"> Contents of the log </param>
        [System.Diagnostics.Conditional(DevelopmentBuild)]
        private static void BuildLog(Label.LabelType type, Type classType, string contexts)
        {
#if DEVELOPMENT_BUILD
            using (var writer = new StreamWriter(Application.persistentDataPath + BuildLogPath, append: true))
            {
                writer.WriteLine(Log.Build.LogBuilder.OnBuild(type, classType, contexts));
            }
#endif
        }

        #endregion
        
        /// <summary>
        /// Outputs a general log
        /// </summary>
        /// <param name="classType"> Type of the class where the log was called </param>
        /// <param name="contexts"> Contents of the log </param>
        [System.Diagnostics.Conditional(DevelopmentBuild), 
         System.Diagnostics.Conditional(UnityEditor)]
        public static void OnDebugLog(Type classType, string contexts)
        {
#if UNITY_EDITOR
            EditorLog(classType, contexts);
#elif DEVELOPMENT_BUILD
            BuildLog(classType, contexts);
#endif
        }

        /// <summary>
        /// Outputs a specific log
        /// </summary>
        /// <param name="type"> Type of Log </param>
        /// <param name="classType"> Type of the class where the log was called </param>
        /// <param name="contexts"> Contents of the log </param>
        [System.Diagnostics.Conditional(DevelopmentBuild),
         System.Diagnostics.Conditional(UnityEditor)]
        public static void OnDebugLog(Label.LabelType type, Type classType, string contexts)
        {
#if UNITY_EDITOR
            EditorLog(type, classType, contexts);
#elif DEVELOPMENT_BUILD
            BuildLog(type, classType, contexts);
#endif
        }
    }
}
