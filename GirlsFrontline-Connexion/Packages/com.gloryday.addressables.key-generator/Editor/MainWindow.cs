#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace GloryDay.Addressables
{
    public class MainWindow : EditorWindow
    {
        #region CONSTANT FIELD API

        private const string TabPath = "Window/Services/Addressables Key Generator";
        private const string Title = "Addressables Key Generator";

        private const int MinimizeWindowWidth = 400;
        private const int MinimizeWindowHeight = 300;

        private const string Button01Text = "Update";
        private const string Button02Text = "Settings";

        private const float IconSize = 16f;

        #endregion

        private readonly AddressableAssetMetadataReader _reader = new AddressableAssetMetadataReader();

        private VirtualTreeView _table;

        private void OnEnable()
        {
            // Reads the cached metadata on the disk.
            var metadata = AddressableAssetCacheRepository.ReadCacheDataFromDisk();

            // Updates the table using previously cached metadata.
            if (_table is null)
            {
                _table = VirtualTreeView.Build();
            }

            _table.Update(metadata);
        }

        [MenuItem(TabPath)]
        public static void ShowWindow()
        {
            var window = GetWindow<MainWindow>(Title);
            window.minSize = new Vector2(MinimizeWindowWidth, MinimizeWindowHeight);
        }

        public void OnGUI()
        {
            DrawToolbar();

            GUILayout.FlexibleSpace();

            // Get automatically aligned position for our multi-column header component.
            var bound = GUILayoutUtility.GetLastRect();
            bound.width = position.width;
            bound.height = position.height;
            bound = new Rect(0f, 20f, bound.width, 10000f);

            _table.Draw(bound);
        }

        private void OnDisable()
        {
            SettingsPopUpWindow = null;

            _table = null;
        }

        private void DrawToolbar()
        {
            EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);

            var style = new GUIStyle(EditorStyles.toolbarButton)
            {
                alignment = TextAnchor.MiddleCenter,
                fixedHeight = 20f
            };

            var options = new [] { GUILayout.Width(56f),  GUILayout.Height(20f) };
            var bound = GUILayoutUtility.GetRect(56f, 20f, style, options);
            if (GUI.Button(bound, Button01Text, style))
            {
                var metadata = _reader.Read();
                _table.Update(metadata);

                AddressableAssetCacheRepository.WriteCacheDataToDisk(metadata);

                ScriptGenerator.Generate(metadata);
            }

            style = new GUIStyle(EditorStyles.toolbarDropDown)
            {
                alignment = TextAnchor.MiddleCenter,
                fixedHeight = 20f
            };

            options = new [] { GUILayout.Width(72f),  GUILayout.Height(20f) };
            bound = GUILayoutUtility.GetRect(72f, 20f, style, options);
            if (GUI.Button(bound, Button02Text, style))
            {
                bound = GUILayoutUtility.GetLastRect();
                var point = GUIUtility.GUIToScreenPoint(new Vector2(bound.x, bound.y + bound.height));
                var height = EditorGUIUtility.singleLineHeight;

                if (SettingsPopUpWindow is null)
                {
                    var x = point.x + 56f + 0.6f;
                    var y = point.y + height + 0.6f;
                    bound = new Rect(x, y, 280f, 28f + (height * 5f));
                    SettingsPopUpWindow = CreateInstance<SettingsPopUpWindow>();
                    SettingsPopUpWindow.position = bound;
                    SettingsPopUpWindow.ShowPopup();
                }
                else
                {
                    SettingsPopUpWindow.Close();
                    SettingsPopUpWindow = null;
                }
            }

            GUILayout.Label(" ");

            EditorGUILayout.EndHorizontal();
        }

        private SettingsPopUpWindow SettingsPopUpWindow { get; set; }
    }
}

#endif
