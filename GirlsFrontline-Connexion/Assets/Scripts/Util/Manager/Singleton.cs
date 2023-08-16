using System;
using System.Diagnostics.CodeAnalysis;

namespace Util.Manager
{
    [SuppressMessage("ReSharper", "StaticMemberInGenericType")]
    public class Singleton<T> where T : class
    {
        private static readonly object Locked = new object();
        
        private static T _instance;
        
        // Double-checked locking (Thread Safe)
        protected static T Instance
        {
            get
            {
                lock (Locked)
                {
                    if (_instance == null)
                    {
                        CreateInstance();
                    }
                    
                    return _instance;
                }
            }
        }

        private static void CreateInstance()
        {
            lock (Locked)
            {
                var type = typeof(T);
                var constructorInfos = type.GetConstructors();
                if (constructorInfos.Length > 0)
                {
                    throw new InvalidOperationException(
                        $"{type.Name} has at least one accessible constructor" +
                        " making it impossible to enforce singleton behaviour");
                }

                _instance = (T)Activator.CreateInstance(type, true);
            }
        }
    }
}