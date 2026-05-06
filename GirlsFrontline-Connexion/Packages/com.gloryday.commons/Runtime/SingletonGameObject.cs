using System.Text.RegularExpressions;
using UnityEngine;

namespace GloryDay.Utility
{
    public class SingletonGameObject<T> : SingletonBehavior where T : MonoBehaviour
    {
        #region CONSTANT FIELD API

        private const string Suffix = " (Singleton)";

        private const string Pattern = "/([A-Z])(?=[A-Z][a-z])|([a-z])(?=[A-Z])/g";
        private const string Replacement = "$& ";

        #endregion

        private static T _instance;

        protected override void Awake()
        {
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
                    Debug.LogWarning($"Instance of type {typeof(T)} already destroyed on application quit. Returning null.");

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

                        Debug.LogWarning($"There should never be more than one singleton instance of type {typeof(T)} in the scene, but <b>{length}</b> were found. The first instance found will be used, and all others will be destroyed.");

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

                    Debug.Log("An instance is needed in the scene and no existing instances were found, so a new instance will be created.");

                    return _instance;
                }
            }
        }
    }
}
