using Object.Character;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Utility.Extension.Editor
{
    [CustomEditor(typeof(ProjectileAttackAction))]
    public class ProjectileGeneratorCollectionInspector : UnityEditor.Editor
    {
        private ReorderableList _list;

        private void OnEnable()
        {
            _list = new ReorderableList(serializedObject, serializedObject.FindProperty("list"),
                                        true, true, true, true)
                    {
                        elementHeightCallback = SetElementHeight,
                        drawElementCallback = DrawElement,
                        drawHeaderCallback = DrawHeader
                    };
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            _list.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }

        private float SetElementHeight(int index)
        {
            var element = _list.serializedProperty.GetArrayElementAtIndex(index);
            var property = element.FindPropertyRelative("generators");

            return EditorGUI.GetPropertyHeight(property) + EditorGUIUtility.standardVerticalSpacing;
        }

        private void DrawElement(Rect rect, int index, bool active, bool focused)
        {
            var element = _list.serializedProperty.GetArrayElementAtIndex(index);
            var property = element.FindPropertyRelative("generators");

            EditorGUI.indentLevel++;
            EditorGUI.PropertyField(rect, property, true);
            EditorGUI.indentLevel--;
        }
        
        private void DrawHeader(Rect rect)
        {
            EditorGUI.LabelField(rect, "Projectile Generator Collection");
        }
    }
}