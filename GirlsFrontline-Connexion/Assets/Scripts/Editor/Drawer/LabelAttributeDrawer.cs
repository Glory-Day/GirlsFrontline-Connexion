#if UNITY_EDITOR

using System.Collections.Generic;
using GloryDay.Debug;
using UnityEditor;
using UnityEngine;
using Backend.Utility.Attribute;

<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Extension/Editor/LabelAttributeDrawer.cs
namespace Core.Utility.Extension.Editor
========
namespace Backend.Editor.Drawer
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Editor/Drawer/LabelAttributeDrawer.cs
{
    [CustomPropertyDrawer(typeof(LabelAttribute), true)]
    public class LabelAttributeDrawer : PropertyDrawer
    {
        private LabelAttribute _attribute;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            _attribute = (LabelAttribute)attribute;

            var fieldType = fieldInfo.FieldType;
            var isArrayType = fieldType.IsArray;
            var isGenericType = fieldType.IsGenericType && fieldType.GetGenericTypeDefinition() == typeof(List<>);
            if (isArrayType || isGenericType)
            {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Extension/Editor/LabelAttributeDrawer.cs
                Console.LogError("Can't draw label attribute because it's an array type.");
                
========
                LogManager.LogError("Can't draw label attribute because it's an array type.");

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Editor/Drawer/LabelAttributeDrawer.cs
                EditorGUI.PropertyField(position, property, label, true);

                return;
            }

            EditorGUI.PropertyField(position, property, new GUIContent(_attribute.Text), true);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }
    }
}

#endif
