using System;
using System.Threading;

namespace GloryDay.Utility
{
    public class Singleton<T> where T : class
    {
        private static readonly Lazy<T> InternalInstance = new Lazy<T>(CreateInstance, LazyThreadSafetyMode.ExecutionAndPublication);

        protected static T Instance => InternalInstance.Value;

        private static T CreateInstance()
        {
            var type = typeof(T);
            var constructorInfos = type.GetConstructors();
            if (constructorInfos.Length > 0)
            {
                throw new InvalidOperationException($"{type.Name} has at least one accessible constructor making it impossible to enforce singleton behaviour.");
            }

            return (T)Activator.CreateInstance(type, true);
        }
    }
}
