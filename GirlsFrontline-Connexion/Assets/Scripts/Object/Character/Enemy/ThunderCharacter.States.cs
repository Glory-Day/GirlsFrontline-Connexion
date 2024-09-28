using GloryDay.Log;
using GloryDay.SpineServices;
using Spine;
using UnityEngine;
using Utility.State;
using Event = Spine.Event;

namespace Object.Character.Enemy
{
    public partial class ThunderCharacter
    {
        private class AttackState : StateBase<ThunderCharacter>
        {
            private int _count;
            
            public AttackState(ThunderCharacter component) : base(component) { }

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
                
                Component.FiniteStateMachine.ChangeTo(Component.States[2]);
            }
            
            private void Shoot(TrackEntry trackEntry, Event @event)
            {
                LogManager.LogProgress();
                
                if (Component.SkeletonAnimationHandler.GetEventData(0) != @event.Data)
                {
                    return;
                }
                
                var target = Component.GetPlayerCharacterPosition();
                Component.ParticleSystemHandler.Emit(@event.Int + 1);
                Component._action.Prepare(0, 0, 0, target).Fire(0);
            }
        }
        
        private new class DieState : StateBase<ThunderCharacter>
        {
            public DieState(ThunderCharacter component) : base(component) { }

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
                        throw new System.ArgumentOutOfRangeException();
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
                if (Component.SkeletonAnimationHandler.GetEventData(1) != @event.Data)
                {
                    return;
                }
                
                Component.StartCoroutine(Component.FadeOut());
            }
        }
        
        private class MoveState : StateBase<ThunderCharacter>
        {
            public MoveState(ThunderCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();

                Component.MoveToDestination();
                
                Component.SkeletonAnimationHandler.Play(4, 0, true);
            }

            public override void Update()
            {
                if (Component.IsArrivedAtDestination == false)
                {
                    return;
                }

                Component.FiniteStateMachine.ChangeTo(Component.States[0]);
            }

            public override void End()
            {
                LogManager.LogProgress();
            }
        }

        private class UseSkill : StateBase<ThunderCharacter>
        {
            private int _count;
            
            public UseSkill(ThunderCharacter component) : base(component) { }
            
            public override void Start()
            {
                LogManager.LogProgress();
                
                _count++;
                
                Component.SkeletonAnimationHandler.AddListener(AnimationEventType.Complete, Completed);
                Component.SkeletonAnimationHandler.AddEventListener(Shoot);
                
                var time = Component.SkeletonAnimationHandler.Play(5).Animation.Duration;
                Component.SetRandomDestinationInRange(8);
                Component.MoveToDestinationInTime(time);
                
                Component.ParticleSystemHandler.Emit(5);
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

                _count++;
                if (_count < MaximumAttackCount)
                {
                    Component.FiniteStateMachine.ChangeTo(Component.States[2]);
                    
                    return;
                }

                _count = 0;
                
                Component.FiniteStateMachine.ChangeTo(Component.States[0]);
            }
            
            private void Shoot(TrackEntry trackEntry, Event @event)
            {
                LogManager.LogProgress();
                
                if (Component.SkeletonAnimationHandler.GetEventData(0) != @event.Data)
                {
                    return;
                }
                
                var target = Component.GetPlayerCharacterPosition();
                Component.ParticleSystemHandler.Emit(4);
                Component._action.Prepare(1, 1, 0, target).Fire(1);
            }
        }
        
        private new class WaitState : StateBase<ThunderCharacter>
        {
            public WaitState(ThunderCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();

                Component.SkeletonAnimationHandler.Play(6, 0, true);
            }

            public override void Update() { }

            public override void End()
            {
                LogManager.LogProgress();
            }
        }
    }
}