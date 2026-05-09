using System.Collections;
using GloryDay.Debug;
using Core.Object.Character;
using UnityEngine;
using Core.Utility.Management;
using Core.Utility.Management.Resource;

namespace Core.Object.Weapon
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
            Console.LogProgress();

            _explosionSound = ResourceManager.AudioClipResource.Effect[AddressableAssetKeys.Assets_External_Audios_Effect_Explosion_Wav];
            
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
            Console.LogProgress();

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

            SoundManager.PlayEffectAudioSource(_explosionSound);
            
            _particleSystemHandler.Play(0);
            while (_particleSystemHandler.IsPlaying(0))
            {
                yield return null;
            }
            
            ObjectManager.OnRelease(gameObject);
        }
    }
}
