using UnityEngine;

<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Extension/TransformExtensions.cs
namespace Core.Utility.Extension
========
namespace Backend.Utility.Extension
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Extension/Transform.Extensions.cs
{
    public static class TransformExtensions
    {
        public static Transform GetSibling(this Transform transform, int index)
        {
            return transform.parent.GetChild(index);
        }
    }
}
