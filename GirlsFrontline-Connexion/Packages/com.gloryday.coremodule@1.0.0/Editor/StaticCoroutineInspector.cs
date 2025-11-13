#if UNITY_EDITOR

using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace GloryDay.Threading.Editor
{
    [CustomEditor(typeof(StaticCoroutine))]
    public class StaticCoroutineInspector : UnityEditor.Editor
    {
        #region CONSTANT FIELD API

        private const string ListHeaderLabel = "Coroutine Record List";
        
        private const string PropertyName = "records";

        #endregion
        
        private ReorderableList _list;

        private void OnEnable()
        {
            var element = serializedObject.FindProperty(PropertyName);
            _list = new ReorderableList(serializedObject, element)
                    {
                        draggable = false,
                        displayAdd = false,
                        displayRemove = false,
                        drawHeaderCallback = DrawHeader
                    };
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            _list.DoLayoutList();
            
            serializedObject.ApplyModifiedProperties();
        }

        private void DrawHeader(Rect rect)
        {
            EditorGUI.LabelField(rect, ListHeaderLabel, EditorStyles.boldLabel);
        }
    }
}

#endif