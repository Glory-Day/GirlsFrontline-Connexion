using UnityEditor;
using UnityEngine;

namespace Utility.Extension.Editor
{
    [CustomPropertyDrawer(typeof(SerializableStructureAttribute))]
    public class SerializableStructureDrawer : PropertyDrawer
    {
        #region CONSTANT FIELD API

        private const float Space = 10f;

        #endregion
        
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var length = FieldNames.Length;
            var height = EditorGUIUtility.singleLineHeight * (length + 1) + 2f * (length - 1);
            return height + Space;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            position.y += Space;
            position.height = EditorGUIUtility.singleLineHeight;
            EditorGUI.LabelField(position, label, EditorStyles.boldLabel);
            var length = FieldNames.Length;
            for (var i = 0; i < length; i++)
            {
                position.y += EditorGUIUtility.singleLineHeight + 2f;
                var name = FieldNames[i];
                var element = property.FindPropertyRelative(name);
                EditorGUI.PropertyField(position, element);
            }
        }

        private string[] FieldNames => ((SerializableStructureAttribute)attribute).FieldNames;
    }
}