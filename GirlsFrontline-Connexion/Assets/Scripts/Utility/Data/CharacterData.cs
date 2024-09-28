using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utility.Data
{
    [CreateAssetMenu(fileName = "Character Data", 
                     menuName = "Scriptable Object/Data/Character Data")]
    public class CharacterData : ScriptableObject
    {
        [SerializeField] private string characterName;
        
        [SerializeField] private float healthPoint;
        [SerializeField] private float damagePoint;
        [SerializeField] private float defensePenetrationPoint;
        [SerializeField] private float defensePoint;
        [SerializeField] private float speedPoint;

        [SerializeField] private float shieldPoint;
        [SerializeField] private int shieldPointCount;
        
        [SerializeField] private List<WeaponData> weaponData;
        [SerializeField] private List<BulletData> bulletData;
        [SerializeField] private List<GrenadeData> grenadeData;

        public string CharacterName => characterName;
        
        public float HealthPoint => healthPoint;
        
        public float DamagePoint => damagePoint;

        public float DefensePenetrationPoint => defensePenetrationPoint;
        
        public float DefensePoint => defensePoint;
        
        public float SpeedPoint => speedPoint;

        public float ShieldPoint => shieldPoint;
        
        public int ShieldPointCount => shieldPointCount;

        public List<WeaponData> WeaponData => weaponData;

        public List<BulletData> BulletData => bulletData;

        public List<GrenadeData> GrenadeData => grenadeData;
    }

    #region SERIALIZABLE CLASS API

    [Serializable]
    public class WeaponData
    {
        [SerializeField] private string name;
        [SerializeField] private float damagePoint;
        [SerializeField] private float defensePenetrationPoint;

        public string Name => name;
        
        public float DamagePoint => damagePoint;
        
        public float DefensePenetrationPoint => defensePenetrationPoint;
    }

    [Serializable]
    public class ProjectileData : WeaponData
    {
        [SerializeField]
        private float speedPoint;

        public float SpeedPoint => speedPoint;
    }

    [Serializable]
    public class BulletData : ProjectileData
    {
        [SerializeField]
        private bool isFlip;

        public bool IsFlip => isFlip;
    }

    [Serializable]
    public class GrenadeData : ProjectileData
    {
        [SerializeField]
        private float height;

        public float Height => height;
    }

    #endregion
}
