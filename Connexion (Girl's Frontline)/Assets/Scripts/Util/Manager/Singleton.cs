#region NAMESPACE API

using System.Diagnostics.CodeAnalysis;

#endregion

namespace Util.Manager
{
    [SuppressMessage("ReSharper", "StaticMemberInGenericType")]
    public class Singleton<T> where T : class, new()
    {
        private static readonly object Locked = new object();
        private static          T      _instance;
        
        // Double-checked locking (Thread Safe)
        public static T Instance
        {
            get
            {
                lock (Locked)
                {
                    return _instance ?? (_instance = new T());
                }
            }
        }
    }
}
