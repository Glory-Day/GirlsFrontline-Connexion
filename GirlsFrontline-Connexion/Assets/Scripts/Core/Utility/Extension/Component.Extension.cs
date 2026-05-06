using UnityEngine;

namespace Core.Utility.Extension
{
    public static class Component_Extension
    {
        public static T GetOrAddComponent<T>(this Component component) where T : Component
        {
            return component.gameObject.GetOrAddComponent<T>();
        }
    }
}
