using UnityEngine;

<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Extension/LabelAttribute.cs
namespace Core.Utility.Extension
========
namespace Backend.Utility.Attribute
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Attribute/LabelAttribute.cs
{
    public class LabelAttribute : PropertyAttribute
    {
        public string Text { get; private set; }

        public LabelAttribute(string text) => Text = text;
    }
}
