using UnityEngine;

namespace Backend.Utility.Extension
{
    public static class TransformExtensions
    {
        public static Transform GetSibling(this Transform transform, int index)
        {
            return transform.parent.GetChild(index);
        }
    }
}
