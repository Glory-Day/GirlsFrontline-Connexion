#if UNITY_EDITOR

using GloryDay.Editor.GUI;
using UnityEngine;
using UnityEditor;

namespace GloryDay.Editor
{
    public class TimeScaleSlider : MonoBehaviour
    {
        [InitializeOnLoadMethod]
        private static void Initialize()
        {
            ToolbarGUI.RightToolbarGUI.Add(OnToolbarGUI);
        }

        private static void OnToolbarGUI()
        {
            EditorGUILayout.LabelField(" ", GUILayout.Width(10f));
            EditorGUILayout.LabelField("Time Scale", GUILayout.MaxWidth(80f));
            Time.timeScale = EditorGUILayout.Slider(Time.timeScale, 0f, 1f, GUILayout.MaxWidth(120f));
        }
    }
}

#endif // UNITY_EDITOR