using System.Collections;
using GloryDay.Debug.Log;
using Object.Character;
using UnityEngine;
using Utility.Manager;

namespace Object.Weapon
{
    public class SplashDamageArea : WeaponBase
    {
        #region COMPONENT FIELD API

        private ParticleSystemHandler _particleSystemHandler;

        #endregion
        
        #region CONSTANT FIELD API

        private const float Radius = 20f;
        
        private const int TriggerInEnemyCharacterLayerMask = 1 << 22;

        #endregion

        private AudioClip _explosionSound;
        
        private readonly Collider[] _colliders = new Collider[20];

        private void Awake()
        {
            LogManager.LogProgress();

            var key = DataManager.AudioData.Effect[12];
            _explosionSound = ResourceManager.AudioClipResource.Effect[key];
            
            _particleSystemHandler = GetComponentInChildren<ParticleSystemHandler>();
        }

#if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, Radius);
        }

#endif
        
        public void Attack()
        {
            LogManager.LogProgress();

            StartCoroutine(Attacking());
        }

        private IEnumerator Attacking()
        {
            var center = transform.position;
            var count = Physics.OverlapSphereNonAlloc(center, Radius, _colliders, TriggerInEnemyCharacterLayerMask);
            for (var i = 0; i < count; i++)
            {
                var character = _colliders[i].GetComponentInParent<EnemyCharacter>();
                character.TakeDamage(DamagePoint, DefensePenetrationPoint, DamageType.Explosive);
            }

            SoundManager.OnPlayEffectAudioSource(_explosionSound);
            
            _particleSystemHandler.Play(0);
            while (_particleSystemHandler.IsPlaying(0))
            {
                yield return null;
            }
            
            ObjectManager.OnRelease(gameObject);
        }
    }
}