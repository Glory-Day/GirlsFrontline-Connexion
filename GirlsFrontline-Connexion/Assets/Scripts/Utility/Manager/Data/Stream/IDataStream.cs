namespace Utility.Manager.Data.Stream
{
    public interface IDataStream<T>
    {
        /// <summary>
        /// Load data in json format file
        /// </summary>
        T Load();

        /// <summary>
        /// Save current data to json format file
        /// </summary>
        /// <param name="data"> Data to save currently </param>
        void Save(T data);
    }
}
