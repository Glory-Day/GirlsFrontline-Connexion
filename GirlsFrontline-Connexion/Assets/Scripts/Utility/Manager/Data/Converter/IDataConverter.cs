namespace Utility.Manager.Data.Converter
{
    public interface IDataConverter<out T>
    {
        /// <summary>
        /// Convert json format data to object type format
        /// </summary>
        T ToObject();
    }
}
