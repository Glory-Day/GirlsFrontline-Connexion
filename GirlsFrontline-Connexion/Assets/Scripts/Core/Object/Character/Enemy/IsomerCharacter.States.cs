using System;
using GloryDay.Debug;
using Spine;
using Core.Utility.State;

using Console = GloryDay.Debug.Console;

namespace Core.Object.Character.Enemy
{
    public partial class IsomerCharacter
    {
        private new class DieState : StateBase<IsomerCharacter>
        {
            public DieState(IsomerCharacter component) : base(component) { }

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
                        Component.SkeletonAnimationHandler.Play(0);
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
                
                if (Component.SkeletonAnimationHandler.GetEventData(0) != @event.Data)
                {
                    return;
                }
                
                Component.StartCoroutine(Component.FadeOut());
            }
        }
        
        private class MoveState : StateBase<IsomerCharacter>
        {
            public MoveState(IsomerCharacter component) : base(component) { }

            public override void Start()
            {
                Console.LogProgress();
                
                Component.MoveToLeftDirection();
                
                Component.SkeletonAnimationHandler.Play(1, 0, true);
            }

            public override void Update() { }

            public override void End()
            {
                Console.LogProgress();
                
                Component.StopMoving();
            }
        }
        
        private new class WaitState : StateBase<IsomerCharacter>
        {
            public WaitState(IsomerCharacter component) : base(component) { }

            public override void Start()
            {
                Console.LogProgress();
                
                Component.SkeletonAnimationHandler.Play(2, 0, true);
            }

            public override void Update() { }

            public override void End()
            {
                Console.LogProgress();
            }
        }
    }
}