using System;
using System.Collections.Generic;
using GloryDay.Debug;
using Core.Object.Weapon;
using UnityEngine;
using Core.Utility.Management;
using Core.Utility.Data;

using Console = GloryDay.Debug.Console;

namespace Core.Object.Character
{
    public class ProjectileAttackAction : AttackAction
    {
        #region SERIALIZABLE CLASS API

        [Serializable]
        private class ProjectileGeneratorList
        {
            public Transform[] generators;
        }

        #endregion

        #region SERIALZABLE FIELD API

        [SerializeField]
        private List<ProjectileGeneratorList> list = new List<ProjectileGeneratorList>();

        #endregion

        private List<BulletData> _bulletDataList = new List<BulletData>();
        private List<GrenadeData> _grenadeDataList = new List<GrenadeData>();

        private void OnDestroy()
        {
            Console.LogProgress();

            _bulletDataList.Clear();
            _bulletDataList = null;

            _grenadeDataList.Clear();
            _grenadeDataList = null;
        }

        public void AddData(string data)
        {
            var original = AssetManager.Asset.Object.Character[data];
            var parent = transform.parent;
            ObjectPoolManager.Create(original, parent, 10);
        }

        /// <summary>
        /// Add bullet data for the character.
        /// Create 10 bullet objects in the object pool.
        /// </summary>
        /// <param name="data"> Bullet data held by a character. </param>
        public void AddBulletData(BulletData data)
        {
            var original = AssetManager.Asset.Object.Weapon[data.Name].gameObject;
            ObjectPoolManager.Create(original, transform.parent, 10);

            _bulletDataList.Add(data);
        }

        /// <summary>
        /// Add grenade data for the character.
        /// Create 10 grenade objects in the object pool.
        /// </summary>
        /// <param name="data"> Grenade data held by a character. </param>
        public void AddGrenadeData(GrenadeData data)
        {
            var original = AssetManager.Asset.Object.Weapon[data.Name].gameObject;
            ObjectPoolManager.Create(original, transform.parent, 10);

            _grenadeDataList.Add(data);
        }

        /// <param name="index"> Index number of the projectile generator list. </param>
        /// <param name="iterator"> Index number for iterating the projectile generators. </param>
        /// <returns> Projectile generator corresponding to the index number. </returns>
        public Transform GetProjectileGenerator(int index, int iterator) => list[index].generators[iterator];

        public void Spawn(string data, int generatorIndex, int iterator)
        {
            Console.LogProgress();

            var generator = list[generatorIndex].generators[iterator];

            var original = AssetManager.Asset.Object.Character[data];
            var clone = ObjectPoolManager.Spawn(original, generator.position, generator.rotation);

            clone.gameObject.SetActive(true);
        }

        /// <summary>
        /// Shoot a bullet.
        /// </summary>
        /// <param name="dataIndex"> Index number of bullet data list held by a character. </param>
        /// <param name="generatorIndex"> Index number of the projectile generator list. </param>
        /// <param name="iterator"> Index number for iterating the projectile generators. </param>
        /// <param name="target"></param>
        public Bullet Prepare(int dataIndex, int generatorIndex, int iterator, Vector3? target = null)
        {
            Console.LogProgress();

            var generator = list[generatorIndex].generators[iterator];
            var data = _bulletDataList[dataIndex];
            var damagePoint = data.DamagePoint + DefaultDamagePoint;
            var defensePenetrationPoint = data.DefensePenetrationPoint + DefaultDefensePenetrationPoint;

            var original = AssetManager.Asset.Object.Weapon[data.Name];
            var clone = ObjectPoolManager.Spawn<Bullet>(original.gameObject, generator.position, generator.rotation);
            clone.SetData(damagePoint, defensePenetrationPoint, data.SpeedPoint, data.IsFlip);
            clone.SetCalledCharacterInfo(Tag);
            clone.SetTarget(target);

            return clone;
        }

        /// <summary>
        /// Prepare a grenade that shoot to the destination.
        /// </summary>
        /// <param name="dataIndex"> Index number of grenade data list held by a character. </param>
        /// <param name="destination"> The destination of the projectile. </param>
        /// <param name="generatorIndex"> Index number of the projectile generator list. </param>
        /// <param name="iterator"> Index number for iterating the projectile generators. </param>
        public Grenade Prepare(int dataIndex, Vector3 destination, int generatorIndex, int iterator)
        {
            Console.LogProgress();

            var generator = list[generatorIndex].generators[iterator];

            var data = _grenadeDataList[dataIndex];
            var damagePoint = data.DamagePoint + DefaultDamagePoint;
            var defensePenetrationPoint = data.DefensePenetrationPoint + DefaultDefensePenetrationPoint;

            var original = AssetManager.Asset.Object.Weapon[data.Name];
            var clone = ObjectPoolManager.Spawn<Grenade>(original.gameObject, generator.position, generator.rotation);
            clone.SetData(damagePoint, defensePenetrationPoint, data.SpeedPoint, data.Height);
            clone.SetBezierCurvePoints(destination);
            clone.SetCalledCharacterInfo(Tag);

            return clone;
        }
    }
}
