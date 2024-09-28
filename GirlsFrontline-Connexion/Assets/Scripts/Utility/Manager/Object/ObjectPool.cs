using System;
using System.Collections.Generic;
using GloryDay.Log;
using UnityEngine;

namespace Utility.Manager.Object
{
    #region DEFINED TYPE API

    using PoolDictionary = Dictionary<GameObject, Pool<GameObject>>;

    #endregion
    
    public class ObjectPool
    {
        private readonly PoolDictionary _instances = new PoolDictionary();
        private readonly PoolDictionary _clones = new PoolDictionary();

        private readonly Transform _transform;
        
        /// <param name="transform"> Default transform that will be assigned to the new object. </param>
        public ObjectPool(Transform transform)
        {
            _transform = transform;
        }
        
        /// <summary>
        /// Instantiate <see cref="GameObject"/> and set instance to disable.
        /// </summary>
        /// <param name="original"> An existing object to make a clone. </param>
        /// <param name="parent"> Parent that will be assigned to the new object. </param>
        /// <returns> The instantiated clone. </returns>
        private GameObject Instantiate(GameObject original, Transform parent)
        {
            parent = parent ?? _transform;
            var instance = UnityEngine.Object.Instantiate(original, parent, true);
            
            // Rename instantiated game object.
            var index = instance.name.IndexOf("(Clone)", StringComparison.Ordinal);
            if (index > 0)
            {
                instance.name = instance.name.Substring(0, index);
            }
            
            instance.SetActive(false);

            return instance;
        }

        /// <summary>
        /// Create new instance and add to object pool.
        /// </summary>
        /// <param name="original"> An existing object to make a clone. </param>
        /// <param name="parent"> Parent that will be assigned to the new object. </param>
        /// <param name="capacity"> Capacity of object pool. </param>
        public void Create(GameObject original, Transform parent, int capacity)
        {
            if (_instances.ContainsKey(original))
            {
                LogManager.LogError($"Pool for object type {original.name} has already been created");
            }

            // Instantiate new object to use
            var pool = new Pool<GameObject>(capacity, () => Instantiate(original, parent));
            _instances[original] = pool;
        }

        /// <summary>
        /// Release <see cref="GameObject"/> in <see cref="Pool{T}"/>.
        /// </summary>
        /// <param name="clone"> <see cref="GameObject"/> to release. </param>
        public void Release(GameObject clone)
        {
            // Object deactivate
            clone.SetActive(false);

            if (_clones.ContainsKey(clone))
            {
                // Release and remove deactivated object.
                _clones[clone].Release(clone);
                _clones.Remove(clone);
                return;
            }

            LogManager.LogError($"No pool contains the object {clone.name}");
        }

        /// <summary>
        /// Spawn <see cref="GameObject"/> has position and rotation.
        /// </summary>
        /// <param name="original"> An existing object to make a clone. </param>
        /// <param name="parent"> Parent that will be assigned to the new object. </param>
        /// <param name="position"> Position for the new object. </param>
        /// <param name="rotation"> Orientation of the new object. </param>
        /// <returns> The instantiated clone. </returns>
        public GameObject Spawn(GameObject original, Vector3? position, Quaternion? rotation, Transform parent)
        {
            // Object pool is not exist.
            if (_instances.ContainsKey(original) == false)
            {
                Create(original, parent ?? _transform, 1);
            }
            
            // Get original object.
            var instance = _instances[original];

            // Duplicate original object and set position, rotation and set duplicated object to enable.
            var clone = instance.Object;
            clone.transform.SetPositionAndRotation(position ?? Vector3.zero, rotation ?? Quaternion.identity);

            // Add activated object in object pool.
            _clones.Add(clone, instance);

            return clone;
        }

        public T Spawn<T>(GameObject original, Vector3? position, Quaternion? rotation, Transform parent) where T : MonoBehaviour
        {
            return Spawn(original, position, rotation, parent).GetComponent<T>();
        }
    }
}