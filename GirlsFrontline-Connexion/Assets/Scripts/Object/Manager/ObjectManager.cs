using System.Collections.Generic;
using UnityEngine;
using Util.Manager;
using Util.Log;
using Util.Manager.Object;


namespace Object.Manager
{
    public class ObjectManager : Singleton<ObjectManager>
    {
        private struct ObjectPool
        {
            public Dictionary<GameObject, Pool<GameObject>> originals;
            public Dictionary<GameObject, Pool<GameObject>> clones;
        }

        private ObjectPool objectPool;

        protected ObjectManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }

        private void Start()
        {
            LogManager.LogCalled();
            
            objectPool.originals = new Dictionary<GameObject, Pool<GameObject>>();
            objectPool.clones = new Dictionary<GameObject, Pool<GameObject>>();
        }
        
        /// <summary>
        /// Instantiate <see cref="GameObject"/> and set <see cref="GameObject"/> to disable
        /// </summary>
        /// <param name="prefab"> <see cref="GameObject"/> to instantiate </param>
        /// <param name="parentTransform">
        /// Parent <see cref="Transform"/> of instantiated <see cref="GameObject"/>
        /// </param>
        /// <returns> Instantiated <see cref="GameObject"/> </returns>
        private static GameObject InstantiateObject(GameObject prefab, Transform parentTransform)
        {
            var instantiatedObject = Instantiate(prefab);

            if (parentTransform != null)
            {
                prefab.transform.parent = parentTransform;
            }

            instantiatedObject.SetActive(false);

            return instantiatedObject;
        }

        /// <summary>
        /// Create new <see cref="GameObject"/> and put to <see cref="ObjectPool"/>
        /// </summary>
        /// <param name="prefab"> <see cref="GameObject"/> to instantiate </param>
        /// <param name="capacity"> Capacity of <see cref="Pool{T}"/> </param>
        /// <param name="parentTransform">
        /// Parent <see cref="Transform"/> of instantiated <see cref="GameObject"/>
        /// </param>
        private void Create(GameObject prefab, int capacity, Transform parentTransform)
        {
            if (objectPool.originals.ContainsKey(prefab))
                LogManager.LogError($"Pool for object type {prefab.name} has already been created");

            // Instantiate new object to use
            var pool = new Pool<GameObject>(
                () => InstantiateObject(prefab, parentTransform), capacity);
            objectPool.originals[prefab] = pool;
        }

        /// <summary>
        /// Release <see cref="GameObject"/> in <see cref="ObjectPool"/>
        /// </summary>
        /// <param name="clone"> <see cref="GameObject"/> to release </param>
        private void Release(GameObject clone)
        {
            // Object deactivate
            clone.SetActive(false);

            if (objectPool.clones.ContainsKey(clone))
            {
                // Release and remove deactivated object
                objectPool.clones[clone].Release(clone);
                objectPool.clones.Remove(clone);
                return;
            }

            LogManager.LogError($"No pool contains the object {clone.name}");
        }

        /// <summary>
        /// Spawn <see cref="GameObject"/> has position and rotation
        /// </summary>
        /// <param name="prefab"> <see cref="GameObject"/> to spawn </param>
        /// <param name="parentTransform"> Parent <see cref="Transform"/> of spawned <see cref="GameObject"/> </param>
        /// <param name="position"> Position of spawned <see cref="GameObject"/> </param>
        /// <param name="rotation"> Rotation of spawned <see cref="GameObject"/> </param>
        /// <returns> Spawned object </returns>
        private GameObject Spawn(GameObject prefab, Transform parentTransform, Vector3? position, Quaternion? rotation)
        {
            // Object pool is not exist
            if (!objectPool.originals.ContainsKey(prefab))
            {
                Create(prefab, 1, parentTransform ? parentTransform : transform);
            }
            
            // Get original object
            var original = objectPool.originals[prefab];

            // Duplicate original object and set position, rotation and set duplicated object to enable
            var clone = original.Object;
            clone.transform.SetPositionAndRotation(position ?? Vector3.zero, rotation ?? Quaternion.identity);
            clone.SetActive(true);

            // Add activated object in object pool
            objectPool.clones.Add(clone, original);

            return clone;
        }

        #region STATIC METHOD API

        /// <summary>
        /// Create new <see cref="GameObject"/> and put to <see cref="ObjectPool"/>
        /// </summary>
        /// <param name="prefab"> <see cref="GameObject"/> to instantiate </param>
        /// <param name="capacity"> Capacity of <see cref="Pool{T}"/> </param>
        /// <param name="parentTransform">
        /// Parent <see cref="Transform"/> of instantiated <see cref="GameObject"/>
        /// </param>
        public static void OnCreate(GameObject prefab, int capacity, Transform parentTransform = null)
        {
            Instance.Create(prefab, capacity, parentTransform);
        }

        /// <summary>
        /// Release <see cref="GameObject"/> in <see cref="ObjectPool"/>
        /// </summary>
        /// <param name="clone"> <see cref="GameObject"/> to release </param>
        public static void OnRelease(GameObject clone)
        {
            Instance.Release(clone);
        }

        /// <summary>
        /// Spawn <see cref="GameObject"/> has position and rotation
        /// </summary>
        /// <param name="prefab"> <see cref="GameObject"/> to spawn </param>
        /// <param name="parentTransform"> Parent <see cref="Transform"/> of spawned <see cref="GameObject"/> </param>
        /// <param name="position"> Position of spawned <see cref="GameObject"/> </param>
        /// <param name="rotation"> Rotation of spawned <see cref="GameObject"/> </param>
        public GameObject OnSpawn(GameObject prefab, Transform parentTransform = null, Vector3? position = null,
                                  Quaternion? rotation = null)
        {
            return Instance.Spawn(prefab, parentTransform, position, rotation);
        }

        #endregion
    }
}
