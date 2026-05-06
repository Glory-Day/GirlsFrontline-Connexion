using UnityEngine;

namespace Core.Utility.Extension
{
    public static class TransformExtensions
    {
        public static Transform GetSibling(this Transform transform, int index)
        {
            return transform.parent.GetChild(index);
        }
    }
}