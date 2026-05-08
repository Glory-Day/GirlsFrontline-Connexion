using System.Collections;
using Core.Utility.Management;
using GloryDay.Debug;
using UnityEngine;

namespace Core.Object
{
    [CreateAssetMenu(fileName = "Object Pool Management System Bootstrap Asset", menuName = "Scriptable Object/Bootstrap Asset/Object Pool Management System Bootstrap Asset")]
    public class ObjectPoolManagementSystemBootstrapAsset : BootstrapAsset
    {
        protected override IEnumerator Booting_Internal()
        {
            Console.LogMessage("Object pool management system is booting...");

            ObjectManager.OnSpawn(ResourceManager.UIResource.TransitionScreen).SetActive(true);
            ObjectManager.OnSpawn(ResourceManager.UIResource.OptionScreen).SetActive(true);
            ObjectManager.OnSpawn(ResourceManager.UIResource.PauseScreen).SetActive(true);

            Console.LogSuccess("Booting object pool management system is completed");

            yield return null;
        }
    }
}
