using System;
using GloryDay.Debug.Log;
using GloryDay.SpineServices;
using Object.Map;
using Object.Weapon;
using Spine;
using Utility.Manager;
using Utility.State;

namespace Object.Character.Enemy
{
    public partial class TeslatrooperCharacter
    {
        private class AttackState : StateBase<TeslatrooperCharacter>
        {
            public AttackState(TeslatrooperCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();
                
                Component.SkeletonAnimationHandler.AddListener(AnimationEventType.Complete, Completed);
                Component.SkeletonAnimationHandler.AddEventListener(Hit);
                
                Component.SkeletonAnimationHandler.Play(0, 0, true);
            }

            public override void Update() { }

            public override void End()
            {
                LogManager.LogProgress();
                
                Component.SkeletonAnimationHandler.RemoveListener(AnimationEventType.Complete, Completed);
                Component.SkeletonAnimationHandler.RemoveEventListener(Hit);
            }
            
            private void Completed(TrackEntry trackEntry)
            {
                LogManager.LogProgress();
                
                if (Component._meleeAttackAction.IsDetected == false)
                {
                    Component.FiniteStateMachine.ChangeTo(Component.States[1]);
                }
                else if (Component._coolDownTime >= MaximumCoolDownTime)
                {
                    Component.FiniteStateMachine.ChangeTo(Component.States[2]);
                }
            }
            
            private void Hit(TrackEntry trackEntry, Event @event)
            {
                LogManager.LogProgress();
                
                if (Component.SkeletonAnimationHandler.GetEventData(0) != @event.Data)
                {
                    return;
                }
                
                Component._meleeAttackAction.Hit(0);
            }
        }
        
        private new class DieState : StateBase<TeslatrooperCharacter>
        {
            public DieState(TeslatrooperCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();

                Component.ItemSpawner.Spawn();
                Component.OnRemoveRecord.Invoke(Component);
                
                Component.SkeletonAnimationHandler.AddEventListener(FadeOut);
                
                switch (Component.DeadCause)
                {
                    case DamageType.Default:
                        Component.SkeletonAnimationHandler.Play(1);
                        break;
                    case DamageType.Critical:
                        Component.SkeletonAnimationHandler.Play(3);
                        break;
                    case DamageType.Explosive:
                        Component.SkeletonAnimationHandler.Play(2);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            public override void Update() { }

            public override void End()
            {
                LogManager.LogProgress();
                
                Component.SkeletonAnimationHandler.RemoveEventListener(FadeOut);
            }
            
            private void FadeOut(TrackEntry trackEntry, Event @event)
            {
                LogManager.LogProgress();
                
                if (Component.SkeletonAnimationHandler.GetEventData(2) != @event.Data)
                {
                    return;
                }
                
                Component.StartCoroutine(Component.FadeOut());
            }
        }
        
        private class MoveState : StateBase<TeslatrooperCharacter>
        {
            private bool _isEnabled;

            public MoveState(TeslatrooperCharacter component) : base(component)
            {
                _isEnabled = true;
            }

            public override void Start()
            {
                LogManager.LogProgress();
                
                Component.MoveToLeftDirection();
                
                Component.SkeletonAnimationHandler.Play(4, 0, true);
            }

            public override void Update()
            {
                if (_isEnabled && Component.HealthPointBar.IsShieldEnabled == false)
                {
                    _isEnabled = false;
                    Component.FiniteStateMachine.ChangeTo(Component.States[3]);

                    return;
                }
                
                if (Component._meleeAttackAction.IsDetected)
                {
                    Component.FiniteStateMachine.ChangeTo(Component.States[0]);
                }
                else if (Component._coolDownTime >= MaximumCoolDownTime)
                {
                    Component.FiniteStateMachine.ChangeTo(Component.States[2]);
                }
            }

            public override void End()
            {
                LogManager.LogProgress();
                
                Component.StopMoving();
            }
        }

        private class UseSkill01 : StateBase<TeslatrooperCharacter>
        {
            private readonly Tile[] _tiles = new Tile[4];

            private bool _isShot;
            private readonly Grenade[] _grenades = new Grenade[4];
            
            public UseSkill01(TeslatrooperCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();

                Component._coolDownTime = 0f;

                for (var i = 0; i < 4; i++)
                {
                    _tiles[i] = Component.TileMap.GetRandom();
                    
                    var destination = _tiles[i].transform.position;
                    _grenades[i] = Component._projectileAttackAction.Prepare(0, destination, 0, i);
                    
                    _tiles[i]?.StartWarningState(_grenades[i].InstanceID);
                }

                _isShot = false;
                
                Component.SkeletonAnimationHandler.AddListener(AnimationEventType.Complete, Completed);
                Component.SkeletonAnimationHandler.AddEventListener(Shoot);
                
                Component.SkeletonAnimationHandler.Play(5);
            }

            public override void Update() { }

            public override void End()
            {
                LogManager.LogProgress();
                
                Component.SkeletonAnimationHandler.RemoveListener(AnimationEventType.Complete, Completed);
                Component.SkeletonAnimationHandler.RemoveEventListener(Shoot);
            }
            
            private void Completed(TrackEntry trackEntry)
            {
                LogManager.LogProgress();

                if (_isShot == false)
                {
                    for (var i = 0; i < 4; i++)
                    {
                        _tiles[i]?.StopWarningState(_grenades[i].InstanceID);
                        
                        ObjectManager.OnRelease(_grenades[i].gameObject);
                        _grenades[i] = null;
                    }
                }
                
                var state = Component.States[1];
                if (Component._meleeAttackAction.IsDetected)
                {
                    state = Component.States[0];
                }
                
                Component.FiniteStateMachine.ChangeTo(state);
            }

            private void Shoot(TrackEntry trackEntry, Event @event)
            {
                LogManager.LogProgress();
                
                if (Component.SkeletonAnimationHandler.GetEventData(1) != @event.Data)
                {
                    return;
                }
                
                for (var i = 0; i < 4; i++)
                {
                    Component.ParticleSystemHandler.Emit(i + 1);
                    
                    _grenades[i].Launch();
                }
                
                _isShot = true;
            }
        }

        private class UseSkill02 : StateBase<TeslatrooperCharacter>
        {
            public UseSkill02(TeslatrooperCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();

                Component.DefensePoint += AdditionalDefense;

                Component.SkeletonAnimationHandler.AddListener(AnimationEventType.Complete, Completed);
                
                Component.SkeletonAnimationHandler.AddAnimation(6);
            }

            public override void Update() { }

            public override void End()
            {
                LogManager.LogProgress();

                Component.DefensePoint -= AdditionalDefense;
                
                Component.SkeletonAnimationHandler.RemoveListener(AnimationEventType.Complete, Completed);
            }

            private void Completed(TrackEntry trackEntry)
            {
                LogManager.LogProgress();

                if (Component._meleeAttackAction.IsDetected)
                {
                    Component.FiniteStateMachine.ChangeTo(Component.States[0]);
                }
                else if (Component._coolDownTime < MaximumCoolDownTime)
                {
                    Component.FiniteStateMachine.ChangeTo(Component.States[2]);
                }
                else
                {
                    Component.FiniteStateMachine.ChangeTo(Component.States[1]);
                }
            }
        }
        
        private new class WaitState : StateBase<TeslatrooperCharacter>
        {
            public WaitState(TeslatrooperCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();

                Component.SkeletonAnimationHandler.Play(7, 0, true);
            }

            public override void Update() { }

            public override void End()
            {
                LogManager.LogProgress();
            }
        }
    }
}