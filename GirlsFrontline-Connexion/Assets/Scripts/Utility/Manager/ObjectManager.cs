using System.Collections.Generic;
using UnityEngine;
using GloryDay.Log;
using GloryDay.Utility;
using Utility.Manager.Object;

namespace Utility.Manager
{
    public class ObjectManager : SingletonGameObject<ObjectManager>
    {
        private Dictionary<GameObject, Pool<GameObject>> _instances;
        private Dictionary<GameObject, Pool<GameObject>> _clones;

        protected ObjectManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }

        private void Start()
        {
            LogManager.LogProgress();
            
            _instances = new Dictionary<GameObject, Pool<GameObject>>();
            _clones = new Dictionary<GameObject, Pool<GameObject>>();
        }
        
        /// <summary>
        /// Instantiate game object and set instance to disable
        /// </summary>
        /// <param name="original"> An existing object to make a clone </param>
        /// <param name="parent"> Parent that will be assigned to the new object </param>
        /// <returns> The instantiated clone </returns>
        private GameObject Instantiate(GameObject original, Transform parent)
        {
            var instance = UnityEngine.Object.Instantiate(original, parent != null ? parent : transform);
            instance.SetActive(false);

            return instance;
        }

        /// <summary>
        /// Create new instance and add to object pool
        /// </summary>
        /// <param name="original"> An existing object to make a clone </param>
        /// <param name="parent"> Parent that will be assigned to the new object </param>
        /// <param name="capacity"> Capacity of object pool </param>
        private void Create(GameObject original, Transform parent, int capacity)
        {
            if (_instances.ContainsKey(original))
                LogManager.LogError($"Pool for object type {original.name} has already been created");

            // Instantiate new object to use
            var pool = new Pool<GameObject>(capacity, () => Instantiate(original, parent));
            _instances[original] = pool;
        }

        /// <summary>
        /// Release <see cref="GameObject"/> in <see cref="ObjectPool"/>
        /// </summary>
        /// <param name="clone"> <see cref="GameObject"/> to release </param>
        private void Release(GameObject clone)
        {
            // Object deactivate
            clone.SetActive(false);

            if (_clones.ContainsKey(clone))
            {
                // Release and remove deactivated object
                _clones[clone].Release(clone);
                _clones.Remove(clone);
                return;
            }

            LogManager.LogError($"No pool contains the object {clone.name}");
        }

        /// <summary>
        /// Spawn <see cref="GameObject"/> has position and rotation
        /// </summary>
        /// <param name="original"> An existing object to make a clone </param>
        /// <param name="parent"> Parent that will be assigned to the new object </param>
        /// <param name="position"> Position for the new object </param>
        /// <param name="rotation"> Orientation of the new object </param>
        /// <returns> The instantiated clone </returns>
        private GameObject Spawn(GameObject original, Vector3? position, Quaternion? rotation, Transform parent)
        {
            // Object pool is not exist
            if (_instances.ContainsKey(original) == false)
            {
                Create(original, parent ? parent : transform, 1);
            }
            
            // Get original object
            var instance = _instances[original];

            // Duplicate original object and set position, rotation and set duplicated object to enable
            var clone = instance.Object;
            clone.transform.SetPositionAndRotation(position ?? Vector3.zero, rotation ?? Quaternion.identity);
            clone.SetActive(true);

            // Add activated object in object pool
            _clones.Add(clone, instance);

            return clone;
        }

        #region STATIC METHOD API

        /// <summary>
        /// Create new <see cref="GameObject"/> and put to <see cref="ObjectPool"/>
        /// </summary>
        /// <param name="prefab"> <see cref="GameObject"/> to instantiate </param>
        /// <param name="capacity"> Capacity of <see cref="Pool{T}"/> </param>
        public static void OnCreate(GameObject prefab, int capacity)
        {
            Instance.Create(prefab, null, capacity);
        }
        
        /// <summary>
        /// Create new <see cref="GameObject"/> and put to <see cref="ObjectPool"/>
        /// </summary>
        /// <param name="prefab"> <see cref="GameObject"/> to instantiate </param>
        /// <param name="parent">
        /// Parent <see cref="Transform"/> of instantiated <see cref="GameObject"/>
        /// </param>
        /// <param name="capacity"> Capacity of <see cref="Pool{T}"/> </param>
        public static void OnCreate(GameObject prefab, Transform parent, int capacity)
        {
            Instance.Create(prefab, parent, capacity);
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
        /// <param name="position"> Position of spawned <see cref="GameObject"/> </param>
        /// <param name="rotation"> Rotation of spawned <see cref="GameObject"/> </param>
        /// <param name="parent"> Parent <see cref="Transform"/> of spawned <see cref="GameObject"/> </param>
        public GameObject OnSpawn(GameObject prefab, 
                                  Vector3? position = null, Quaternion? rotation = null, Transform parent = null)
        {
            return Instance.Spawn(prefab, position, rotation, parent);
        }

        #endregion
    }
}
