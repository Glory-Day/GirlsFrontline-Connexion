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

        private static GameObject InstantiateObject(GameObject prefab, Transform parentTransform)
        {
            var instantiatedObject = Instantiate(prefab);

            if (parentTransform != null) prefab.transform.parent = parentTransform;

            instantiatedObject.SetActive(false);

            return instantiatedObject;
        }

        private void Create(GameObject prefab, int capacity, Transform parentTransform)
        {
            if (objectPool.originals.ContainsKey(prefab))
                LogManager.OnDebugLog(Label.LabelType.Error, typeof(ObjectManager),
                    $"Pool for object type {prefab.name} has already been created");

            var pool = new Pool<GameObject>(() => InstantiateObject(prefab, parentTransform),
                capacity);
            objectPool.originals[prefab] = pool;
        }

        private void Release(GameObject clone)
        {
            clone.SetActive(false);

            if (objectPool.clones.ContainsKey(clone))
            {
                objectPool.clones[clone].Release(clone);
                objectPool.clones.Remove(clone);
                return;
            }

            LogManager.OnDebugLog(Label.LabelType.Error, typeof(ObjectManager),
                $"No pool contains the object {clone.name}");
        }

        private GameObject Spawn(GameObject prefab, Transform parentTransform, Vector3? position,
                                 Quaternion? rotation)
        {
            if (!objectPool.originals.ContainsKey(prefab))
                Create(prefab, 1, parentTransform ? parentTransform : transform);

            var original = objectPool.originals[prefab];

            var clone = original.GetObject();
            clone.transform.SetPositionAndRotation(position ?? Vector3.zero, rotation ?? Quaternion.identity);
            clone.SetActive(true);

            objectPool.clones.Add(clone, original);

            return clone;
        }

        public static void OnCreate(GameObject prefab, int capacity, Transform parentTransform = null)
        {
            Instance.Create(prefab, capacity, parentTransform);
        }

        public static void OnRelease(GameObject clone)
        {
            Instance.Release(clone);
        }

        public GameObject OnSpawn(GameObject prefab, Transform parentTransform = null, Vector3? position = null,
                                  Quaternion? rotation = null)
        {
            return Instance.Spawn(prefab, parentTransform, position, rotation);
        }
    }
}
