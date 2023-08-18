using System;

namespace Utility
{
    public static class Extensions
    {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
        
        /// <summary>
        /// Get the name of <see cref="Manager.Log.LogLabel"/> in all upper case
        /// </summary>
        public static string GetName(this Manager.Log.LogLabel label)
        {
            return Enum.GetName(typeof(Manager.Log.LogLabel), label)?.ToUpper();
        }

#endif
    }
}
