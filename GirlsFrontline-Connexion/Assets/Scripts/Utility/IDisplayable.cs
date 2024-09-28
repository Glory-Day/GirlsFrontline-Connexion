namespace Utility
{
    public interface IDisplayable
    {
        /// <summary>
        /// Start displaying it.
        /// </summary>
        void StartDisplaying();
        
        /// <summary>
        /// Stop displaying it.
        /// </summary>
        void StopDisplaying();
        
        /// <summary>
        /// True if displaying it, otherwise false.
        /// </summary>
        bool IsDisplaying { get; }
    }
}