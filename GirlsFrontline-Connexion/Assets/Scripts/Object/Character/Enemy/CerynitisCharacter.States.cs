using GloryDay.Debug.Log;
using GloryDay.SpineServices;
using Spine;
using UnityEngine;
using Utility.State;
using Event = Spine.Event;

namespace Object.Character.Enemy
{
    public partial class CerynitisCharacter
    {
        private class AttackState : StateBase<CerynitisCharacter>
        {
            public AttackState(CerynitisCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();
                
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
                
                Component.FiniteStateMachine.ChangeTo(Component.States[2]);
            }

            private void Shoot(TrackEntry trackEntry, Event @event)
            {
                LogManager.LogProgress();
                
                if (Component.SkeletonAnimationHandler.GetEventData(0) != @event.Data)
                {
                    return;
                }

                var index = @event.Int;
                Component.ParticleSystemHandler.Emit(index % 6 + 1);
                Component._action.Prepare(0, 0, index).Fire(0);
            }
        }
        
        private new class DieState : StateBase<CerynitisCharacter>
        {
            public DieState(CerynitisCharacter component) : base(component) { }

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
                LogManager.LogProgress();
                
                if (Component.SkeletonAnimationHandler.GetEventData(1) != @event.Data)
                {
                    return;
                }
                
                Component.StartCoroutine(Component.FadeOut());
            }
        }
        
        private class MoveState : StateBase<CerynitisCharacter>
        {
            public MoveState(CerynitisCharacter component) : base(component) { }

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
            }
        }
        
        private class CoolDownState : StateBase<CerynitisCharacter>
        {
            private float _coolDownTime;

            public CoolDownState(CerynitisCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();

                _coolDownTime = 0f;
                
                Component.SkeletonAnimationHandler.Play(5, 0, true);
            }

            public override void Update()
            {
                _coolDownTime += Time.deltaTime;
                if (_coolDownTime < MaximumCoolDownTime)
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
        
        private new class WaitState : StateBase<CerynitisCharacter>
        {
            public WaitState(CerynitisCharacter component) : base(component) { }

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