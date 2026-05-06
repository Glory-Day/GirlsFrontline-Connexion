using UnityEngine;

<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Extension/NamedArrayAttribute.cs
namespace Core.Utility.Extension
========
namespace Backend.Utility.Attribute
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Attribute/NamedArrayAttribute.cs
{
    public class NamedArrayAttribute : PropertyAttribute
    {
        public NamedArrayAttribute(string name)
        {
            Name = name;
            Start = 0;
        }

        public NamedArrayAttribute(string name, int start)
        {
            Name = name;
            Start = start;
        }

        #region PROPERTIES API

        public string Name { get; }

        public int Start { get; }

        #endregion
    }
}
