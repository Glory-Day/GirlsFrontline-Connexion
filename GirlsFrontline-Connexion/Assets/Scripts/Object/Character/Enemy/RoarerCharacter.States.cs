using System;
using GloryDay.Debug.Log;
using GloryDay.SpineServices;
using Spine;
using Utility.Manager;
using Utility.State;

namespace Object.Character.Enemy
{
    public partial class RoarerCharacter
    {
        private class AttackState : StateBase<RoarerCharacter>
        {
            public AttackState(RoarerCharacter component) : base(component) { }

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
                
                if (Component._action.IsDetected == false)
                {
                    Component.FiniteStateMachine.ChangeTo(Component.States[1]);

                    return;
                }

                var state = Component.States[2];
                if (Component._count < MaximumAttackCount)
                {
                    state = Component.States[0];
                }
                
                Component.FiniteStateMachine.ChangeTo(state);
            }

            private void Hit(TrackEntry trackEntry, Event @event)
            {
                LogManager.LogProgress();
                
                if (Component.SkeletonAnimationHandler.GetEventData(0) != @event.Data)
                {
                    return;
                }

                Component._count++;
                
                Component._action.Hit(0);
            }
        }
        
        private new class DieState : StateBase<RoarerCharacter>
        {
            public DieState(RoarerCharacter component) : base(component) { }

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
                        Component.SkeletonAnimationHandler.Play(1);
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
                
                if (Component.SkeletonAnimationHandler.GetEventData(1) != @event.Data)
                {
                    return;
                }
                
                Component.StartCoroutine(Component.FadeOut());
            }
        }
        
        private class MoveState : StateBase<RoarerCharacter>
        {
            public MoveState(RoarerCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();
                
                Component.MoveToLeftDirection();
                
                Component.SkeletonAnimationHandler.Play(2, 0, true);
            }

            public override void Update()
            {
                if (Component._action.IsDetected == false)
                {
                    return;
                }

                var state = Component.States[2];
                if (Component._count < MaximumAttackCount)
                {
                    state = Component.States[0];
                }
                
                Component.FiniteStateMachine.ChangeTo(state);
            }

            public override void End()
            {
                LogManager.LogProgress();
                
                Component.StopMoving();
            }
        }

        private class UseSkill : StateBase<RoarerCharacter>
        {
            public UseSkill(RoarerCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();

                Component._count = 0;
                
                Component.SkeletonAnimationHandler.AddListener(AnimationEventType.Complete, Completed);
                Component.SkeletonAnimationHandler.AddEventListener(Hit);
                
                Component.SkeletonAnimationHandler.Play(3);
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
                
                var state = Component.States[1];
                if (Component._action.IsDetected)
                {
                    state = Component.States[0];
                }
                
                Component.FiniteStateMachine.ChangeTo(state);
            }

            private void Hit(TrackEntry trackEntry, Event @event)
            {
                LogManager.LogProgress();
                
                if (Component.SkeletonAnimationHandler.GetEventData(0) != @event.Data)
                {
                    return;
                }
                
                SoundManager.OnPlayEffectAudioSource(Component._explosionSound);
                
                Component.ParticleSystemHandler.Emit(1, 6);
                Component._action.Hit(1);
            }
        }
        
        private new class WaitState : StateBase<RoarerCharacter>
        {
            public WaitState(RoarerCharacter component) : base(component) { }

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