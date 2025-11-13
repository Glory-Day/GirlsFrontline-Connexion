using UnityEngine;

namespace GloryDay.Debug.Extensions
{
    public static class GameObjectExtensions
    {
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var component = gameObject.GetComponent<T>();

            return component == null ? gameObject.AddComponent<T>() : component;
        }
    }
}