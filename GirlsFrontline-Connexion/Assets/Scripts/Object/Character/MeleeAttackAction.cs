using System.Collections.Generic;
using GloryDay.Debug.Log;
using UnityEngine;
using Utility.Data;
using Utility.Manager;

namespace Object.Character
{
    public class MeleeAttackAction : AttackAction
    {
        #region SERIALIZABLE FIELD API

        [Header("Attack Range")]
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;

        #endregion

        #region CONSTANT FIELD API
        
        private const int TriggerInPlayerCharacterLayerMask = 1 << 21;

        #endregion
        
        private List<WeaponData> _meleeDataList = new List<WeaponData>();
        
        private readonly Collider[] _colliders = new Collider[1];

        private void FixedUpdate()
        {
            var center = transform.position - position;
            var count = Physics.OverlapBoxNonAlloc(center, scale, _colliders, rotation, 
                                                   TriggerInPlayerCharacterLayerMask);
            
            switch (0 < count)
            {
                case true:
                    IsDetected = true;
                    break;
                case false:
                    _colliders[0] = null;
                    IsDetected = false;
                    break;
            }
        }
        
        private void OnDestroy()
        {
            LogManager.LogProgress();
            
            _meleeDataList.Clear();
            _meleeDataList = null;
        }

        /// <summary>
        /// Adds melee data for the character.
        /// </summary>
        /// <param name="data"> The damage value of melee data. </param>
        public void AddMeleeData(WeaponData data) => _meleeDataList.Add(data);
        
        /// <summary>
        /// Hit the character with melee attack.
        /// </summary>
        /// <param name="index"> Index number of melee data list held by a character. </param>
        public void Hit(int index)
        {
            LogManager.LogProgress();
            
            if (_colliders[0] is null)
            {
                return;
            }

            var parent = _colliders[0].transform.parent;
            if (parent.TryGetComponent<PlayerCharacter>(out var character) == false)
            {
                return;
            }
            
            var damagePoint = _meleeDataList[index].DamagePoint;
            var defensePenetrationPoint = _meleeDataList[index].DefensePenetrationPoint;
            damagePoint += DefaultDamagePoint;
            defensePenetrationPoint += DefaultDefensePenetrationPoint;
            
            character.TakeDamage(damagePoint, defensePenetrationPoint, DamageType.Default);
        }
        
        public bool IsDetected { get; private set; }
        
        #region UNITY EDITOR API

#if UNITY_EDITOR
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube (transform.position - position, scale);
        }
        
#endif

        #endregion
    }
}