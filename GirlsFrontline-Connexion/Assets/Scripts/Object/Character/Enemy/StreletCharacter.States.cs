using GloryDay.Debug.Log;
using GloryDay.SpineServices;
using Spine;
using UnityEngine;
using Utility.State;

namespace Object.Character.Enemy
{
    public partial class StreletCharacter
    {
        private class AttackState : StateBase<StreletCharacter>
        {
            private int _count;

            public AttackState(StreletCharacter component) : base(component) { }

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
                
                Component.FiniteStateMachine.ChangeTo(Component.States[1]);
            }

            private void Shoot(TrackEntry trackEntry, Spine.Event @event)
            {
                LogManager.LogProgress();
                
                if (Component.SkeletonAnimationHandler.GetEventData(0) != @event.Data)
                {
                    return;
                }
                
                Component.ParticleSystemHandler.Emit(@event.Int + 1);
                Component._action.Prepare(0, 0, 0).Fire(0);
            }
        }
        
        private new class DieState : StateBase<StreletCharacter>
        {
            public DieState(StreletCharacter component) : base(component) { }

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
        
        private class MoveState : StateBase<StreletCharacter>
        {
            public MoveState(StreletCharacter component) : base(component) { }

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
        
        private new class WaitState : StateBase<StreletCharacter>
        {
            public WaitState(StreletCharacter component) : base(component) { }

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