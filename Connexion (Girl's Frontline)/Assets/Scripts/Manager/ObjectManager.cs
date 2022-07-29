#region NAMESPACE API

using System.Collections.Generic;
using UnityEngine;
using Manager.Util.ObjectPool;
using Label = Manager.Log.Label;

#endregion

namespace Manager
{
    public class ObjectManager : Singleton<ObjectManager>
    {
        private struct ObjectPool
        {
            public Dictionary<GameObject, Pool<GameObject>> originals;
            public Dictionary<GameObject, Pool<GameObject>> clones;
        }

        /// <summary>
        /// Object pool instance
        /// </summary>
        private ObjectPool objectPool;

        protected ObjectManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }

        // Start is called before the first frame update
        private void Start()
        {
            objectPool.originals = new Dictionary<GameObject, Pool<GameObject>>();
            objectPool.clones = new Dictionary<GameObject, Pool<GameObject>>();
        }

        /// <summary>
        /// Instantiate object and set object to disable
        /// </summary>
        /// <param name="prefab"> Object to instantiate </param>
        /// <param name="parentTransform"> Parent transform of instantiated object </param>
        /// <returns> Instantiated object </returns>
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
        /// Create new object and put to <b>Object Pool</b>
        /// </summary>
        /// <param name="prefab"> Object to instantiate </param>
        /// <param name="capacity"> Capacity of pool </param>
        /// <param name="parentTransform"> Parent transform of instantiated object </param>
        private void Create(GameObject prefab, int capacity, Transform parentTransform)
        {
            if (objectPool.originals.ContainsKey(prefab))
                LogManager.OnDebugLog(Label.LabelType.Error, typeof(ObjectManager),
                    $"Pool for object type {prefab.name} has already been created");

            // Instantiate new object to use
            var pool = new Pool<GameObject>(
                () => InstantiateObject(prefab, parentTransform), capacity);
            objectPool.originals[prefab] = pool;
        }

        /// <summary>
        /// Release object in <b>Object Pool</b>
        /// </summary>
        /// <param name="clone"> Object to release </param>
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

            LogManager.OnDebugLog(Label.LabelType.Error, typeof(ObjectManager),
                $"No pool contains the object {clone.name}");
        }

        /// <summary>
        /// Spawn object has position and rotation
        /// </summary>
        /// <param name="prefab"> Object to spawn </param>
        /// <param name="parentTransform"> Parent transform of spawned object </param>
        /// <param name="position"> Position of spawned object </param>
        /// <param name="rotation"> Rotation of spawned object </param>
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
            var clone = original.GetObject();
            clone.transform.SetPositionAndRotation(position ?? Vector3.zero, rotation ?? Quaternion.identity);
            clone.SetActive(true);

            // Add activated object in object pool
            objectPool.clones.Add(clone, original);

            return clone;
        }

        /// <summary>
        /// Create new object and put to <b>Object Pool</b>
        /// </summary>
        /// <param name="prefab"> Object to instantiate </param>
        /// <param name="capacity"> Capacity of pool </param>
        /// <param name="parentTransform"> Parent transform of instantiated object </param>
        public static void OnCreate(GameObject prefab, int capacity, Transform parentTransform = null)
        {
            Instance.Create(prefab, capacity, parentTransform);
        }

        /// <summary>
        /// Release object in <b>Object Pool</b>
        /// </summary>
        /// <param name="clone"> Object to release </param>
        public static void OnRelease(GameObject clone)
        {
            Instance.Release(clone);
        }

        /// <summary>
        /// Spawn object has position and rotation
        /// </summary>
        /// <param name="prefab"> Object to spawn </param>
        /// <param name="parentTransform"> Parent transform of spawned object </param>
        /// <param name="position"> Position of spawned object </param>
        /// <param name="rotation"> Rotation of spawned object </param>
        public GameObject OnSpawn(GameObject prefab, Transform parentTransform = null, Vector3? position = null,
                                  Quaternion? rotation = null)
        {
            return Instance.Spawn(prefab, parentTransform, position, rotation);
        }
    }
}
