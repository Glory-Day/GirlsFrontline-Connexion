using System;
using GloryDay.Debug;
using GloryDay.SpineServices;
using Spine;
using Core.Utility.State;

using Console = GloryDay.Debug.Console;

namespace Core.Object.Character.Enemy
{
    public partial class UnknownCharacter
    {
        private class AttackState : StateBase<UnknownCharacter>
        {
            public AttackState(UnknownCharacter component) : base(component) { }

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
        
        private new class DieState : StateBase<UnknownCharacter>
        {
            public DieState(UnknownCharacter component) : base(component) { }

            public override void Start()
            {
                Console.LogProgress();
                
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
        
        private class MoveState : StateBase<UnknownCharacter>
        {
            public MoveState(UnknownCharacter component) : base(component) { }

            public override void Start()
            {
                Console.LogProgress();

                Component.MoveToLeftDirection();
                
                Component.SkeletonAnimationHandler.Play(2, 0, true);
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
        
        private new class WaitState : StateBase<UnknownCharacter>
        {
            public WaitState(UnknownCharacter component) : base(component) { }

            public override void Start()
            {
                Console.LogProgress();
                
                Component.SkeletonAnimationHandler.Play(0, 0, true);
            }

            public override void Update() { }

            public override void End()
            {
                Console.LogProgress();
            }
        }
    }
}