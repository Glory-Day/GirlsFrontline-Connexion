using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Manager
{
    [SuppressMessage("ReSharper", "StaticMemberInGenericType")]
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        // Check to see if we're about to be destroyed
        private static bool _quited;

        private static object Locked => new Object();
        private static T _instance;

        // Access singleton instance through this propriety
        public static T Instance
        {
            get
            {
                // At the end of the game than object OnDestroy() of singleton can also be first
                // The singleton is gameObject. OnDestroy() doesn't use it or If uses it, let's make a null check
                if (_quited)
                {
                    Debug.LogWarning("<b>[Singleton]</b> Instance '" + typeof(T) + 
                                     "' already destroyed. Returning null.");
                    
                    return null;
                }

                // Double-checked locking (Thread Safe)
                lock (Locked)
                {
                    if (_instance != null)
                    {
                        return _instance;
                    }

                    // Search for existing instance
                    _instance = FindObjectOfType(typeof(T)) as T;

                    if (_instance != null)
                    {
                        return _instance;
                    }

                    // If it hasn't been created yet, create an instance
                    var gameObject = new GameObject();
                    _instance = gameObject.AddComponent<T>();
                    gameObject.name = typeof(T) + " (Singleton)";

                    // Make instance persistent
                    DontDestroyOnLoad(gameObject);

                    return _instance;
                }
            }
        }

        private void OnApplicationQuit()
        {
            _quited = true;
        }
        
        private void OnDestroy() 
        {
            _quited = true;
        }
    }
}
