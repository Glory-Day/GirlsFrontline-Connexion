using GloryDay.Debug.Log;
using GloryDay.SpineServices;
using Spine;
using UnityEngine;
using Utility.State;

namespace Object.Character.Enemy
{
    public partial class ZombieBCharacter
    {
        private class AttackState : StateBase<ZombieBCharacter>
        {
            private int _count;
            
            public AttackState(ZombieBCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();
                
                _count = Random.Range(1, 6);
                
                Component.SkeletonAnimationHandler.AddListener(AnimationEventType.Complete, Completed);
                Component.SkeletonAnimationHandler.AddEventListener(Shoot);
                
                Component.SkeletonAnimationHandler.Play(0);
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
                
                Component.FiniteStateMachine.ChangeTo(Component.States[1]);
            }

            private void Shoot(TrackEntry trackEntry, Spine.Event @event)
            {
                LogManager.LogProgress();
                
                if (Component.SkeletonAnimationHandler.GetEventData(0) != @event.Data)
                {
                    return;
                }

                var index = Random.Range(0, 3);
                var iterator = Random.Range(0, 5);
                Component.ParticleSystemHandler.Emit(index + 1);
                Component._action.Prepare(0, 0, iterator).Fire(0);
            }
        }
        
        private new class DieState : StateBase<ZombieBCharacter>
        {
            public DieState(ZombieBCharacter component) : base(component) { }

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
        
        private class MoveState : StateBase<ZombieBCharacter>
        {
            public MoveState(ZombieBCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();

                Component.MoveToDestination();
                
                Component.SkeletonAnimationHandler.Play(4, 0, true);
            }

            public override void Update()
            {
                if (Component.IsArrivedAtDestination)
                {
                    Component.FiniteStateMachine.ChangeTo(Component.States[0]);
                }
            }

            public override void End()
            {
                LogManager.LogProgress();
                
                Component.SetRandomDestinationInRange(5);
            }
        }
        
        private new class WaitState : StateBase<ZombieBCharacter>
        {
            public WaitState(ZombieBCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();

                Component.SkeletonAnimationHandler.Play(5, 0, true);
            }

            public override void Update() { }

            public override void End()
            {
                LogManager.LogProgress();
            }
        }
    }
}