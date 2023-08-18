namespace Utility.Manager.Object
{
    public class Container<T>
    {
        public Container(T instantiatedObject)
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
        public T Object { get; }

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
