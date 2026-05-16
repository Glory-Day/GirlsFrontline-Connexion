using System.Collections;
using Core.Utility.Management;
using Core.Utility.Management.Resource;
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

            ObjectPoolManager.CreateObjectPool();

            ObjectPoolManager.Spawn(AssetManager.Asset.UI[AddressableAssetKeys.Assets_Prefabs_UI_Transition_Screen_Prefab]).SetActive(true);
            ObjectPoolManager.Spawn(AssetManager.Asset.UI[AddressableAssetKeys.Assets_Prefabs_UI_Option_Screen_Prefab]).SetActive(true);
            ObjectPoolManager.Spawn(AssetManager.Asset.UI[AddressableAssetKeys.Assets_Prefabs_UI_Pause_Screen_Prefab]).SetActive(true);

            Console.LogSuccess("Booting object pool management system is completed");

            yield return null;
        }
    }
}
