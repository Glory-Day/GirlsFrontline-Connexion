#if UNITY_EDITOR

using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

#if UNITY_2019_1_OR_NEWER

using UnityEngine.UIElements;

#else

using UnityEngine.Experimental.UIElements;

#endif

namespace GloryDay.Editor.GUI
{
    public static class GUICallback
    {
	    private static readonly Type ToolbarType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.Toolbar");
	    private static readonly Type GUIViewType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.GUIView");

#if UNITY_2020_1_OR_NEWER
	    
	    private static readonly Type WindowBackendType = typeof(Editor).Assembly.GetType(
		    "UnityEditor.IWindowBackend");
	    private static readonly PropertyInfo WindowBackend = GUIViewType.GetProperty(
		    "windowBackend", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
	    private static readonly PropertyInfo ViewVisualTree = WindowBackendType.GetProperty(
		    "visualTree", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
	    
#else

	    private static readonly PropertyInfo ViewVisualTree = GUIViewType.GetProperty(
		    "visualTree", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
#endif

	    private static readonly FieldInfo GUIContainer = typeof(IMGUIContainer).GetField(
		    "m_OnGUIHandler", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

	    private static ScriptableObject _currentToolbar;

		/// <summary>
		/// Callback for toolbar OnGUI method.
		/// </summary>
		public static Action OnToolbarGUI;
		public static Action OnLeftToolbarGUI;
		public static Action OnRightToolbarGUI;
		
		static GUICallback()
		{
			EditorApplication.update -= OnUpdate;
			EditorApplication.update += OnUpdate;
		}

		private static void OnUpdate()
		{
			// Relying on the fact that toolbar is ScriptableObject and gets deleted when layout changes
			if (_currentToolbar is null == false)
			{
				return;
			}
			
			// Find toolbars
			var toolbars = Resources.FindObjectsOfTypeAll(ToolbarType);
			
			_currentToolbar = toolbars.Length > 0 ? (ScriptableObject) toolbars[0] : null;
			if (_currentToolbar is null)
			{
				return;
			}
			
#if UNITY_2021_1_OR_NEWER

			var root = _currentToolbar.GetType().GetField("m_Root", BindingFlags.NonPublic | BindingFlags.Instance);
			var rawValue = root.GetValue(_currentToolbar);
			var element = rawValue as VisualElement;
			RegisterCallback("ToolbarZoneLeftAlign", OnToolbarGUILeft);
			RegisterCallback("ToolbarZoneRightAlign", OnToolbarGUIRight);

			void RegisterCallback(string root, Action callback) {
				var zone = element.Q(root);
				var parent = new VisualElement
				             {
					             style = {
						                     flexGrow = 1,
						                     flexDirection = FlexDirection.Row,
					                     }
				             };
						
				var container = new IMGUIContainer();
				container.style.flexGrow = 1;
				container.onGUIHandler += () => { callback?.Invoke(); }; 
				parent.Add(container);
				zone.Add(parent);
			}

#else
#if UNITY_2020_1_OR_NEWER

			var windowBackend = WindowBackend.GetValue(_currentToolbar);

			// Get view visual tree
			var visualTree = (VisualElement) ViewVisualTree.GetValue(windowBackend, null);
					
#else
					
			// Get view visual tree
			var visualTree = (VisualElement)ViewVisualTree.GetValue(_currentToolbar, null);
					
#endif

			// Get first child which 'happens' to be toolbar IMGUIContainer
			var container = (IMGUIContainer)visualTree[0];

			// Attach handler
			var handler = (Action)GUIContainer.GetValue(container);
			handler -= OnGUI;
			handler += OnGUI;
			GUIContainer.SetValue(container, handler);
					
#endif
		}

		private static void OnGUI()
		{
			var handler = OnToolbarGUI;
			handler?.Invoke();
		}
    }
}

#endif

