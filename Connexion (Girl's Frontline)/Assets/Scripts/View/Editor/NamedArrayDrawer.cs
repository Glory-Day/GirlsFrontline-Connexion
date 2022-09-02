#region NAMESPACE API

using UnityEngine;
using UnityEditor;

#endregion

namespace View.Editor
{
    [CustomPropertyDrawer(typeof(NamedArrayAttribute))]
    public class NamedArrayDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, property.isExpanded);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            try
            {
                var index = int.Parse(property.propertyPath.Split('[', ']')[1]);
                EditorGUI.PropertyField(
                    position, property, new GUIContent($"{Name} {Start + index}"), property.isExpanded);
            }
            catch
            {
                EditorGUI.PropertyField(position, property, label, property.isExpanded);
            }
        }
        
        private string Name => ((NamedArrayAttribute)attribute).Name;

        private int Start => ((NamedArrayAttribute)attribute).Start;
    }
}
