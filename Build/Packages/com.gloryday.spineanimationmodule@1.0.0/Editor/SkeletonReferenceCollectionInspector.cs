#if UNITY_EDITOR

using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace GloryDay.SpineServices.Editor
{
    [CustomEditor(typeof(SkeletonReferenceCollectionObject))]
    public class SkeletonReferenceCollectionInspector : UnityEditor.Editor
    {
        private ReorderableList _animationList;
        private ReorderableList _eventDataList;

        private void OnEnable()
        {
            _animationList = new ReorderableList(
                                 serializedObject, serializedObject.FindProperty("animations"),
                                 true, true, true, true)
                             {
                                 drawElementCallback = DrawSkeletonAnimationReferenceAsset,
                                 drawHeaderCallback =
                                     rect => EditorGUI.LabelField(rect, "Skeleton Animation Reference Assets")
                             };

            _eventDataList = new ReorderableList(
                                 serializedObject, serializedObject.FindProperty("events"),
                                 true, true, true, true)
                             {
                                 drawElementCallback = DrawEventDataReferenceAsset,
                                 drawHeaderCallback =
                                     rect => EditorGUI.LabelField(rect, "Event Data Reference Assets")
                             };
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            _animationList.DoLayoutList();
            _eventDataList.DoLayoutList();
            serializedObject.ApplyModifiedProperties();
        }

        private void DrawSkeletonAnimationReferenceAsset(Rect rect, int index, bool active, bool focused)
        {
            var element = _animationList.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2f;
            EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight),
                                    element, GUIContent.none);
        }

        private void DrawEventDataReferenceAsset(Rect rect, int index, bool active, bool focused)
        {
            var element = _eventDataList.serializedProperty.GetArrayElementAtIndex(index);
            rect.y += 2f;
            EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight),
                                    element, GUIContent.none);
        }
    }
}

#endif