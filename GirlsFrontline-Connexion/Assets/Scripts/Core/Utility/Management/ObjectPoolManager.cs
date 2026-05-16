using GloryDay.Debug;
using GloryDay.Utility;
using UnityEngine;
using Core.Utility.Management.Object;

namespace Core.Utility.Management
{
    public class ObjectPoolManager : SingletonGameObject<ObjectPoolManager>
    {
        private ObjectPool _objectPool;

        private void CreateObjectPool_Internal()
        {
            _objectPool = new ObjectPool(transform);
        }

        #region STATIC METHOD API

        public static void CreateObjectPool()
        {
            Console.LogProgress();

            Instance.CreateObjectPool_Internal();
        }

        /// <summary>
        /// Create new <see cref="GameObject"/> and put to <see cref="Pool{T}"/>
        /// </summary>
        /// <param name="original"> <see cref="GameObject"/> to instantiate </param>
        /// <param name="capacity"> Capacity of <see cref="Pool{T}"/> </param>
        public static void Create(GameObject original, int capacity)
        {
            Console.LogProgress();

            Instance._objectPool.Create(original, null, capacity);
        }

        /// <summary>
        /// Create new <see cref="GameObject"/> and put to <see cref="Pool{T}"/>
        /// </summary>
        /// <param name="original"> <see cref="GameObject"/> to instantiate </param>
        /// <param name="parent"> Parent <see cref="Transform"/> of instantiated <see cref="GameObject"/> </param>
        /// <param name="capacity"> Capacity of <see cref="Pool{T}"/> </param>
        public static void Create(GameObject original, Transform parent, int capacity)
        {
            Console.LogProgress();

            Instance._objectPool.Create(original, parent, capacity);
        }

        /// <summary>
        /// Spawn <see cref="GameObject"/> has position and rotation
        /// </summary>
        /// <param name="original"> <see cref="GameObject"/> to spawn </param>
        /// <param name="position"> Position of spawned <see cref="GameObject"/> </param>
        /// <param name="rotation"> Rotation of spawned <see cref="GameObject"/> </param>
        /// <param name="parent"> Parent <see cref="Transform"/> of spawned <see cref="GameObject"/> </param>
        public static GameObject Spawn(GameObject original, Vector3? position = null,
                                       Quaternion? rotation = null, Transform parent = null)
        {
            Console.LogProgress();

            return Instance._objectPool.Spawn(original, position, rotation, parent);
        }

        public static T Spawn<T>(GameObject original, Vector3? position = null,
                                 Quaternion? rotation = null, Transform parent = null) where T : MonoBehaviour
        {
            Console.LogProgress();

            return Instance._objectPool.Spawn<T>(original, position, rotation, parent);
        }

        /// <summary>
        /// Release <see cref="GameObject"/> in <see cref="Pool{T}"/>
        /// </summary>
        /// <param name="clone"> <see cref="GameObject"/> to release </param>
        public static void Release(GameObject clone)
        {
            Console.LogProgress();

            Instance._objectPool.Release(clone);
        }

        #endregion
    }
}
