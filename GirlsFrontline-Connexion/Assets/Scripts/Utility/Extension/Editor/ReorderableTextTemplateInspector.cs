using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using Utility.Data;

namespace Utility.Extension.Editor
{
    [CustomEditor(typeof(ReorderableTextTemplate))]
    public class ReorderableTextTemplateInspector : UnityEditor.Editor
    {
        #region CONSTANT FIELD API

        private const string PropertyPath = "texts";

        private const string ListHeaderLabel = "Text Data Collection";

        #endregion
        
        private ReorderableList _list;
        
        private void OnEnable()
        {
            _list = new ReorderableList(serializedObject, serializedObject.FindProperty(PropertyPath))
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
                                  EditorGUI.PropertyField(position, element, new GUIContent($"Index {index}"));
                              },
                          drawHeaderCallback =
                              rect =>
                              {
                                  EditorGUI.LabelField(rect, ListHeaderLabel, EditorStyles.boldLabel);
                              },
                          elementHeightCallback = index => EditorGUIUtility.singleLineHeight + 4f
                      };
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            GUILayout.Space(10f);
            _list.DoLayoutList();

            serializedObject.ApplyModifiedProperties();
        }
    }
}