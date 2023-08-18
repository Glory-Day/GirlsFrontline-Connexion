namespace Utility.Manager.Data.Stream
{
    public interface IDataStream<out T>
    {
        /// <summary>
        /// Load data in json format
        /// </summary>
        /// <returns> Data in T type format </returns>
        T Load();
    }
}
