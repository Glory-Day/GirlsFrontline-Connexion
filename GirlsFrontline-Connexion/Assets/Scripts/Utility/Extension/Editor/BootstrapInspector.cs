using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Utility.Extension.Editor
{
    [CustomEditor(typeof(Bootstrap))]
    [CanEditMultipleObjects]
    public class BootstrapInspector : UnityEditor.Editor
    {
        #region CONSTANT FIELD API

        private const string ListHeaderLabel = "Boot Progress Collection";
        private const string PropertyPath01 = "progresses";
        private const string PropertyPath02 = "m_PersistentCalls.m_Calls";

        #endregion

        private readonly GUIContent _content = new GUIContent("Process");
        
        private ReorderableList _list;

        private void OnEnable()
        {
            _list = new ReorderableList(serializedObject, serializedObject.FindProperty(PropertyPath01))
                    {
                        draggable = true,
                        displayAdd = true,
                        displayRemove = true,
                        drawElementCallback =
                            (rect, index, active, focused) =>
                            {
                                rect.y += 2f;

                                var height = EditorGUIUtility.singleLineHeight;
                                var position = new Rect(rect.x, rect.y, rect.width, height);
                                var element = _list.serializedProperty.GetArrayElementAtIndex(index);
                                
                                EditorGUI.PropertyField(position, element, _content);
                            },
                        drawHeaderCallback =
                            rect => { EditorGUI.LabelField(rect, ListHeaderLabel, EditorStyles.boldLabel); },
                        elementHeightCallback =
                            index =>
                            {
                                var element = _list.serializedProperty.GetArrayElementAtIndex(index);
                                var size = element.FindPropertyRelative(PropertyPath02).arraySize;

                                var height = 0f;
                                if (size > 0)
                                {
                                    height = EditorGUIUtility.singleLineHeight * 5 + 8;
                                    for (var i = 0; i < size - 1; i++)
                                    {
                                        height += EditorGUIUtility.singleLineHeight * 2 + 13;
                                    }
                                }
                                else
                                {
                                    height = EditorGUIUtility.singleLineHeight * 5 + 6;
                                }
                                
                                return height;
                            }
                    };
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            _list.DoLayoutList();

            serializedObject.ApplyModifiedProperties();
        }
    }
}