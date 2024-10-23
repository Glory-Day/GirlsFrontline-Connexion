using System;
using System.Collections;
using System.Collections.Generic;
using GloryDay.Debug.Log;
using Object.Item;
using Object.Map;
using Object.Weapon;
using UnityEngine;
using Utility;
using Utility.Manager;

namespace Object.Character
{
    public partial class PlayerCharacter : CharacterBase
    {
        #region COMPONENT FIELD API

        private ProjectileAttackAction _projectileAttackAction;
        private SkillAction _skillAction;
        
        #endregion

        #region CONSTANT FIELD API
        
        private const int WallForPlayerCharacterLayer = 16;
        
        private const float MaximumHealthPoint = 100f;
        private const float MaximumDamagePoint = 100f;
        private const float MaximumDefensePenetrationPoint = 100f;
        private const float MaximumDefensePoint = 100f;
        private const float MaximumSpeedPoint = 100f;
        
        private const float SpeedPointInReadyState = 10f;
        
        #endregion

        private PlayerControls _controls;

        private WeaponBase _splashDamageArea;

        private bool _isInvulnerability;

        private AudioClip _fallDownSound;
        private AudioClip _shieldSound;
        private AudioClip _buffSound;
        
        private AudioClip _deadSound;
        private AudioClip _startStageSound;
        private readonly AudioClip[] _skillSounds = new AudioClip[3];
        private AudioClip _victorySound;
        
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();
            
            // Initializes input system of the player character.
            _controls = new PlayerControls();
            _controls.Player.Attack.performed += Attack;
            _controls.Player.Attack.performed += SetAnimation;
            _controls.Player.Attack.canceled += CancelAttack;
            _controls.Player.Attack.canceled += SetAnimation;
            _controls.Player.Move.performed += Move;
            _controls.Player.Move.performed += SetAnimation;
            _controls.Player.Move.canceled += CancelMove;
            _controls.Player.Move.canceled += SetAnimation;
            _controls.Player.UseSkill01.performed += UseSkill01;
            _controls.Player.UseSkill02.performed += UseSkill02;
            _controls.Player.UseSkill03.performed += UseSkill03;
            
            // Initialize the attack action component of the player character.
            _projectileAttackAction = GetComponent<ProjectileAttackAction>();
            

            _skillAction = GetComponent<SkillAction>();
            _skillAction.Timers[0].OnCountingDownStarted += SetAnimation;
            _skillAction.Timers[0].OnCountingDownCompleted += SetAnimation;
            _skillAction.Timers[1].OnCountingDownStarted += EnableInvulnerability;
            _skillAction.Timers[1].OnCountingDownCompleted += DisableInvulnerability;
            _skillAction.Timers[2].OnCountingDownStarted += EnableBuff;
            _skillAction.Timers[2].OnCountingDownCompleted += DisableBuff;
            
            var key = DataManager.AudioData.Effect[19];
            HitSound = ResourceManager.AudioClipResource.Effect[key];
            
            key = DataManager.AudioData.Effect[15];
            _buffSound = ResourceManager.AudioClipResource.Effect[key];
            
            key = DataManager.AudioData.Effect[16];
            _shieldSound = ResourceManager.AudioClipResource.Effect[key];
            
            key = DataManager.AudioData.Voice[0];
            _deadSound = ResourceManager.AudioClipResource.Voice[key];
            
            key = DataManager.AudioData.Voice[1];
            _startStageSound = ResourceManager.AudioClipResource.Voice[key];
            
            key = DataManager.AudioData.Voice[2];
            _skillSounds[0] = ResourceManager.AudioClipResource.Voice[key];
            
            key = DataManager.AudioData.Voice[3];
            _skillSounds[1] = ResourceManager.AudioClipResource.Voice[key];
            
            key = DataManager.AudioData.Voice[4];
            _skillSounds[2] = ResourceManager.AudioClipResource.Voice[key];
            
            key = DataManager.AudioData.Voice[5];
            _victorySound = ResourceManager.AudioClipResource.Voice[key];
            
