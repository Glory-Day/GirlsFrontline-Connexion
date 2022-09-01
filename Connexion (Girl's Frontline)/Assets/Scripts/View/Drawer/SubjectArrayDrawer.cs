#region NAMESPACE API

using UnityEngine;
using UnityEditor;

#endregion

namespace View.Drawer
{
    [CustomPropertyDrawer(typeof(SubjectArrayAttribute))]
    public class SubjectArrayDrawer : PropertyDrawer
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
                    position, property, new GUIContent($"{Subject} {Start + index}"), property.isExpanded);
            }
            catch
            {
                EditorGUI.PropertyField(position, property, label, property.isExpanded);
            }
        }
        
        private string Subject => ((SubjectArrayAttribute)attribute).Subject;

        private int Start => ((SubjectArrayAttribute)attribute).Start;
    }
}
