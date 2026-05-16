using System.Collections;
using Core.Utility.Management;
using GloryDay.Debug;
using UnityEngine;

namespace Core.Object
{
    [CreateAssetMenu(fileName = "Resource Management System Bootstrap Asset", menuName = "Scriptable Object/Bootstrap Asset/Resource Management System Bootstrap Asset")]
    public class ResourceManagementSystemBootstrapAsset : BootstrapAsset
    {
        protected override IEnumerator Booting_Internal()
        {
            Console.LogMessage("Resource management system is booting...");

            // Load all resources used by the application.
            AssetManager.Load();
            while (AssetManager.IsLoadedDone == false)
            {
                yield return null;
            }

            Console.LogSuccess("Booting resource management system is completed");
        }
    }
}