            var data = characterData.WeaponData[0];
            _splashDamageArea = ResourceManager.GameObjectResource.Weapon[data.Name];
            ObjectManager.OnCreate(_splashDamageArea.gameObject, transform.parent, 10);
            
            SkeletonAnimationHandler.AddEventListener(Shoot01);
            SkeletonAnimationHandler.AddEventListener(Shoot02);
            SkeletonAnimationHandler.AddEventListener(FadeOut);
        }

        protected override void OnEnable()
        {
            LogManager.LogProgress();
            
            base.OnEnable();
            
            OnDamagePointTextChanged?.Invoke($"{(int)DamagePoint}");
            OnDefensePenetratePointTextChanged?.Invoke($"{DefensePenetrationPoint:N1}");
            OnDefensePointTextChanged?.Invoke($"{(int)DefensePoint}");
            OnSpeedPointTextChanged?.Invoke($"{(int)SpeedPoint}");
            
            // Set the default destination.
            Destination = TileMap[4, 2]?.Position;
        }

        private void Start()
        {
            LogManager.LogProgress();
            
            // Set projectile attack action component.
            _projectileAttackAction.AddBulletData(characterData.BulletData[0]);
            _projectileAttackAction.SetCharacterDamagePoint(DamagePoint, DefensePenetrationPoint);
        }

        protected override void OnDestroy()
        {
            LogManager.LogProgress();
            
            base.OnDestroy();
            
            _controls.Player.Attack.performed -= Attack;
            _controls.Player.Attack.performed -= SetAnimation;
            _controls.Player.Attack.canceled -= CancelAttack;
            _controls.Player.Attack.canceled -= SetAnimation;
            _controls.Player.Move.performed -= Move;
            _controls.Player.Move.performed -= SetAnimation;
            _controls.Player.Move.canceled -= CancelMove;
            _controls.Player.Move.canceled -= SetAnimation;
            _controls.Player.UseSkill01.performed -= UseSkill01;
            _controls.Player.UseSkill02.performed -= UseSkill02;
            _controls.Player.UseSkill03.performed -= UseSkill03;
            _controls.Disable();
            _controls = null;
            
            _skillAction.Timers[0].OnCountingDownStarted -= SetAnimation;
            _skillAction.Timers[0].OnCountingDownCompleted -= SetAnimation;
            _skillAction.Timers[1].OnCountingDownStarted -= EnableInvulnerability;
            _skillAction.Timers[1].OnCountingDownCompleted -= DisableInvulnerability;
            _skillAction.Timers[2].OnCountingDownStarted -= EnableBuff;
            _skillAction.Timers[2].OnCountingDownCompleted -= DisableBuff;
        }

        /// <summary>
        /// Enable input system of the player character.
        /// </summary>
        public void EnablePlayerCharacterControls()
        {
            LogManager.LogProgress();
            
            _controls.Enable();
        }
        
        /// <summary>
        /// Disable input system of the player character.
        /// </summary>
        public void DisablePlayerCharacterControls()
        {
            LogManager.LogProgress();
            
            _controls.Disable();
        }
        
        /// <summary>
        /// Makes the collision detection system ignore all collisions
        /// between any collider in player character and any collider in wall.
        /// </summary>
        /// <param name="isIgnored"> Whether to ignore colliders. </param>
        public void IgnoreWallCollision(bool isIgnored = true)
        {
            LogManager.LogProgress();

            var layer = gameObject.layer;
            Physics.IgnoreLayerCollision(layer, WallForPlayerCharacterLayer, isIgnored);
        }

        public void MoveToDestination()
        {
            LogManager.LogProgress();
            
            IsMovingToDestination = true;
            
            StartCoroutine(MovingToDestination());
        }
        
        private IEnumerator MovingToDestination()
        {
            if (Destination.HasValue == false)
            {
                yield break;
            }
            
            SkeletonAnimationHandler.Play(6, 0, true);
            
            var distance = Vector3.Distance(Rigidbody.position, Destination.Value);
            var time = distance / SpeedPointInReadyState;
            
            yield return StartCoroutine(base.MovingToDestinationInTime(time));
            
            IsMovingToDestination = false;
        }
        
