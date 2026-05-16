using System.Collections;
using Core.Utility.Management;
using GloryDay.Debug;
using UnityEngine;

namespace Core.Object
{
    [CreateAssetMenu(fileName = "Data Management System Bootstrap Asset", menuName = "Scriptable Object/Bootstrap Asset/Data Management System Bootstrap Asset")]
    public class DataManagementSystemBootstrapAsset : BootstrapAsset
    {
        protected override IEnumerator Booting_Internal()
        {
            Console.LogMessage("Data management system is booting...");

            // Initialize user data stored in the local repository.
            DataManager.LoadUserData();

            Console.LogSuccess("Booting data management system is completed");

            yield return null;
        }
    }
}
