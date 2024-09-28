using System.Collections.Generic;
using GloryDay.Log;

namespace Utility.Manager.Object
{
    public class Pool<T>
    {
        /// <summary>
        /// List to save object container
        /// </summary>
        private readonly List<Container<T>> _containers;

        /// <summary>
        /// Pool to contain object
        /// </summary>
        private readonly Dictionary<T, Container<T>> _pool;

        private readonly InstantiateCallback<T> _onInstantiate;
        
        /// <summary>
        /// Index of used object container
        /// </summary>
        private int _index;

        /// <summary>
        /// Object pool constructor
        /// </summary>
        /// <param name="capacity"> Initial capacity </param>
        /// <param name="callback"> <b>UnityEngine.Instantiate</b> Method </param>
        public Pool(int capacity, InstantiateCallback<T> callback)
        {
            _containers = new List<Container<T>>(capacity);
            _pool = new Dictionary<T, Container<T>>(capacity);
            _onInstantiate = callback;
            
            // Initialize object containers
            InitializeContainers(capacity);
        }

        /// <summary>
        /// Initialize object containers
        /// </summary>
        /// <param name="capacity"> Initial capacity </param>
        private void InitializeContainers(int capacity)
        {
            for (var i = 0; i < capacity; i++)
            {
                CreateContainer();
            }
        }

        /// <summary>
        /// Create object container
        /// </summary>
        /// <returns> Created object container instance </returns>
        private Container<T> CreateContainer()
        {
            if (_onInstantiate is null)
            {
                return null;
            }
            
            var container = new Container<T>(_onInstantiate.Invoke());
            _containers.Add(container);

            return container;
        }

        /// <summary>
        /// Get object in object container for use and add new object container if all object is used in pool
        /// </summary>
        /// <returns> Object for use </returns>
        public T Object
        {
            get
            {
                Container<T> container = null;

                var count = _containers.Count;
                for (var i = 0; i < count; i++)
                {
                    _index++;
                    if (_index > _containers.Count - 1)
                    {
                        _index = 0;
                    }

                    if (_containers[_index].IsUsed)
                    {
                        continue;
                    }

                    // Object container with unused objects
                    container = _containers[_index];
                    break;
                }

                // If all object is used, create new object container
                if (container is null)
                {
                    container = CreateContainer();
                }

                // Set object in container used and add pool
                container.Use();
                _pool.Add(container.Instance, container);

                return container.Instance;
            }
        }

        /// <summary>
        /// Release object in object container
        /// </summary>
        /// <param name="key"> Object to release </param>
        public void Release(T key)
        {
            if (_pool.TryGetValue(key, out var container))
            {
                container.Release();
                _pool.Remove(key);
                return;
            }

            LogManager.LogError($"This object pool does not contain the object provided: {key}");
        }

        public int ObjectContainerCount => _containers.Count;

        public int UsedObjectContainerCount => _pool.Count;
    }
    
    public delegate T InstantiateCallback<out T>();
}
