using System.Text.RegularExpressions;
using GloryDay.Debug.Log;
using UnityEngine;

namespace GloryDay
{
    public class SingletonGameObject<T> : SingletonBehavior where T : MonoBehaviour
    {
        #region CONSTANT FIELD API

        private const string Suffix = " (Singleton)";

        private const string Pattern = "/([A-Z])(?=[A-Z][a-z])|([a-z])(?=[A-Z])/g";
        private const string Replacement = "$& ";

        #endregion
        
        private static T _instance;
        
        protected sealed override void Awake()
        {
            LogManager.LogProgress();
            
            if (_instance is null)
            {
                _instance = this as T;
            }
            else if (_instance != this)
            {
                Destroy(gameObject);
            }
            
            base.Awake();
        }
        
        protected static T Instance
        {
            get
            {
                if (IsQuitting)
                {
                    UnityEngine.Debug.LogWarning("<color=#F7E600><b>[WARNING][Singleton]</b> " +
                                     $"Instance of type {typeof(T)} already destroyed on application quit. " +
                                     "Returning null." +
                                     "</color>");
                    
                    return null;
                }

                // Double-checked locking (Thread Safe)
                lock (Locker)
                {
                    if (_instance is null == false)
                    {
                        return _instance;
                    }

                    // Search for all existing singleton instance.
                    var instances = FindObjectsOfType<T>();

                    var length = instances.Length;
                    if (0 < length)
                    {
                        if (length == 1)
                        {
                            return _instance = instances[0];
                        }

                        UnityEngine.Debug.LogWarning("<color=#F7E600><b>[WARNING][Singleton]</b> " +
                                                    $"There should never be more than one singleton instance of type {typeof(T)} in the scene, but <b>{length}</b> were found. " +
                                                    "The first instance found will be used, and all others will be destroyed." +
                                                    "</color>");

                        for (var i = 1; i < length; i++)
                        {
                            Destroy(instances[i]);
                        }

                        return _instance = instances[0];
                    }

                    // If it hasn't been created yet, create an instance.
                    var gameObject = new GameObject();
                    _instance = gameObject.AddComponent<T>();
                    
                    // Set singleton instance name.
                    var name = Regex.Replace(typeof(T).Name, Pattern, Replacement);
                    gameObject.name = name + Suffix;
                    
                    UnityEngine.Debug.Log("<color=#F8F8FF><b>[Singleton]</b> " +
                                               "An instance is needed in the scene and no existing instances were found, so a new instance will be created." +
                                               "</color>");

                    return _instance;
                }
            }
        }
    }
}
