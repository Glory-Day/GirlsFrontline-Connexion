#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;

namespace GloryDay.Services
{
    public class MainWindow : EditorWindow
    {
        #region CONSTANT FIELD API

        private const string TabPath = "Window/Service/Static Coroutine Log Viewer";
        private const string Title = "Static Coroutine Log Viewer";

        private const int MinimizeWindowWidth = 400;
        private const int MinimizeWindowHeight = 300;

        #endregion

        [MenuItem(TabPath)]
        public static void ShowWindow()
        {
            var window = GetWindow<MainWindow>(Title);
            window.minSize = new Vector2(MinimizeWindowWidth, MinimizeWindowHeight);
        }


    }
}

#endif
