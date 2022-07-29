#region NAMESPACE API

using System;
using System.IO;
using UnityEngine;
using Manager.Log;

#endregion

namespace Manager
{
    /// <summary>
    /// Manager that manages the entire log for debugging
    /// </summary>
    public class LogManager : Singleton<LogManager>
    {
        private Log.UnityEditor.LogBuilder      unityEditorLogBuilder;
        private Log.DevelopmentBuild.LogBuilder developmentBuildLogBuilder;
        
        private const string DevelopmentBuild = "DEVELOPMENT_BUILD";
        private const string UnityEditor      = "UNITY_EDITOR";

        protected LogManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }

        #region UNITY EDITOR CONSOLE API

        /// <summary>
        /// Outputs a administrator permission log to the console in <b>Unity Editor</b>
        /// </summary>
        /// <param name="contexts"> Contents of the log </param>
        [System.Diagnostics.Conditional(UnityEditor)]
        private void UnityEditorLog(string contexts)
        {
#if UNITY_EDITOR
            Debug.LogWarning(unityEditorLogBuilder.Build(contexts));
#endif
        }

        /// <summary>
        /// Outputs a general log to the console in <b>Unity Editor</b>
        /// </summary>
        /// <param name="classType"> Type of the class where the log was called </param>
        /// <param name="contexts"> Contents of the log </param>
        [System.Diagnostics.Conditional(UnityEditor)]
        private void UnityEditorLog(Type classType, string contexts)
        {
#if UNITY_EDITOR
            Debug.Log(unityEditorLogBuilder.Build(classType, contexts));
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
        private void UnityEditorLog(Label.LabelType type, Type classType, string contexts)
        {
            var message = unityEditorLogBuilder.Build(type, classType, contexts);

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

        private const string DevelopmentBuildLogFilePath = @"/Build.log";

        /// <summary>
        /// Outputs a administrator permission log to the console in <b>Unity Application</b> after built
        /// </summary>
        /// <param name="contexts"> Contents of the log </param>
        [System.Diagnostics.Conditional(DevelopmentBuild)]
        private void DevelopmentBuildLog(string contexts)
        {
#if DEVELOPMENT_BUILD
            using (var writer = new StreamWriter(Application.persistentDataPath + DevelopmentBuildLogFilePath,
                       true))
            {
                writer.WriteLine(developmentBuildLogBuilder.Build(contexts));
            }
#endif
        }

        /// <summary>
        /// Outputs a general log to the console in <b>Unity Application</b> after built
        /// </summary>
        /// <param name="classType"> Type of the class where the log was called </param>
        /// <param name="contexts"> Contents of the log </param>
        [System.Diagnostics.Conditional(DevelopmentBuild)]
        private void DevelopmentBuildLog(Type classType, string contexts)
        {
#if DEVELOPMENT_BUILD
            using (var writer = new StreamWriter(Application.persistentDataPath + DevelopmentBuildLogFilePath,
                       true))
            {
                writer.WriteLine(developmentBuildLogBuilder.Build(classType, contexts));
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
        private void DevelopmentBuildLog(Label.LabelType type, Type classType, string contexts)
        {
#if DEVELOPMENT_BUILD
            using (var writer = new StreamWriter(Application.persistentDataPath + DevelopmentBuildLogFilePath,
                       true))
            {
                writer.WriteLine(developmentBuildLogBuilder.Build(type, classType, contexts));
            }
#endif
        }

        #endregion

        [System.Diagnostics.Conditional(DevelopmentBuild)]
        [System.Diagnostics.Conditional(UnityEditor)]
        public static void OnInitializeLogBuilders()
        {
            Instance.unityEditorLogBuilder      = new Log.UnityEditor.LogBuilder();
            Instance.developmentBuildLogBuilder = new Log.DevelopmentBuild.LogBuilder();
        }

        /// <summary>
        /// Outputs a administrator permission log
        /// </summary>
        /// <param name="contexts"> Contents of the log </param>
        [System.Diagnostics.Conditional(DevelopmentBuild)] 
        [System.Diagnostics.Conditional(UnityEditor)]
        public static void OnDebugLog(string contexts)
        {
#if UNITY_EDITOR
            Instance.UnityEditorLog(contexts);
#elif DEVELOPMENT_BUILD
            Instance.DevelopmentBuildLog(contexts);
#endif
        }

        /// <summary>
        /// Outputs a general log
        /// </summary>
        /// <param name="classType"> Type of the class where the log was called </param>
        /// <param name="contexts"> Contents of the log </param>
        [System.Diagnostics.Conditional(DevelopmentBuild)] 
        [System.Diagnostics.Conditional(UnityEditor)]
        public static void OnDebugLog(Type classType, string contexts)
        {
#if UNITY_EDITOR
            Instance.UnityEditorLog(classType, contexts);
#elif DEVELOPMENT_BUILD
            Instance.DevelopmentBuildLog(classType, contexts);
#endif
        }

        /// <summary>
        /// Outputs a specific log
        /// </summary>
        /// <param name="type"> Type of Log </param>
        /// <param name="classType"> Type of the class where the log was called </param>
        /// <param name="contexts"> Contents of the log </param>
        [System.Diagnostics.Conditional(DevelopmentBuild)] 
        [System.Diagnostics.Conditional(UnityEditor)]
        public static void OnDebugLog(Label.LabelType type, Type classType, string contexts)
        {
#if UNITY_EDITOR
            Instance.UnityEditorLog(type, classType, contexts);
#elif DEVELOPMENT_BUILD
            Instance.DevelopmentBuildLog(type, classType, contexts);
#endif
        }
    }
}