        public void SetWaitState()
        {
            LogManager.LogProgress();
            
            SoundManager.OnPlayVoiceAudioSource(_startStageSound);
            
            SkeletonAnimationHandler.Play(12, 0, true);
        }
        
        /// <summary>
        /// Set the player character's current spine animation to a victory animation.
        /// </summary>
        public void SetVictoryAnimation()
        {
            LogManager.LogProgress();

            SoundManager.OnPlayVoiceAudioSource(_victorySound);
            
            SkeletonAnimationHandler.Play(10);
            SkeletonAnimationHandler.Play(11, 0, true);
        }

        public void ApplyItem(ItemBase item)
        {
            LogManager.LogProgress();

            var score = 500;
            switch (item)
            {
                case DamagePointItem damagePointItem:
                {
                    DamagePoint += damagePointItem.DamagePoint;
                    if (DamagePoint >= MaximumDamagePoint)
                    {
                        DamagePoint = MaximumDamagePoint;
                        
                        score += 250;
                    }
                    
                    DefensePenetrationPoint += damagePointItem.DefensivePenetrationPoint;
                    if (DefensePenetrationPoint >= MaximumDefensePenetrationPoint)
                    {
                        DefensePenetrationPoint = MaximumDefensePenetrationPoint;
                        
                        score += 250;
                    }
                    
                    OnDamagePointTextChanged.Invoke($"{(int)DamagePoint}");
                    OnDefensePenetratePointTextChanged.Invoke($"{DefensePenetrationPoint:N1}");
                    
                    break;
                }
                case DefensivePointItem defensivePointItem:
                {
                    DefensePoint += defensivePointItem.DefensivePoint;
                    if (DefensePoint >= MaximumDefensePoint)
                    {
                        DefensePoint = MaximumDefensePoint;
                        
                        score += 500;
                    }
                    
                    OnDefensePointTextChanged.Invoke($"{(int)DefensePoint}");
                    
                    break;
                }
                case HealthPointItem healthPointItem:
                {
                    HealthPoint += healthPointItem.HealthPoint;
                    if (HealthPoint >= MaximumHealthPoint)
                    {
                        HealthPoint = MaximumHealthPoint;
                        
                        score += 500;
                    }
                    
                    break;
                }
                case SpeedPointItem speedPointItem:
                {
                    SpeedPoint += speedPointItem.SpeedPoint;
                    if (SpeedPoint >= MaximumSpeedPoint)
                    {
                        SpeedPoint = MaximumSpeedPoint;
                        
                        score += 500;
                    }
                    
                    OnSpeedPointTextChanged.Invoke($"{(int)SpeedPoint}");
                    
                    break;
                }
            }
            
            OnScoreChanged.Invoke(score);
        }

        public override void TakeDamage(float damagePoint, float defensePenetratePoint, DamageType type)
        {
            LogManager.LogProgress();
            
            if (_isInvulnerability)
            {
                return;
            }
            
            base.TakeDamage(damagePoint, defensePenetratePoint, type);

            if (IsAlive)
            {
                return;
            }
            
            DisablePlayerCharacterControls();
            
            SoundManager.OnPlayEffectAudioSource(_fallDownSound);
            SoundManager.OnPlayVoiceAudioSource(_deadSound);
            
            SkeletonAnimationHandler.Play(5);
        }

        public bool IsMovingToDestination{ get; private set; }
        
        public List<SkillAction.Timer> Timers => _skillAction.Timers;
        
        public CharacterSpawner.ClosestEnemyCharacterPositionCallback ClosestEnemyCharacterPosition;
        
        public ValueChangedCallback<string> OnDamagePointTextChanged;
        public ValueChangedCallback<string> OnDefensePenetratePointTextChanged;
        public ValueChangedCallback<string> OnDefensePointTextChanged;
        public ValueChangedCallback<string> OnSpeedPointTextChanged;
    }
}