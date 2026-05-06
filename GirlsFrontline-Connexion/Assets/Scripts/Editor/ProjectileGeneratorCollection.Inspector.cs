<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Extension/Editor/ProjectileGeneratorCollectionInspector.cs
﻿using Core.Object.Character;
========
﻿using Backend.Object.Character;
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Editor/ProjectileGeneratorCollection.Inspector.cs
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Extension/Editor/ProjectileGeneratorCollectionInspector.cs
namespace Core.Utility.Extension.Editor
========
namespace Backend.Editor
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Editor/ProjectileGeneratorCollection.Inspector.cs
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
