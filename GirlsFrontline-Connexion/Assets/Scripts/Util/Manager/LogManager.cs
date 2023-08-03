using System;
using UnityEngine;
using Util.Log;

namespace Util.Manager
{
    public static class LogManager
    {
        #region CONSTANT FIELD

        private const string DevelopmentBuild = "DEVELOPMENT_BUILD";
        private const string UnityEditor      = "UNITY_EDITOR";

        #endregion

        #region UNITY EDITOR CONSOLE LOG METHOD API

        /// <summary>
        /// Outputs a administrator permission log to the console in <b>Unity Editor Console</b>
        /// </summary>
        /// <param name="contexts"> Contents of output log </param>
        [System.Diagnostics.Conditional(UnityEditor)]
        private static void UnityEditorLog(string contexts)
        {
#if UNITY_EDITOR
            
            Debug.LogWarning(Log.UnityEditor.LogBuilder.Build(contexts));
            
#endif
        }

        /// <summary>
        /// Outputs a log by <see cref="Label"/> to the console in <b>Unity Editor Console</b>
        /// </summary>
        /// <param name="label"> <see cref="Label"/> of log </param>
        /// <param name="type"> <see cref="Type"/> of the class where the log was called </param>
        /// <param name="contexts"> Contents of output log </param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Out of range exception in <see cref="Label"/>
        /// </exception>
        [System.Diagnostics.Conditional(UnityEditor)]
        private static void UnityEditorLog(Label label, Type type, string contexts)
        {
            var message = Log.UnityEditor.LogBuilder.Build(label, type, contexts);

            switch (label)
            {
                case Label.Called:
#if UNITY_EDITOR
                    
                    Debug.Log(message);
                    
#endif
                    break;
                case Label.Event:
#if UNITY_EDITOR
                    
                    Debug.Log(message);
                    
#endif
                    break;
                case Label.Error:
#if UNITY_EDITOR
                    
                    Debug.LogError(message);
                    
#endif
                    break;
                case Label.Success:
#if UNITY_EDITOR
                    
                    Debug.Log(message);
                    
#endif
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(label), label, null);
            }
        }

        #endregion

        #region DEVELOPMENT BUILD CONSOLE LOG METHOD API

        private const string DevelopmentBuildLogFilePath = @"/Build.log";

        /// <summary>
        /// Outputs a administrator permission log to the console in <b>Development Build</b>
        /// </summary>
        /// <param name="contexts"> Contents of output log </param>
        [System.Diagnostics.Conditional(DevelopmentBuild)]
        private static void DevelopmentBuildLog(string contexts)
        {
#if DEVELOPMENT_BUILD

            using (var writer = new StreamWriter(
                       Application.persistentDataPath + DevelopmentBuildLogFilePath, true))
            {
                writer.WriteLine(Log.DevelopmentBuild.LogBuilder.Build(contexts));
            }
            
#endif
        }

        /// <summary>
        /// Outputs a log by <see cref="Label"/> to the console in <b>Development Build</b>
        /// </summary>
        /// <param name="label"> <see cref="Label"/> of log </param>
        /// <param name="type"> <see cref="Type"/> of the class where the log was called </param>
        /// <param name="contexts"> Contents of output log </param>
        [System.Diagnostics.Conditional(DevelopmentBuild)]
        private static void DevelopmentBuildLog(Label label, Type type, string contexts)
        {
#if DEVELOPMENT_BUILD

            using (var writer = new StreamWriter(
                       Application.persistentDataPath + DevelopmentBuildLogFilePath, true))
            {
                writer.WriteLine(Log.DevelopmentBuild.LogBuilder.Build(label, type, contexts));
            }
            
#endif
        }

        #endregion

        #region STATIC METHOD API

        /// <summary>
        /// Outputs a administrator permission log
        /// </summary>
        /// <param name="contexts"> Contents of output log </param>
        [System.Diagnostics.Conditional(DevelopmentBuild)] 
        [System.Diagnostics.Conditional(UnityEditor)]
        public static void OnDebugLog(string contexts)
        {
#if UNITY_EDITOR
            
            UnityEditorLog(contexts);
            
#elif DEVELOPMENT_BUILD

            DevelopmentBuildLog(contexts);
            
#endif
        }

        /// <summary>
        /// Outputs a log by <see cref="Label"/>
        /// </summary>
        /// <param name="label"> <see cref="Label"/> of log </param>
        /// <param name="type"> <see cref="Type"/> of the class where the log was called </param>
        /// <param name="contexts"> Contents of output <b>Log</b> </param>
        [System.Diagnostics.Conditional(DevelopmentBuild)] 
        [System.Diagnostics.Conditional(UnityEditor)]
        public static void OnDebugLog(Label label, Type type, string contexts)
        {
#if UNITY_EDITOR
            
            UnityEditorLog(label, type, contexts);
            
#elif DEVELOPMENT_BUILD

            DevelopmentBuildLog(label, type, contexts);
            
#endif
        }

        #endregion
    }
}
