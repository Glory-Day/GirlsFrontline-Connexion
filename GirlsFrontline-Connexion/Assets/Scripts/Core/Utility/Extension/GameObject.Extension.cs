using UnityEngine;

namespace Core.Utility.Extension
{
    public static class GameObject_Extension
    {
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var component = gameObject.GetComponent<T>();

            return component ?? gameObject.AddComponent<T>();
        }
    }
}
