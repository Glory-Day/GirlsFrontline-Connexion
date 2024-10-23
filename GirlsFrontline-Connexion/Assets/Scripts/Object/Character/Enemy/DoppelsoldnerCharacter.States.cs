using GloryDay.Debug.Log;
using GloryDay.SpineServices;
using Object.Map;
using Object.Weapon;
using Spine;
using UnityEngine;
using Utility.Manager;
using Utility.State;

namespace Object.Character.Enemy
{
    public partial class DoppelsoldnerCharacter
    {
        private class AttackState : StateBase<DoppelsoldnerCharacter>
        {
            private int _count;
            
            public AttackState(DoppelsoldnerCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();
                
                _count = Random.Range(3, 6);
                
                Component.SkeletonAnimationHandler.AddListener(AnimationEventType.Complete, Completed);
                Component.SkeletonAnimationHandler.AddEventListener(Shoot);
                
                Component.SkeletonAnimationHandler.Play(0, 0, true);
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
                
                _count--;
                if (0 < _count)
                {
                    return;
                }
                
                var state = Component.States[2];
                if (Component._coolDownTime < MaximumCoolDownTime)
                {
                    state = Component.States[1];
                }
                
                Component.FiniteStateMachine.ChangeTo(state);
            }
            
            private void Shoot(TrackEntry trackEntry, Spine.Event @event)
            {
                LogManager.LogProgress();
                
                if (Component.SkeletonAnimationHandler.GetEventData(0) != @event.Data)
                {
                    return;
                }

                var index = Random.Range(0, 3);
                Component.ParticleSystemHandler.Emit(index * 2 + @event.Int + 1);
                Component._action.Prepare(0, 0, @event.Int).Fire(1);
            }
        }
        
        private new class DieState : StateBase<DoppelsoldnerCharacter>
        {
            public DieState(DoppelsoldnerCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();
                
                Component.ItemSpawner.Spawn();
                Component.OnRemoveRecord.Invoke(Component);
                
                Component.SkeletonAnimationHandler.AddEventListener(FadeOut);
                
                switch (Component.DeadCause)
                {
                    case DamageType.Default:
                    case DamageType.Critical:
                    case DamageType.Explosive:
                        Component.SkeletonAnimationHandler.Play(2);
                        break;
                    default:
                        throw new System.ArgumentOutOfRangeException();
                }
            }

            public override void Update() { }

            public override void End()
            {
                LogManager.LogProgress();
                
                Component.SkeletonAnimationHandler.RemoveEventListener(FadeOut);
            }
            
            private void FadeOut(TrackEntry trackEntry, Spine.Event @event)
            {
                LogManager.LogProgress();
                
                if (Component.SkeletonAnimationHandler.GetEventData(1) != @event.Data)
                {
                    return;
                }
                
                Component.StartCoroutine(Component.FadeOut());
            }
        }
        
        private class MoveState : StateBase<DoppelsoldnerCharacter>
        {
            public MoveState(DoppelsoldnerCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();
                
                Component.MoveToDestination();
                
                Component.SkeletonAnimationHandler.Play(3, 0, true);
            }

            public override void Update()
            {
                if (Component.IsArrivedAtDestination == false)
                {
                    return;
                }

                var state = Component.States[2];
                if (Component._coolDownTime < MaximumCoolDownTime)
                {
                    state = Component.States[0];
                }
                
                Component.FiniteStateMachine.ChangeTo(state);
            }

            public override void End()
            {
                LogManager.LogProgress();
                
                Component.SetRandomDestinationInRange(2);
            }
        }

        private class UseSkill : StateBase<DoppelsoldnerCharacter>
        {
            private readonly Tile[] _tiles = new Tile[6];

            private bool _isShot;
            private readonly Grenade[] _grenades = new Grenade[6];
            
            public UseSkill(DoppelsoldnerCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();

                Component._coolDownTime = 0f;

                _isShot = false;
                for (var i = 0; i < 6; i++)
                {
                    _tiles[i] = Component.TileMap.GetRandom();

                    var destination = _tiles[i].Position;
                    _grenades[i] = Component._action.Prepare(0, destination, 1, i);
                    
                    _tiles[i]?.StartWarningState(_grenades[i].InstanceID);
                }
                
                Component.SkeletonAnimationHandler.AddListener(AnimationEventType.Complete, Completed);
                Component.SkeletonAnimationHandler.AddEventListener(Shoot);
                
                Component.SkeletonAnimationHandler.Play(1);
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
                    for (var i = 0; i < 6; i++)
                    {
                        _tiles[i]?.StopWarningState(_grenades[i].InstanceID);
                        
                        ObjectManager.OnRelease(_grenades[i].gameObject);
                        _grenades[i] = null;
                    }
                }
                
                Component.FiniteStateMachine.ChangeTo(Component.States[1]);
            }

            private void Shoot(TrackEntry trackEntry, Spine.Event @event)
            {
                LogManager.LogProgress();
                
                if (Component.SkeletonAnimationHandler.GetEventData(0) != @event.Data)
                {
                    return;
                }

                var index = @event.Int;
                Component.ParticleSystemHandler.Emit(index + 7);
                
                _isShot = true;
                _grenades[index].Launch();
            }
        }
        
        private new class WaitState : StateBase<DoppelsoldnerCharacter>
        {
            public WaitState(DoppelsoldnerCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();
                
                Component.SkeletonAnimationHandler.Play(4, 0, true);
            }

            public override void Update() { }

            public override void End()
            {
                LogManager.LogProgress();
            }
        }
    }
}