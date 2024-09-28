using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using Utility.Data;

namespace Utility.Extension.Editor
{
    [CustomEditor(typeof(ChapterData))]
    [CanEditMultipleObjects]
    public class ChapterDataInspector : UnityEditor.Editor
    {
        #region CONSTANT FIELD API

        private const string PropertyPath01 = "stageData";
        private const string PropertyPath02 = "waveData";
        private const string PropertyPath03 = "spawnData";
        private const string PropertyPath04 = "characterName";
        private const string PropertyPath05 = "spawnedPositionIndex";
        private const string PropertyPath06 = "destinationIndex";
        private const string PropertyPath07 = "delay";
        private const string PropertyPath08 = "bossStageData";

        private const string ListHeaderLabel01 = "Wave Data Collection";
        private const string ListHeaderLabel02 = "Spawn Data Collection";
        private const string ListHeaderLabel03 = "Boss Stage Data Collection";

        #endregion

        private readonly string[] _tabNames = { "Stage 01","Stage 02","Stage 03","Stage 04","Stage 05" };
        private int _selectedTabIndex;
        
        private readonly ReorderableList[] _lists01 = new ReorderableList[5];
        private readonly SerializedProperty[] _properties = new SerializedProperty[5];

        private readonly Dictionary<string, ReorderableList> _lists02 = new Dictionary<string, ReorderableList>();
        private ReorderableList _list03;

        private void OnEnable()
        {
            var property01 = serializedObject.FindProperty(PropertyPath01);
            for (var i = 0; i < 5; i++)
            {
                var j = i;
                
                _properties[i] = property01.GetArrayElementAtIndex(i);
                _lists01[i] = new ReorderableList(_properties[i].serializedObject, _properties[i].FindPropertyRelative(PropertyPath02))
                              {
                                  displayAdd = true,
                                  displayRemove = true,
                                  draggable = true,
                                  drawHeaderCallback = DrawHeader01,
                                  drawElementCallback =
                                      (rect, index, active, focused) =>
                                      {
                                          DrawElement01(_lists01[j], rect, index);
                                      },
                                  elementHeightCallback = index => GetElementHeight01(_lists01[j], index)
                              };
            }

            var property02 = serializedObject.FindProperty(PropertyPath08);
            _list03 = new ReorderableList(property02.serializedObject, property02.FindPropertyRelative(PropertyPath02))
                      {
                          displayAdd = true,
                          displayRemove = true,
                          draggable = true,
                          drawHeaderCallback = DrawHeader03,
                          drawElementCallback =
                              (rect, index, active, focused) =>
                              {
                                  DrawElement01(_list03, rect, index);
                              },
                          elementHeightCallback = index => GetElementHeight01(_list03, index)
                      };
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            GUILayout.Space(10f);
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();
            _selectedTabIndex = GUILayout.Toolbar(_selectedTabIndex, _tabNames, GUILayout.Width(320f));
            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();

            GUILayout.Space(10f);
            _lists01[_selectedTabIndex].DoLayoutList();
            
            GUILayout.Space(10f);
            _list03.DoLayoutList();

            serializedObject.ApplyModifiedProperties();
        }

        private void DrawHeader01(Rect rect)
        {
            EditorGUI.LabelField(rect, ListHeaderLabel01, EditorStyles.boldLabel);
        }

        private void DrawHeader02(Rect rect, int index)
        {
            EditorGUI.LabelField(rect, ListHeaderLabel02 + $" {index}", EditorStyles.boldLabel);
        }
        
        private void DrawHeader03(Rect rect)
        {
            EditorGUI.LabelField(rect, ListHeaderLabel03, EditorStyles.boldLabel);
        }

        private void DrawElement01(ReorderableList list01, Rect rect01, int index01)
        {
            rect01.y += 4f;
            
            var position = new Rect(rect01.x, rect01.y, rect01.width, EditorGUIUtility.singleLineHeight);
            var element01 = list01.serializedProperty.GetArrayElementAtIndex(index01);
            var property01 = element01.FindPropertyRelative(PropertyPath03);
            var property02 = element01.FindPropertyRelative(PropertyPath07);
            var propertyPath = element01.propertyPath;
            
            if (_lists02.ContainsKey(propertyPath) == false)
            {
                var list02 = new ReorderableList(element01.serializedObject, property01)
                             {
                                 displayAdd = true,
                                 displayRemove = true,
                                 draggable = true,
                                 drawHeaderCallback =
                                     rect =>
                                     {
                                         DrawHeader02(rect, index01);
                                     },
                                 drawElementCallback =
                                     (rect02, index02, active02, focused02) =>
                                     {
                                         DrawElement02(_lists02[propertyPath], rect02, index02);
                                     },
                                 elementHeightCallback =
                                     index02 => EditorGUIUtility.singleLineHeight * 3f + 8f
                             };

                _lists02[propertyPath] = list02;
            }
            
            var height = position.height - EditorGUIUtility.singleLineHeight;
            _lists02[propertyPath].DoList(new Rect(position.x, position.y, position.width, height));
            
            position.y += _lists02[propertyPath].GetHeight() + 2f;
            EditorGUI.PropertyField(position, property02);
        }

        private void DrawElement02(ReorderableList list01, Rect rect01, int index01)
        {
            rect01.y += 2f;
            
            var height = EditorGUIUtility.singleLineHeight;
            var position = new Rect(rect01.x, rect01.y, rect01.width, height);
            var element = list01.serializedProperty.GetArrayElementAtIndex(index01);
            var property01 = element.FindPropertyRelative(PropertyPath04);
            var property02 = element.FindPropertyRelative(PropertyPath05);
            var property03 = element.FindPropertyRelative(PropertyPath06);

            EditorGUI.PropertyField(position, property01);
            position.y += height + 2f;
            EditorGUI.PropertyField(position, property02);
            position.y += height + 2f;
            EditorGUI.PropertyField(position, property03);
        }
        
        private float GetElementHeight01(ReorderableList list, int index)
        {
            var height = EditorGUIUtility.singleLineHeight * 3f;
            var element = list.serializedProperty.GetArrayElementAtIndex(index);
            var property = element.FindPropertyRelative(PropertyPath03);
            
            var size = property.arraySize;
            if (size > 0)
            {
                for (var i = 0; i < size; i++)
                {
                    height += EditorGUIUtility.singleLineHeight * 3f + 8f;
                }
            }
            else
            {
                height = EditorGUIUtility.singleLineHeight * 4f + 2f;
            }
            
            return height + EditorGUIUtility.singleLineHeight + 4f;
        }
    }
}