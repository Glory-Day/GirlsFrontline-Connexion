using System;
using System.Collections;
using GloryDay.Log;
using Object.Character;
using UnityEngine;
using Utility.Manager;

namespace Object.Weapon
{
    public class Bullet : ProjectileBase
    {
        #region COMPONENT FIELD API

        private SpriteRenderer _spriteRenderer;
        private ParticleSystemHandler _particleSystemHandler;

        #endregion
        
        private Vector3 _target;
        private bool _hasTarget;

        private Vector3 _direction;
        
        private readonly AudioClip[] _fireSounds = new AudioClip[2];
        
        private readonly WaitUntil _instruction = new WaitUntil(() => GameManager.IsApplicationPaused == false);

        private void Awake()
        {
            LogManager.LogProgress();

            _spriteRenderer = GetComponent<SpriteRenderer>();
            
            _particleSystemHandler = GetComponentInChildren<ParticleSystemHandler>();
            
            var key = DataManager.AudioData.Effect[9];
            _fireSounds[0] = ResourceManager.AudioClipResource.Effect[key];
            
            key = DataManager.AudioData.Effect[10];
            _fireSounds[1] = ResourceManager.AudioClipResource.Effect[key];
        }

        private void OnEnable()
        {
            LogManager.LogProgress();

            _spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        }

        private void Update()
        {
            var speed = SpeedPoint * Time.deltaTime;
            if (_hasTarget)
            {
                var position = transform.position;
                var movedPosition = Vector3.MoveTowards(position, _target, speed);

                transform.position = movedPosition;
            }
            else
            {
                transform.Translate(_direction * speed);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            LogManager.LogProgress();

            if (other.CompareTag("Ground"))
            {
                StartCoroutine(PlayingEffect());

                return;
            }
            
            if (other.TryGetComponent<HealthPointBar>(out var component) == false)
            {
                return;
            }

            if (component.CompareTag(CalledCharacterTag))
            {
                return;
            }
            
            var parent = other.transform.parent;
            if (parent.TryGetComponent<CharacterBase>(out var character))
            {
                character.EmitHitEffect();
                character.TakeDamage(DamagePoint, DefensePenetrationPoint, DamageType.Default);
            }
            
            ObjectManager.OnRelease(gameObject);
        }

        private IEnumerator PlayingEffect()
        {
            _spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
            
            _particleSystemHandler.Play(0);
            while (_particleSystemHandler.IsPlaying(0))
            {
                yield return _instruction;
            }
                
            ObjectManager.OnRelease(gameObject);
        }

        public void SetTarget(Vector3? position)
        {
            if (position is null)
            {
                _hasTarget = false;
            }
            else
            {
                _target = (Vector3)position;
                _hasTarget = true;
                
                transform.rotation = Rotate(_target - transform.position);
            }
        }

        public void SetData(float damagePoint, float defensePenetrationPoint, float speedPoint, bool isFlip)
        {
            base.SetData(damagePoint, defensePenetrationPoint, speedPoint);

            _direction = isFlip ? Vector3.right : Vector3.left;
        }

        public void Fire()
        {
            LogManager.LogProgress();
            
            gameObject.SetActive(true);
        }
        
        public void Fire(int index)
        {
            LogManager.LogProgress();
            
            SoundManager.OnPlayEffectAudioSource(_fireSounds[index]);
            
            gameObject.SetActive(true);
        }
    }
}