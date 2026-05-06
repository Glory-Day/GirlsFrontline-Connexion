#if UNITY_EDITOR

using GloryDay.Json.Serialization;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace GloryDay.Addressables
{
    public class SettingsPopUpWindow : EditorWindow
    {
        #region CONSTANT FIELD API

        private const string SubjectLabel = "C# Script";
        private const string PathLabel = "Path";
        private const string NamespaceLabel = "Namespace";
        private const string ClassLabel = "Class";

        private const string ExplorerWindowTitle = "Select Folder Path";

        private const string UserDataFilePath = "Addressables";
        private const string UserDataFileName = "settings.json";

        private const float Border = 1f;
        private const float Padding = 10f;

        #endregion

        private UserData _cache;

        private void OnGUI()
        {
            DrawBorderLine();

            // Initialize button GUI style.
            var style = new GUIStyle(GUI.skin.button)
            {
                alignment = TextAnchor.MiddleCenter
            };

            var height = EditorGUIUtility.singleLineHeight;
            var bounds = new []
            {
                new Rect(90f, 10f + (height * 1f) + (2f * 1f), 180f - height - 2f, height),
                new Rect(90f, 10f + (height * 2f) + (2f * 2f), 180f, height),
                new Rect(90f, 10f + (height * 3f) + (2f * 3f), 180f, height)
            };

            // Draw a text field for input of user settings.
            _cache.Path = GUI.TextField(bounds[0], _cache.Path);
            _cache.Namespace = GUI.TextField(bounds[1], _cache.Namespace);
            _cache.ClassName = GUI.TextField(bounds[2], _cache.ClassName);

            var bound = new Rect(270f - height, 10f + (height * 1f) + (2f * 1f), height, height);
            if (GUI.Button(bound, "..."))
            {
                var directory = Application.dataPath;
                var path = EditorUtility.OpenFolderPanel(ExplorerWindowTitle, directory, string.Empty);
                if (string.IsNullOrEmpty(path) == false && path.StartsWith(directory))
                {
                    path = path.Substring(directory.Length);
                    path = path.TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
                    path = path.Replace("\\", "/");

                    _cache.Path = path;
                }
            }

            bound = new Rect(230f, 10f + (height * 4f) + (2f * 4f), 40f, height);
            if (GUI.Button(bound, "Save", style))
            {
                WriteUserDataToDisk(_cache);

                Close();
            }

            // Initialize label GUI style.
            style = new GUIStyle(GUI.skin.label)
            {
                fontStyle = FontStyle.Bold,
                fontSize = EditorStyles.label.fontSize,
                normal = { textColor = EditorStyles.label.normal.textColor }
            };

            // Draw labels.
            GUI.Label(new Rect(10f, 10f + (height * 0f) + (2f * 0f), 80f, height), SubjectLabel, style);
            GUI.Label(new Rect(10f, 10f + (height * 1f) + (2f * 1f), 80f, height), PathLabel);
            GUI.Label(new Rect(10f, 10f + (height * 2f) + (2f * 2f), 80f, height), NamespaceLabel);
            GUI.Label(new Rect(10f, 10f + (height * 3f) + (2f * 3f), 80f, height), ClassLabel);
        }

        private void OnFocus()
        {
            _cache = ReadUserDataFromDisk();
        }

        private void OnLostFocus()
        {
            Close();
        }

        private void DrawBorderLine()
        {
            var width = position.width;
            var height = position.height;
            var area = new Rect(0f, 0f, width, height);

            var background = new Color(0f, 0f, 0f, 0.0f);
            var border = EditorStyles.centeredGreyMiniLabel.normal.textColor;

            EditorGUI.DrawRect(area, background);

            EditorGUI.DrawRect(new Rect(0f, 0f, width, Border), border);
            EditorGUI.DrawRect(new Rect(0f, height - Border, width, Border), border);
            EditorGUI.DrawRect(new Rect(0f, 0f, Border, height), border);
            EditorGUI.DrawRect(new Rect(width - Border, 0f, Border, height), border);
        }

        public static UserData ReadUserDataFromDisk()
        {
            var path = Path.Combine(Application.persistentDataPath, UserDataFilePath);
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }

            path = Path.Combine(path, UserDataFileName);
            if (File.Exists(path) == false)
            {
                JsonSerializer.Serialize(path, new UserData());
            }

            return JsonSerializer.Deserialize<UserData>(path);
        }

        private static void WriteUserDataToDisk(UserData data)
        {
            var path = Path.Combine(Application.persistentDataPath, UserDataFilePath);
            path = Path.Combine(path, UserDataFileName);

            JsonSerializer.Serialize(path, data);
        }
    }
}

#endif
