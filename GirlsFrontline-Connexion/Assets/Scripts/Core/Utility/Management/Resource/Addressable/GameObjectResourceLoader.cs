using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/Resource/Addressable/GameObjectResourceLoader.cs
using GloryDay.Debug;
using Core.Object.Character;
using Core.Object.Item;
using Core.Object.Weapon;

using Console = GloryDay.Debug.Console;

namespace Core.Utility.Manager.Resource.Addressable
========
using GloryDay.Debug.Log;
using Backend.Object.Character;
using Backend.Object.Item;
using Backend.Object.Weapon;

namespace Backend.Utility.Management.Resource.Addressable
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/Resource/Addressable/GameObjectResourceLoader.cs
{
    public class GameObjectResourceLoader : IResourceLoader
    {
        private AsyncOperationHandle<IList<GameObject>> _enemyCharacterResourceHandle;
        private AsyncOperationHandle<IList<GameObject>> _playerCharacterResourceHandle;
        private AsyncOperationHandle<IList<GameObject>> _itemResourceHandle;
        private AsyncOperationHandle<IList<GameObject>> _weaponResourceHandle;
        private AsyncOperationHandle<IList<GameObject>> _bulletResourceHandle;
        private AsyncOperationHandle<IList<GameObject>> _grenadeResourceHandle;

        public void Load()
        {
            Console.LogProgress();

            _enemyCharacterResourceHandle = Addressables.LoadAssetsAsync(
                    AddressableLabelGroup.GameObject.EnemyCharacter, (Action<GameObject>)LoadEnemyCharacterResources);
            _playerCharacterResourceHandle = Addressables.LoadAssetsAsync(
                AddressableLabelGroup.GameObject.PlayerCharacter, (Action<GameObject>)LoadPlayerCharacterResources);
            _itemResourceHandle = Addressables.LoadAssetsAsync(
                AddressableLabelGroup.GameObject.Item, (Action<GameObject>)LoadItemResources);
            _weaponResourceHandle = Addressables.LoadAssetsAsync(
                AddressableLabelGroup.GameObject.Weapon, (Action<GameObject>)LoadWeaponResources);
            _bulletResourceHandle = Addressables.LoadAssetsAsync(
                AddressableLabelGroup.GameObject.Bullet, (Action<GameObject>)LoadBulletResources);
            _grenadeResourceHandle = Addressables.LoadAssetsAsync(
                AddressableLabelGroup.GameObject.Grenade, (Action<GameObject>)LoadGrenadeResources);
        }

        public void Unload()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/Resource/Addressable/GameObjectResourceLoader.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/Resource/Addressable/GameObjectResourceLoader.cs
            UnloadEnemyCharacterResources();
            UnloadPlayerCharacterResources();
            UnloadItemResources();
            UnloadWeaponResources();
            UnloadBulletResources();
            UnloadGrenadeResources();
        }

        /// <summary>
        /// Load enemy character prefab assets using addressables
        /// </summary>
        private static void LoadEnemyCharacterResources(GameObject resource)
        {
            ResourceManager.GameObjectResource.EnemyCharacter.Add(resource.name, resource);
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/Resource/Addressable/GameObjectResourceLoader.cs
            
            Console.LogSuccess($"<b>{resource.name}</b> is loaded");
========

            LogManager.LogSuccess($"<b>{resource.name}</b> is loaded");
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/Resource/Addressable/GameObjectResourceLoader.cs
        }

        /// <summary>
        /// Load player character prefab assets using addressables
        /// </summary>
        private static void LoadPlayerCharacterResources(GameObject resource)
        {
            ResourceManager.GameObjectResource.PlayerCharacter = resource;
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/Resource/Addressable/GameObjectResourceLoader.cs
            
            Console.LogSuccess($"<b>{resource.name}</b> is loaded");
========

            LogManager.LogSuccess($"<b>{resource.name}</b> is loaded");
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/Resource/Addressable/GameObjectResourceLoader.cs
        }

        /// <summary>
        /// Load item prefab assets using addressables
        /// </summary>
        private static void LoadItemResources(GameObject resource)
        {
            ResourceManager.GameObjectResource.Item.Add(resource);
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/Resource/Addressable/GameObjectResourceLoader.cs
            
            Console.LogSuccess($"<b>{resource.name}</b> is loaded");
========

            LogManager.LogSuccess($"<b>{resource.name}</b> is loaded");
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/Resource/Addressable/GameObjectResourceLoader.cs
        }

        /// <summary>
        /// Load weapon prefab assets using addressables
        /// </summary>
        private static void LoadWeaponResources(GameObject resource)
        {
            ResourceManager.GameObjectResource.Weapon.Add(resource.name, resource.GetComponent<WeaponBase>());
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/Resource/Addressable/GameObjectResourceLoader.cs
            
            Console.LogSuccess($"<b>{resource.name}</b> is loaded");
========

            LogManager.LogSuccess($"<b>{resource.name}</b> is loaded");
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/Resource/Addressable/GameObjectResourceLoader.cs
        }

        /// <summary>
        /// Load bullet prefab assets using addressables
        /// </summary>
        private static void LoadBulletResources(GameObject resource)
        {
            ResourceManager.GameObjectResource.Bullet.Add(resource.name, resource.GetComponent<Bullet>());
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/Resource/Addressable/GameObjectResourceLoader.cs
            
            Console.LogSuccess($"<b>{resource.name}</b> is loaded");
========

            LogManager.LogSuccess($"<b>{resource.name}</b> is loaded");
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/Resource/Addressable/GameObjectResourceLoader.cs
        }

        /// <summary>
        /// Load grenade prefab assets using addressables
        /// </summary>
        private static void LoadGrenadeResources(GameObject resource)
        {
            ResourceManager.GameObjectResource.Grenade.Add(resource.name, resource.GetComponent<Grenade>());
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/Resource/Addressable/GameObjectResourceLoader.cs
            
            Console.LogSuccess($"<b>{resource.name}</b> is loaded");
========

            LogManager.LogSuccess($"<b>{resource.name}</b> is loaded");
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/Resource/Addressable/GameObjectResourceLoader.cs
        }

        /// <summary>
        /// Unload enemy character prefab assets using addressables
        /// </summary>
        private void UnloadEnemyCharacterResources()
        {
            Console.LogProgress();

            Addressables.Release(_enemyCharacterResourceHandle);

            Console.LogSuccess("<b>Enemy Character Prefabs</b> are unloaded");
        }

        /// <summary>
        /// Unload player character prefab assets using addressables
        /// </summary>
        private void UnloadPlayerCharacterResources()
        {
            Console.LogProgress();

            Addressables.Release(_playerCharacterResourceHandle);

            Console.LogSuccess("<b>Player Character Prefabs</b> are unloaded");
        }

        /// <summary>
        /// Unload item prefab assets using addressables
        /// </summary>
        private void UnloadItemResources()
        {
            Console.LogProgress();

            Addressables.Release(_itemResourceHandle);

            Console.LogSuccess("<b>Item Prefabs</b> are unloaded");
        }

        /// <summary>
        /// Unload weapon prefab assets using addressables
        /// </summary>
        private void UnloadWeaponResources()
        {
            Console.LogProgress();

            Addressables.Release(_weaponResourceHandle);

            Console.LogSuccess("<b>Weapon Prefabs</b> are unloaded");
        }

        /// <summary>
        /// Unload bullet prefab assets using addressables
        /// </summary>
        private void UnloadBulletResources()
        {
            Console.LogProgress();

            Addressables.Release(_bulletResourceHandle);

            Console.LogSuccess("<b>Bullet Prefabs</b> are unloaded");
        }

        /// <summary>
        /// Unload grenade prefab assets using addressables
        /// </summary>
        private void UnloadGrenadeResources()
        {
            Console.LogProgress();

            Addressables.Release(_grenadeResourceHandle);

            Console.LogSuccess("<b>Grenade Prefabs</b> are unloaded");
        }

        public bool IsLoadedDone => IsEnemyCharacterResourceLoadedDone &&
                                    IsPlayerCharacterResourceLoadedDone &&
                                    IsItemResourceLoadedDone &&
                                    IsWeaponResourceLoadedDone &&
                                    IsBulletResourceLoadedDone &&
                                    IsGrenadeResourceLoadedDone;

        private bool IsEnemyCharacterResourceLoadedDone =>
            _enemyCharacterResourceHandle.IsValid() && _enemyCharacterResourceHandle.IsDone;

        private bool IsPlayerCharacterResourceLoadedDone =>
            _playerCharacterResourceHandle.IsValid() && _playerCharacterResourceHandle.IsDone;

        private bool IsItemResourceLoadedDone => _itemResourceHandle.IsValid() && _itemResourceHandle.IsDone;

        private bool IsWeaponResourceLoadedDone => _weaponResourceHandle.IsValid() && _weaponResourceHandle.IsDone;

        private bool IsBulletResourceLoadedDone => _bulletResourceHandle.IsValid() && _bulletResourceHandle.IsDone;

        private bool IsGrenadeResourceLoadedDone => _grenadeResourceHandle.IsValid() && _grenadeResourceHandle.IsDone;
    }
}
