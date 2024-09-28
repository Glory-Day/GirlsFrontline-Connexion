using Object.Character;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Utility.Extension.Editor
{
    [CustomEditor(typeof(SkillAction))]
    [CanEditMultipleObjects]
    public class SkillActionInspector : UnityEditor.Editor
    {
        #region CONSTANT FIELD API

        private const string PropertyPath01 = "timers";
        private const string PropertyPath02 = "coolDown";
        private const string PropertyPath03 = "duration";

        private const string HeaderLabel = "Skill Time Data Collection";
        
        #endregion
        
        private ReorderableList _list;
        
        private void OnEnable()
        {
            _list = new ReorderableList(serializedObject, serializedObject.FindProperty(PropertyPath01),
                                        true, true, true, true)
                    {
                        drawElementCallback = DrawElement,
                        drawHeaderCallback = DrawHeader,
                        elementHeightCallback = SetElementHeight
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
            return EditorGUIUtility.singleLineHeight * 2 + 6f;
        }

        private void DrawElement(Rect rect, int index, bool active, bool focused)
        {
            var element = _list.serializedProperty.GetArrayElementAtIndex(index);
            var property01 = element.FindPropertyRelative(PropertyPath02);
            var property02 = element.FindPropertyRelative(PropertyPath03);
            
            rect.y += 2f;
            EditorGUI.PropertyField(rect, property01, true);
            rect.y += EditorGUIUtility.singleLineHeight + 2f;
            EditorGUI.PropertyField(rect, property02, true);
        }
        
        private void DrawHeader(Rect rect)
        {
            EditorGUI.LabelField(rect, HeaderLabel);
        }
    }
}