namespace Utility.Manager.Object
{
    public class Container<T>
    {
        public Container(T instance)
        {
            Instance = instance;
        }
        
        /// <summary>
        /// Set contained object to use
        /// </summary>
        public void Use() => IsUsed = true;

        /// <summary>
        /// Release contained object
        /// </summary>
        public void Release() => IsUsed = false;

        /// <summary>
        /// Contained object
        /// </summary>
        public T Instance { get; }
        
        /// <summary>
        /// Whether to use an object
        /// </summary>
        public bool IsUsed { get; private set; }
    }
}
