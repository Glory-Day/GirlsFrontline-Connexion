using System;
using UnityEngine;

using Manager.Log.Console;

namespace Manager
{
    /// <summary>
    /// Manager that manages the entire log for debugging in the <b>Unity Editor</b>
    /// </summary>
    public class LogManager : Singleton<LogManager>
    {
        private const string UnityEditor = "UNITY_EDITOR";
        
        protected LogManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }

        #region CONSOLE STATIC API

        /// <summary>
        /// Outputs a general log to the console
        /// </summary>
        /// <param name="classType"> Type of the class where the log was called </param>
        /// <param name="contexts"> Contents of the log </param>
        [System.Diagnostics.Conditional(UnityEditor)]
        public static void OnDebugLog(Type classType, string contexts)
        {
#if UNITY_EDITOR
            Debug.Log(LogBuilder.OnBuild(classType, contexts));
#endif
        }

        /// <summary>
        /// Outputs a specific log to the console
        /// </summary>
        /// <param name="type"> Type of Log </param>
        /// <param name="classType"> Type of the class where the log was called </param>
        /// <param name="contexts"> Contents of the log </param>
        [System.Diagnostics.Conditional(UnityEditor)]
        public static void OnDebugLog(Label.LabelType type, Type classType, string contexts)
        {
            switch (type)
            {
                case Label.LabelType.Event:
#if UNITY_EDITOR
                    Debug.Log(LogBuilder.OnBuild(type, classType, contexts));
#endif
                    break;
                case Label.LabelType.Error:
#if UNITY_EDITOR
                    Debug.LogError(LogBuilder.OnBuild(type, classType, contexts));
#endif
                    break;
                case Label.LabelType.Warning:
#if UNITY_EDITOR
                    Debug.LogWarning(LogBuilder.OnBuild(type, classType, contexts));
#endif
                    break;
                case Label.LabelType.Success:
#if UNITY_EDITOR
                    Debug.Log(LogBuilder.OnBuild(type, classType, contexts));
#endif
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        #endregion
    }
}
