using GloryDay.Log;
using GloryDay.Utility;
using UnityEngine;
using Utility.Manager.Object;

namespace Utility.Manager
{
    public class ObjectManager : SingletonGameObject<ObjectManager>
    {
        private ObjectPool _objectPool;
        
        protected override void OnAwake()
        {
            LogManager.LogProgress();

            _objectPool = new ObjectPool(transform);
        }
        
        #region STATIC METHOD API
        
        /// <summary>
        /// Create new <see cref="GameObject"/> and put to <see cref="Pool{T}"/>
        /// </summary>
        /// <param name="original"> <see cref="GameObject"/> to instantiate </param>
        /// <param name="capacity"> Capacity of <see cref="Pool{T}"/> </param>
        public static void OnCreate(GameObject original, int capacity)
        {
            Instance._objectPool.Create(original, null, capacity);
        }
        
        /// <summary>
        /// Create new <see cref="GameObject"/> and put to <see cref="Pool{T}"/>
        /// </summary>
        /// <param name="original"> <see cref="GameObject"/> to instantiate </param>
        /// <param name="parent"> Parent <see cref="Transform"/> of instantiated <see cref="GameObject"/> </param>
        /// <param name="capacity"> Capacity of <see cref="Pool{T}"/> </param>
        public static void OnCreate(GameObject original, Transform parent, int capacity)
        {
            Instance._objectPool.Create(original, parent, capacity);
        }

        /// <summary>
        /// Spawn <see cref="GameObject"/> has position and rotation
        /// </summary>
        /// <param name="original"> <see cref="GameObject"/> to spawn </param>
        /// <param name="position"> Position of spawned <see cref="GameObject"/> </param>
        /// <param name="rotation"> Rotation of spawned <see cref="GameObject"/> </param>
        /// <param name="parent"> Parent <see cref="Transform"/> of spawned <see cref="GameObject"/> </param>
        public static GameObject OnSpawn(GameObject original, Vector3? position = null,
                                         Quaternion? rotation = null, Transform parent = null)
        {
            return Instance._objectPool.Spawn(original, position, rotation, parent);
        }

        public static T OnSpawn<T>(GameObject original, Vector3? position = null, 
                                   Quaternion? rotation = null, Transform parent = null) where T : MonoBehaviour
        {
            return Instance._objectPool.Spawn<T>(original, position, rotation, parent);
        }
        
        /// <summary>
        /// Release <see cref="GameObject"/> in <see cref="Pool{T}"/>
        /// </summary>
        /// <param name="clone"> <see cref="GameObject"/> to release </param>
        public static void OnRelease(GameObject clone)
        {
            Instance._objectPool.Release(clone);
        }
        
        #endregion
    }
}
