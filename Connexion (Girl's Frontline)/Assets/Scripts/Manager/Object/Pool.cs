#region NAMESPACE API

using System;
using System.Collections.Generic;
using Label = Manager.Log.Label;

#endregion

namespace Manager.Object
{
    /// <summary>
    /// Pool for using objects while saving memory
    /// </summary>
    /// <typeparam name="T"> Type of contained object </typeparam>
    public class Pool<T>
    {
        /// <summary>
        /// List to save object container
        /// </summary>
        private readonly List<ObjectContainer<T>> objectContainers;

        /// <summary>
        /// Pool to contain object
        /// </summary>
        private readonly Dictionary<T, ObjectContainer<T>> pool;

        /// <summary>
        /// <b>UnityEngine.Instantiate</b> Method
        /// </summary>
        private readonly Func<T> instantiateObjectMethod;

        /// <summary>
        /// Index of used object container
        /// </summary>
        private int objectContainerIndex;

        /// <summary>
        /// Object pool constructor
        /// </summary>
        /// <param name="instantiateObjectMethod"> <b>UnityEngine.Instantiate</b> Method </param>
        /// <param name="capacity"> Initial capacity </param>
        public Pool(Func<T> instantiateObjectMethod, int capacity)
        {
            // Initialize object containers and pool
            objectContainers = new List<ObjectContainer<T>>(capacity);
            pool = new Dictionary<T, ObjectContainer<T>>(capacity);

            // Initialize object containers
            InitializeObjectContainers(capacity);

            this.instantiateObjectMethod = instantiateObjectMethod;
        }

        /// <summary>
        /// Initialize object containers
        /// </summary>
        /// <param name="capacity"> Initial capacity </param>
        private void InitializeObjectContainers(int capacity)
        {
            for (var i = 0; i < capacity; i++) CreateObjectContainer();
        }

        /// <summary>
        /// Create object container
        /// </summary>
        /// <returns> Created object container instance </returns>
        private ObjectContainer<T> CreateObjectContainer()
        {
            var objectContainer = new ObjectContainer<T>(instantiateObjectMethod());
            objectContainers.Add(objectContainer);

            return objectContainer;
        }

        /// <summary>
        /// Get object in object container for use and add new object container if all object is used in pool
        /// </summary>
        /// <returns> Object for use </returns>
        public T GetObject()
        {
            ObjectContainer<T> objectContainer = null;
            for (var i = 0; i < objectContainers.Count; i++)
            {
                objectContainerIndex++;
                if (objectContainerIndex > objectContainers.Count - 1) objectContainerIndex = 0;
                if (objectContainers[objectContainerIndex].Used) continue;

                // Object container with unused objects
                objectContainer = objectContainers[objectContainerIndex];
                break;
            }

            // If all object is used, create new object container
            if (objectContainer == null) objectContainer = CreateObjectContainer();

            // Set object in container used and add pool
            objectContainer.Use();
            pool.Add(objectContainer.Object, objectContainer);

            return objectContainer.Object;
        }

        /// <summary>
        /// Release object in object container
        /// </summary>
        /// <param name="key"> Object to release </param>
        public void Release(T key)
        {
            if (pool.ContainsKey(key))
            {
                var objectContainer = pool[key];
                objectContainer.Release();
                return;
            }

            LogManager.OnDebugLog(Label.LabelType.Error, typeof(Pool<T>),
                $"This object pool does not contain the object provided: {key}");
        }

        /// <summary>
        /// Count of object container list
        /// </summary>
        public int ObjectContainerCount => objectContainers.Count;

        /// <summary>
        /// Count of used object container in pool
        /// </summary>
        public int UsedObjectContainerCount => pool.Count;
    }
}
