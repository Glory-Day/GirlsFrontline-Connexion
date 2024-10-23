using System;
using GloryDay.Debug.Log;
using GloryDay.SpineServices;
using Spine;
using Utility.State;

namespace Object.Character.Enemy
{
    public partial class PathfinderCharacter
    {
        private class AttackState : StateBase<PathfinderCharacter>
        {
            public AttackState(PathfinderCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();
                
                Component.SkeletonAnimationHandler.AddEventListener(Hit);
                Component.SkeletonAnimationHandler.AddListener(AnimationEventType.Complete, Completed);
                
                Component.SkeletonAnimationHandler.Play(0, 0, true);
            }

            public override void Update() { }

            public override void End()
            {
                LogManager.LogProgress();
                
                Component.SkeletonAnimationHandler.RemoveEventListener(Hit);
                Component.SkeletonAnimationHandler.RemoveListener(AnimationEventType.Complete, Completed);
            }

            private void Completed(TrackEntry trackEntry)
            {
                LogManager.LogProgress();

                if (Component._action.IsDetected == false)
                {
                    Component.FiniteStateMachine.ChangeTo(Component.States[1]);
                }
            }

            private void Hit(TrackEntry trackEntry, Event @event)
            {
                LogManager.LogProgress();

                if (Component.SkeletonAnimationHandler.GetEventData(0) != @event.Data)
                {
                    return;
                }
                
                Component._action.Hit(0);
            }
        }
        
        private new class DieState : StateBase<PathfinderCharacter>
        {
            public DieState(PathfinderCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();
                
                Component.SkeletonAnimationHandler.AddEventListener(FadeOut);
                
                switch (Component.DeadCause)
                {
                    case DamageType.Default:
                    case DamageType.Critical:
                        Component.SkeletonAnimationHandler.Play(1);
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
                
                if (Component.SkeletonAnimationHandler.GetEventData(1) != @event.Data)
                {
                    return;
                }
                
                Component.StartCoroutine(Component.FadeOut());
            }
        }
        
        private class MoveState : StateBase<PathfinderCharacter>
        {
            public MoveState(PathfinderCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();

                Component.MoveToLeftDirection();
                
                Component.SkeletonAnimationHandler.Play(3, 0, true);
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
                LogManager.LogProgress();
                
                Component.StopMoving();
            }
        }
        
        private new class WaitState : StateBase<PathfinderCharacter>
        {
            public WaitState(PathfinderCharacter component) : base(component) { }

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