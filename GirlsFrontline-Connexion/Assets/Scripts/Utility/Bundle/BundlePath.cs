#if UNITY_EDITOR

using UnityEngine;

namespace Utility.Bundle
{
    public static class BundlePath
    {
        public static readonly string CommandConsoleBundleDirectory = Application.dataPath + "/Library/Bundles";
        public static readonly string CommandConsoleBundlePath = CommandConsoleBundleDirectory + "/command_console";
    }
}

#endif