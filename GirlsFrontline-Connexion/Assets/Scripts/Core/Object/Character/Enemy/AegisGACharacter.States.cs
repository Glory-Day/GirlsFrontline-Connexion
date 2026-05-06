using System;
using GloryDay.Debug;
using GloryDay.SpineServices;
using Spine;
using Core.Utility.State;

using Console = GloryDay.Debug.Console;

namespace Core.Object.Character.Enemy
{
    public partial class AegisGACharacter
    {
        private class AttackState : StateBase<AegisGACharacter>
        {
            public AttackState(AegisGACharacter component) : base(component) { }

            public override void Start()
            {
                Console.LogProgress();
                
                Component.SkeletonAnimationHandler.AddListener(AnimationEventType.Complete, Completed);
                Component.SkeletonAnimationHandler.AddEventListener(Hit);
                
                Component.SkeletonAnimationHandler.Play(0, 0, true);
            }

            public override void Update() { }

            public override void End()
            {
                Console.LogProgress();
                
                Component.SkeletonAnimationHandler.RemoveListener(AnimationEventType.Complete, Completed);
                Component.SkeletonAnimationHandler.RemoveEventListener(Hit);
            }

            private void Completed(TrackEntry trackEntry)
            {
                Console.LogProgress();
                
                if (Component._action.IsDetected == false)
                {
                    Component.FiniteStateMachine.ChangeTo(Component.States[1]);
                }
            }

            private void Hit(TrackEntry trackEntry, Event @event)
            {
                Console.LogProgress();
                
                if (Component.SkeletonAnimationHandler.GetEventData(0) != @event.Data)
                {
                    return;
                }
                
                Component._action.Hit(0);
            }
        }
        
        private new class DieState : StateBase<AegisGACharacter>
        {
            public DieState(AegisGACharacter component) : base(component) { }

            public override void Start()
            {
                Console.LogProgress();
                
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
                Console.LogProgress();
                
                Component.SkeletonAnimationHandler.RemoveEventListener(FadeOut);
            }

            private void FadeOut(TrackEntry trackEntry, Event @event)
            {
                Console.LogProgress();
                
                if (Component.SkeletonAnimationHandler.GetEventData(1) != @event.Data)
                {
                    return;
                }
                
                Component.StartCoroutine(Component.FadeOut());
            }
        }
        
        private class MoveState : StateBase<AegisGACharacter>
        {
            public MoveState(AegisGACharacter component) : base(component) { }

            public override void Start()
            {
                Console.LogProgress();
                
                Component.MoveToLeftDirection();
                
                Component.SkeletonAnimationHandler.Play(4, 0, true);
            }

            public override void Update()
            {
                if (Component._action.IsDetected)
                {
                    Component.FiniteStateMachine.ChangeTo(Component.States[0]);
                }
            }

            public override void End()
            {
                Console.LogProgress();
                
                Component.StopMoving();
            }
        }
        
        private new class WaitState : StateBase<AegisGACharacter>
        {
            public WaitState(AegisGACharacter component) : base(component) { }

            public override void Start()
            {
                Console.LogProgress();
                
                Component.SkeletonAnimationHandler.Play(5, 0, true);
            }

            public override void Update() { }

            public override void End()
            {
                Console.LogProgress();
            }
        }
    }
}