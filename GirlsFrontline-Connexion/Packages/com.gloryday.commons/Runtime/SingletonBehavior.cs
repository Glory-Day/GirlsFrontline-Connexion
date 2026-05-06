using UnityEngine;
using UnityEngine.SceneManagement;

namespace GloryDay.Utility
{
    public class SingletonBehavior : MonoBehaviour
    {
        // Flag that sets whether to maintain singleton game objects during scene switching.
        [SerializeField]
        private bool isPersistent = true;

        // Typically, a singleton is removed at the end of the app.
        // Since Unity removes objects in random order at this time, when the singleton object is already removed and
        // approaches the singleton object from the outside, the singleton object is created again.
        // So to prevent this, we add a flag to check if the singleton object is being removed.
        protected static bool IsQuitting;

        // Used for thread safe.
        protected static readonly object Locker = new object();

        protected virtual void Awake()
        {
            if (isPersistent)
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        protected virtual void Start()
        {
            // Call when initialization of a singleton instance is required in the changed scene.
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        protected virtual void OnDestroy()
        {
            IsQuitting = true;

            if (isPersistent)
            {
                SceneManager.sceneLoaded -= OnSceneLoaded;
            }
        }

        protected virtual void OnApplicationQuit()
        {
            IsQuitting = true;
        }

        protected virtual void OnSceneLoaded(Scene scene, LoadSceneMode mode) { }
    }
}
