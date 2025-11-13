#if UNITY_EDITOR

using UnityEngine;

namespace GloryDay.Editor
{
    public class BuildPreprocessor : UnityEditor.Build.IPreprocessBuildWithReport
    {
        public int callbackOrder => 0;

        public void OnPreprocessBuild(UnityEditor.Build.Reporting.BuildReport report)
        {
            Time.timeScale = 1f;
        }
    }
}

#endif