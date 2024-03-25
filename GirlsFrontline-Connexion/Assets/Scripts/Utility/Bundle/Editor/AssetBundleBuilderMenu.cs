#if UNITY_EDITOR

using System.IO;
using UnityEditor;

namespace Utility.Bundle.Editor
{
    public static class AssetBundleBuilderMenu
    {
        [MenuItem("Build/Build Library Asset Bundles/Build Command Console Asset")]
        public static void BuildCommandConsoleBundles()
        {
            if (Directory.Exists(BundlePath.CommandConsoleBundleDirectory) == false)
            {
                Directory.CreateDirectory(BundlePath.CommandConsoleBundleDirectory);
            }

            BuildPipeline.BuildAssetBundles(BundlePath.CommandConsoleBundleDirectory, 
                                            BuildAssetBundleOptions.None,
                                            EditorUserBuildSettings.activeBuildTarget);
        }
    }
}

#endif