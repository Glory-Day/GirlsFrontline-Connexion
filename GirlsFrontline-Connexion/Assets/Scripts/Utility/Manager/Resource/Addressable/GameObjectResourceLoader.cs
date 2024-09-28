using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using GloryDay.Log;
using Object.Character;
using Object.Item;
using Object.Weapon;

namespace Utility.Manager.Resource.Addressable
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
            LogManager.LogProgress();

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
            LogManager.LogProgress();
            
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
            
            LogManager.LogSuccess($"<b>{resource.name}</b> is loaded");
        }
        
        /// <summary>
        /// Load player character prefab assets using addressables
        /// </summary>
        private static void LoadPlayerCharacterResources(GameObject resource)
        {
            ResourceManager.GameObjectResource.PlayerCharacter = resource;
            
            LogManager.LogSuccess($"<b>{resource.name}</b> is loaded");
        }

        /// <summary>
        /// Load item prefab assets using addressables
        /// </summary>
        private static void LoadItemResources(GameObject resource)
        {
            ResourceManager.GameObjectResource.Item.Add(resource);
            
            LogManager.LogSuccess($"<b>{resource.name}</b> is loaded");
        }
        
        /// <summary>
        /// Load weapon prefab assets using addressables
        /// </summary>
        private static void LoadWeaponResources(GameObject resource)
        {
            ResourceManager.GameObjectResource.Weapon.Add(resource.name, resource.GetComponent<WeaponBase>());
            
            LogManager.LogSuccess($"<b>{resource.name}</b> is loaded");
        }
        
        /// <summary>
        /// Load bullet prefab assets using addressables
        /// </summary>
        private static void LoadBulletResources(GameObject resource)
        {
            ResourceManager.GameObjectResource.Bullet.Add(resource.name, resource.GetComponent<Bullet>());
            
            LogManager.LogSuccess($"<b>{resource.name}</b> is loaded");
        }
        
        /// <summary>
        /// Load grenade prefab assets using addressables
        /// </summary>
        private static void LoadGrenadeResources(GameObject resource)
        {
            ResourceManager.GameObjectResource.Grenade.Add(resource.name, resource.GetComponent<Grenade>());
            
            LogManager.LogSuccess($"<b>{resource.name}</b> is loaded");
        }
        
        /// <summary>
        /// Unload enemy character prefab assets using addressables
        /// </summary>
        private void UnloadEnemyCharacterResources()
        {
            LogManager.LogProgress();

            Addressables.Release(_enemyCharacterResourceHandle);

            LogManager.LogSuccess("<b>Enemy Character Prefabs</b> are unloaded");
        }
        
        /// <summary>
        /// Unload player character prefab assets using addressables
        /// </summary>
        private void UnloadPlayerCharacterResources()
        {
            LogManager.LogProgress();

            Addressables.Release(_playerCharacterResourceHandle);

            LogManager.LogSuccess("<b>Player Character Prefabs</b> are unloaded");
        }
        
        /// <summary>
        /// Unload item prefab assets using addressables
        /// </summary>
        private void UnloadItemResources()
        {
            LogManager.LogProgress();

            Addressables.Release(_itemResourceHandle);

            LogManager.LogSuccess("<b>Item Prefabs</b> are unloaded");
        }
        
        /// <summary>
        /// Unload weapon prefab assets using addressables
        /// </summary>
        private void UnloadWeaponResources()
        {
            LogManager.LogProgress();

            Addressables.Release(_weaponResourceHandle);

            LogManager.LogSuccess("<b>Weapon Prefabs</b> are unloaded");
        }
        
        /// <summary>
        /// Unload bullet prefab assets using addressables
        /// </summary>
        private void UnloadBulletResources()
        {
            LogManager.LogProgress();

            Addressables.Release(_bulletResourceHandle);

            LogManager.LogSuccess("<b>Bullet Prefabs</b> are unloaded");
        }
        
        /// <summary>
        /// Unload grenade prefab assets using addressables
        /// </summary>
        private void UnloadGrenadeResources()
        {
            LogManager.LogProgress();

            Addressables.Release(_grenadeResourceHandle);

            LogManager.LogSuccess("<b>Grenade Prefabs</b> are unloaded");
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
