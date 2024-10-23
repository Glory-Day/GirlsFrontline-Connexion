using GloryDay.Debug.Log;
using Object.Weapon;
using Spine;
using UnityEngine;
using UnityEngine.InputSystem;
using Utility.Manager;

namespace Object.Character
{
    public partial class PlayerCharacter
    {
        private void Attack(InputAction.CallbackContext context)
        {
            LogManager.LogProgress();
            
            IsAttacking = true;
        }

        private void CancelAttack(InputAction.CallbackContext context)
        {
            LogManager.LogProgress();
            
            IsAttacking = false;
        }

        private void Shoot01(TrackEntry trackEntry, Spine.Event @event)
        {
            if (SkeletonAnimationHandler.GetEventData(0) != @event.Data)
            {
                return;
            }
            
            ParticleSystemHandler.Emit(@event.Int + 1);
            _projectileAttackAction.Prepare(0, 0, 0).Fire(0);
        }
        
        private void Move(InputAction.CallbackContext context)
        {
            var vector = context.ReadValue<Vector2>();
            if (vector.x < 0f)
            {
                IsBackMoving = true;
                IsMoving = false;
            }
            else
            {
                IsBackMoving = false;
                IsMoving = true;
            }
            
            var direction = new Vector3(vector.x, 0f, vector.y);
            
            Rigidbody.velocity = AdjustDirectionToSlope(direction) * SpeedPoint;
        }

        private void CancelMove(InputAction.CallbackContext context)
        {
            LogManager.LogProgress();
            
            IsMoving = false;
            IsBackMoving = false;

            Rigidbody.velocity = Vector3.zero;
        }
        
        private void UseSkill01(InputAction.CallbackContext context)
        {
            LogManager.LogProgress();
            
            if (_skillAction.Timers[0].IsCoolingTime)
            {
                return;
            }
            
            SoundManager.OnPlayEffectAudioSource(_skillSounds[Random.Range(0, 3)]);
            
            _skillAction.Run(0);
        }
        
        private void Shoot02(TrackEntry trackEntry, Spine.Event @event)
        {
            if (SkeletonAnimationHandler.GetEventData(1) != @event.Data)
            {
                return;
            }

            var position = ClosestEnemyCharacterPosition.Invoke();
            if (position.HasValue == false)
            {
                return;
            }
            
            var clone = ObjectManager.OnSpawn<SplashDamageArea>(_splashDamageArea.gameObject, position);
            clone.SetData(DamagePoint * 2f, 1f);
            clone.gameObject.SetActive(true);
            
            ParticleSystemHandler.Emit(4);
            
            clone.Attack();
        }

        private void UseSkill02(InputAction.CallbackContext context)
        {
            LogManager.LogProgress();
            
            if (_skillAction.Timers[1].IsCoolingTime)
            {
                return;
            }
            
            _skillAction.Run(1);
        }

        private void EnableInvulnerability()
        {
            LogManager.LogProgress();
            
            SoundManager.OnPlayEffectAudioSource(_shieldSound);
            
            ParticleSystemHandler.Emit(5);
            
            _isInvulnerability = true;
        }

        private void DisableInvulnerability()
        {
            LogManager.LogProgress();
            
            _isInvulnerability = false;
        }

        private void UseSkill03(InputAction.CallbackContext context)
        {
            LogManager.LogProgress();
            
            if (_skillAction.Timers[2].IsCoolingTime)
            {
                return;
            }
            
            _skillAction.Run(2);
        }

        private void EnableBuff()
        {
            LogManager.LogProgress();

            SpeedPoint += 10f;
            
            SoundManager.OnPlayEffectAudioSource(_buffSound);
            
            ParticleSystemHandler.Play(6);
            
            OnSpeedPointTextChanged.Invoke($"{(int)SpeedPoint}");
        }

        private void DisableBuff()
        {
            LogManager.LogProgress();
            
            SpeedPoint -= 10f;
            
            ParticleSystemHandler.Stop(6);
            
            OnSpeedPointTextChanged.Invoke($"{(int)SpeedPoint}");
        }

        private void FadeOut(TrackEntry trackEntry, Spine.Event @event)
        {
            LogManager.LogProgress();
                
            if (SkeletonAnimationHandler.GetEventData(2) != @event.Data)
            {
                return;
            }
                
            StartCoroutine(FadeOut());
        }

        private void SetAnimation()
        {
            if (IsAttacking)
            {
                if (_skillAction.Timers[0].IsCountingDown)
                {
                    if (IsMoving)
                    {
                        SkeletonAnimationHandler.Play(9, 0, true);
                    }
                    else if (IsBackMoving)
                    {
                        SkeletonAnimationHandler.Play(4, 0, true);
                    }
                    else
                    {
                        SkeletonAnimationHandler.Play(1, 0, true);
                    }
                }
                else if (IsMoving)
                {
                    SkeletonAnimationHandler.Play(7, 0, true);
                }
                else if (IsBackMoving)
                {
                    SkeletonAnimationHandler.Play(3, 0, true);
                }
                else
                {
                    SkeletonAnimationHandler.Play(0, 0, true);
                }
            }
            else if (IsMoving)
            {
                SkeletonAnimationHandler.Play(6, 0, true);
            }
            else if (IsBackMoving)
            {
                SkeletonAnimationHandler.Play(2, 0, true);
            }
            else
            {
                SkeletonAnimationHandler.Play(12, 0, true);
            }
        }

        private void SetAnimation(InputAction.CallbackContext context)
        {
            SetAnimation();
        }
        
        private bool IsAttacking { get; set; }
        
        private bool IsMoving { get; set; }
        
        private bool IsBackMoving { get; set; }
    }
}