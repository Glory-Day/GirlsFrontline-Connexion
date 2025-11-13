#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace GloryDay.Editor.GUI
{
    [InitializeOnLoad]
    public class ToolbarGUI
    {
	    private static int _iconCount;
	    private static GUIStyle _guiStyle;

	    public static readonly List<Action> LeftToolbarGUI = new List<Action>();
		public static readonly List<Action> RightToolbarGUI = new List<Action>();
		
#if UNITY_2019_1_OR_NEWER

	    private const string IconsFieldName = "k_ToolCount";
			
#else

		private const string IconsFieldName = "s_ShownToolIcons";
			
#endif

		static ToolbarGUI()
		{
			var toolbarType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.Toolbar");
			var iconsFieldInformation = toolbarType.GetField(
				IconsFieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
			
#if UNITY_2019_3_OR_NEWER
			
			_iconCount = iconsFieldInformation != null ? (int)iconsFieldInformation.GetValue(null) : 8;
			
#elif UNITY_2019_1_OR_NEWER

			_iconCount = iconsFieldInformation != null ? (int)iconsFieldInformation.GetValue(null) : 7;
			
#elif UNITY_2018_1_OR_NEWER

			_iconCount = iconsFieldInformation != null ? ((Array)iconsFieldInformation.GetValue(null)).Length : 6;
			
#else

			_iconCount = iconsFieldInformation != null ? ((Array)iconsFieldInformation.GetValue(null)).Length : 5;
			
#endif
	
			GUICallback.OnToolbarGUI = OnGUI;
			GUICallback.OnLeftToolbarGUI = OnLeftGUI;
			GUICallback.OnRightToolbarGUI = OnRightGUI;
		}

#if UNITY_2019_3_OR_NEWER
	    
		public const float Space = 8;
		
#else

		public const float Space = 10;
	    
#endif
	    
		public const float DoubleSpace = 20;
		public const float ButtonWidth = 32;
		public const float DropDownWidth = 80;
		
#if UNITY_2019_1_OR_NEWER
	    
		public const float ControllerWidth = 140;
		
#else

		public const float ControllerWidth = 100;
	    
#endif

	    private static void OnGUI()
		{
			// Create two containers, left and right
			// Screen is whole toolbar
			if (_guiStyle == null)
			{
				_guiStyle = new GUIStyle("CommandLeft");
			}

			var screenWidth = EditorGUIUtility.currentViewWidth;

			// Following calculations match code reflected from Toolbar.OldOnGUI()
			float playButtonsPosition = Mathf.RoundToInt((screenWidth - ControllerWidth) / 2);
			var left = new Rect(0, 0, screenWidth, Screen.height)
			           {
				           xMax = playButtonsPosition
			           };
			var right = new Rect(0, 0, screenWidth, Screen.height)
			            {
				            xMin = playButtonsPosition,
				            xMax = screenWidth
			            };
			
			left.xMin += Space;                     // Spacing left
			left.xMin += ButtonWidth * _iconCount;  // Tool buttons
			
#if UNITY_2019_3_OR_NEWER
			
			left.xMin += Space;                     // Spacing between tools and pivot
			
#else

			left.xMin += largeSpace;                // Spacing between tools and pivot
			
#endif
			
			left.xMin += 64 * 2;                    // Pivot buttons
			right.xMin += _guiStyle.fixedWidth * 3; // Play buttons
			right.xMax -= Space;                    // Spacing right
			right.xMax -= DropDownWidth;            // Layout
			right.xMax -= Space;                    // Spacing between layout and layers
			right.xMax -= DropDownWidth;            // Layers
			
#if UNITY_2019_3_OR_NEWER
			
			right.xMax -= Space;                    // Spacing between layers and account
			
#else

			right.xMax -= largeSpace;               // Spacing between layers and account
			
#endif
			right.xMax -= DropDownWidth;            // Account
			right.xMax -= Space;                    // Spacing between account and cloud
			right.xMax -= ButtonWidth;              // Cloud
			right.xMax -= Space;                    // Spacing between cloud and colab
			right.xMax -= 78;                       // Colab

			// Add spacing around existing controls
			left.xMin += Space;
			left.xMax -= Space;
			right.xMin += Space;
			right.xMax -= Space;

			
#if UNITY_2019_3_OR_NEWER
			
			// Add top and bottom margins
			left.y = 4;
			left.height = 22;
			right.y = 4;
			right.height = 22;
			
#else
			// Add top and bottom margins
			left.y = 5;
			left.height = 24;
			right.y = 5;
			right.height = 24;
			
#endif

			if (left.width > 0)
			{
				GUILayout.BeginArea(left);
				GUILayout.BeginHorizontal();
				
				foreach (var handler in LeftToolbarGUI)
				{
					handler();
				}

				GUILayout.EndHorizontal();
				GUILayout.EndArea();
			}

			if (right.width > 0 == false)
			{
				return;
			}
			
			GUILayout.BeginArea(right);
			GUILayout.BeginHorizontal();
			
			foreach (var handler in RightToolbarGUI)
			{
				handler();
			}

			GUILayout.EndHorizontal();
			GUILayout.EndArea();
		}
		
		public static void OnLeftGUI() 
		{
			GUILayout.BeginHorizontal();
			
			foreach (var handler in LeftToolbarGUI)
			{
				handler();
			}
			
			GUILayout.EndHorizontal();
		}
		
		public static void OnRightGUI() 
		{
			GUILayout.BeginHorizontal();
			
			foreach (var handler in RightToolbarGUI)
			{
				handler();
			}
			
			GUILayout.EndHorizontal();
		}
    }
}

#endif