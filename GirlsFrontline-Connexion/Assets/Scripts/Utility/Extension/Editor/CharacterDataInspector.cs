using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using Utility.Data;

namespace Utility.Extension.Editor
{
    [CustomEditor(typeof(CharacterData))]
    [CanEditMultipleObjects]
    public class CharacterDataInspector : UnityEditor.Editor
    {
        #region CONSTANT FIELD API

        private const string HeaderLabel01 = "Default Information";
        private const string HeaderLabel02 = "Default Stat Point Information";
        private const string HeaderLabel03 = "Shield Point Information";
        
        private const string PropertyPath01 = "characterName";
        private const string PropertyPath02 = "healthPoint";
        private const string PropertyPath03 = "damagePoint";
        private const string PropertyPath04 = "defensePenetrationPoint";
        private const string PropertyPath05 = "defensePoint";
        private const string PropertyPath06 = "speedPoint";
        
        private const string PropertyPath07 = "shieldPoint";
        private const string PropertyPath08 = "shieldPointCount";
        
        private const string PropertyPath09 = "weaponData";
        private const string PropertyPath10 = "bulletData";
        private const string PropertyPath11 = "grenadeData";

        private const string PropertyPath12 = "name";
        private const string PropertyPath13 = "isFlip";
        private const string PropertyPath14 = "height";

        private const string ListHeaderLabel01 = "Weapon Data Collection";
        private const string ListHeaderLabel02 = "Bullet Data Collection";
        private const string ListHeaderLabel03 = "Grenade Data Collection";
        
        #endregion

        private SerializedProperty _property01;
        private SerializedProperty _property02;
        private SerializedProperty _property03;
        private SerializedProperty _property04;
        private SerializedProperty _property05;
        private SerializedProperty _property06;
        private SerializedProperty _property07;
        private SerializedProperty _property08;
        
        private ReorderableList _list01;
        private ReorderableList _list02;
        private ReorderableList _list03;

        private readonly GUIContent _content01 = new GUIContent("Name");
        private readonly GUIContent _content02 = new GUIContent("Count");
        private readonly GUIContent _content03 = new GUIContent("Right Direction");
        private readonly GUIContent _content04 = new GUIContent("Bezier Curve Height");
        
        private void OnEnable()
        {
            _property01 = serializedObject.FindProperty(PropertyPath01);
            _property02 = serializedObject.FindProperty(PropertyPath02);
            _property03 = serializedObject.FindProperty(PropertyPath03);
            _property04 = serializedObject.FindProperty(PropertyPath04);
            _property05 = serializedObject.FindProperty(PropertyPath05);
            _property06 = serializedObject.FindProperty(PropertyPath06);
            _property07 = serializedObject.FindProperty(PropertyPath07);
            _property08 = serializedObject.FindProperty(PropertyPath08);
            
            _list01 = new ReorderableList(serializedObject, serializedObject.FindProperty(PropertyPath09))
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
                                  var element = _list01.serializedProperty.GetArrayElementAtIndex(index);
                                  var property01 = element.FindPropertyRelative(PropertyPath12);
                                  var property02 = element.FindPropertyRelative(PropertyPath03);
                                  var property03 = element.FindPropertyRelative(PropertyPath04);
                                  
                                  EditorGUI.PropertyField(position, property01, _content01);
                                  position.y += height + 2f;
                                  EditorGUI.Slider(position, property02, 0f, 100f);
                                  position.y += height + 2f;
                                  EditorGUI.Slider(position, property03, 0f, 100f);
                              },
                          drawHeaderCallback =
                              rect =>
                              {
                                  EditorGUI.LabelField(rect, ListHeaderLabel01, EditorStyles.boldLabel);
                              },
                          elementHeightCallback =
                              index => EditorGUIUtility.singleLineHeight * 3f + 8f 
                      };
            
            _list02 = new ReorderableList(serializedObject, serializedObject.FindProperty(PropertyPath10))
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
                                  var element = _list02.serializedProperty.GetArrayElementAtIndex(index);
                                  var property01 = element.FindPropertyRelative(PropertyPath12);
                                  var property02 = element.FindPropertyRelative(PropertyPath03);
                                  var property03 = element.FindPropertyRelative(PropertyPath04);
                                  var property04 = element.FindPropertyRelative(PropertyPath06);
                                  var property05 = element.FindPropertyRelative(PropertyPath13);
                                  
                                  EditorGUI.PropertyField(position, property01, _content01);
                                  position.y += height + 2f;
                                  EditorGUI.Slider(position, property02, 0f, 100f);
                                  position.y += height + 2f;
                                  EditorGUI.Slider(position, property03, 0f, 100f);
                                  position.y += height + 2f;
                                  EditorGUI.Slider(position, property04, 0f, 100f);
                                  position.y += height + 2f;
                                  EditorGUI.PropertyField(position, property05, _content03);
                              },
                          drawHeaderCallback =
                              rect =>
                              {
                                  EditorGUI.LabelField(rect, ListHeaderLabel02, EditorStyles.boldLabel);
                              },
                          elementHeightCallback =
                              index => EditorGUIUtility.singleLineHeight * 5f + 12f
                      };
            
            _list03 = new ReorderableList(serializedObject, serializedObject.FindProperty(PropertyPath11))
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
                                  var element = _list03.serializedProperty.GetArrayElementAtIndex(index);
                                  var property01 = element.FindPropertyRelative(PropertyPath12);
                                  var property02 = element.FindPropertyRelative(PropertyPath03);
                                  var property03 = element.FindPropertyRelative(PropertyPath04);
                                  var property04 = element.FindPropertyRelative(PropertyPath06);
                                  var property05 = element.FindPropertyRelative(PropertyPath14);
                                  
                                  EditorGUI.PropertyField(position, property01, _content01);
                                  position.y += height + 2f;
                                  EditorGUI.Slider(position, property02, 0f, 100f);
                                  position.y += height + 2f;
                                  EditorGUI.Slider(position, property03, 0f, 100f);
                                  position.y += height + 2f;
                                  EditorGUI.Slider(position, property04, 0f, 100f);
                                  position.y += height + 2f;
                                  EditorGUI.Slider(position, property05, 0f, 10f, _content04);
                              },
                          drawHeaderCallback =
                              rect =>
                              {
                                  EditorGUI.LabelField(rect, ListHeaderLabel03, EditorStyles.boldLabel);
                              },
                          elementHeightCallback =
                              index => EditorGUIUtility.singleLineHeight * 5f + 12f
                      };
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            GUILayout.Space(10f);
            EditorGUILayout.LabelField(HeaderLabel01, EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(_property01, _content01);
            
            GUILayout.Space(10f);
            EditorGUILayout.LabelField(HeaderLabel02, EditorStyles.boldLabel);
            EditorGUILayout.Slider(_property02, 0f, 10000f);
            EditorGUILayout.Slider(_property03, 0f, 10000f);
            EditorGUILayout.Slider(_property04, 0f, 1f);
            EditorGUILayout.Slider(_property05, 0f, 10000f);
            EditorGUILayout.Slider(_property06, 0f, 10000f);
            
            GUILayout.Space(10f);
            EditorGUILayout.LabelField(HeaderLabel03, EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(_property07);
            EditorGUILayout.IntSlider(_property08, 0, 10, _content02);
            
            GUILayout.Space(10f);
            _list01.DoLayoutList();
            
            GUILayout.Space(10f);
            _list02.DoLayoutList();
            
            GUILayout.Space(10f);
            _list03.DoLayoutList();
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}