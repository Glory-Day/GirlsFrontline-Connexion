using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using GloryDay.Debug;
using Core.Object.Character;
using Core.Object.Item;
using Core.Object.Weapon;

using Console = GloryDay.Debug.Console;

namespace Core.Utility.Management.Resource.Addressable
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
            Console.LogProgress();
            
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
            
            Console.LogSuccess($"<b>{resource.name}</b> is loaded");
        }
        
        /// <summary>
        /// Load player character prefab assets using addressables
        /// </summary>
        private static void LoadPlayerCharacterResources(GameObject resource)
        {
            ResourceManager.GameObjectResource.PlayerCharacter = resource;
            
            Console.LogSuccess($"<b>{resource.name}</b> is loaded");
        }

        /// <summary>
        /// Load item prefab assets using addressables
        /// </summary>
        private static void LoadItemResources(GameObject resource)
        {
            ResourceManager.GameObjectResource.Item.Add(resource);
            
            Console.LogSuccess($"<b>{resource.name}</b> is loaded");
        }
        
        /// <summary>
        /// Load weapon prefab assets using addressables
        /// </summary>
        private static void LoadWeaponResources(GameObject resource)
        {
            ResourceManager.GameObjectResource.Weapon.Add(resource.name, resource.GetComponent<WeaponBase>());
            
            Console.LogSuccess($"<b>{resource.name}</b> is loaded");
        }
        
        /// <summary>
        /// Load bullet prefab assets using addressables
        /// </summary>
        private static void LoadBulletResources(GameObject resource)
        {
            ResourceManager.GameObjectResource.Bullet.Add(resource.name, resource.GetComponent<Bullet>());
            
            Console.LogSuccess($"<b>{resource.name}</b> is loaded");
        }
        
        /// <summary>
        /// Load grenade prefab assets using addressables
        /// </summary>
        private static void LoadGrenadeResources(GameObject resource)
        {
            ResourceManager.GameObjectResource.Grenade.Add(resource.name, resource.GetComponent<Grenade>());
            
            Console.LogSuccess($"<b>{resource.name}</b> is loaded");
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
