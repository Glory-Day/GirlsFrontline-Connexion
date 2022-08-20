namespace Manager.Object
{
    /// <summary>
    /// Container to contain object
    /// </summary>
    /// <typeparam name="T"> Type of contained object </typeparam>
    public class ObjectContainer<T>
    {
        public ObjectContainer(T instantiatedObject)
        {
            Used = true;
            Object = instantiatedObject;
        }

        /// <summary>
        /// Whether to use an object
        /// </summary>
        public bool Used { get; private set; }

        /// <summary>
        /// Contained object
        /// </summary>
        public T Object { get; set; }

        /// <summary>
        /// Set contained object to use
        /// </summary>
        public void Use()
        {
            Used = true;
        }

        /// <summary>
        /// Release contained object
        /// </summary>
        public void Release()
        {
            Used = false;
        }
    }
}
