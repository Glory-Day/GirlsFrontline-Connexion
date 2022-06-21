using System;
using UnityEngine;

using Manager.Log.Console;

namespace Manager.Log
{
    public class LogManager : Singleton<LogManager>
    {
        protected LogManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }

        #region CONSOLE STATIC API

        /// <summary>
        /// General log information is output to the console
        /// </summary>
        /// <param name="classType"> The type of the class where the log was called </param>
        /// <param name="contexts"> Contents of the log </param>
        public static void OnDebugLog(Type classType, string contexts) => 
            Debug.Log(LogBuilder.OnBuild(classType, contexts));
        
        /// <summary>
        /// Specific log information is output to the console
        /// </summary>
        /// <param name="type"> Type of Log </param>
        /// <param name="classType"> The type of the class where the log was called </param>
        /// <param name="contexts"> Contents of the log </param>
        public static void OnDebugLog(Label.LabelType type, Type classType, string contexts) => 
            Debug.Log(LogBuilder.OnBuild(type, classType, contexts));

        #endregion
    }
}
