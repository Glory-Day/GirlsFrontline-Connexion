using GloryDay.Log;
using GloryDay.SpineServices;
using Spine;
using UnityEngine;
using Utility.State;

namespace Object.Character.Enemy
{
    public partial class HydraCharacter
    {
        private class AttackState : StateBase<HydraCharacter>
        {
            private int _count;
            
            public AttackState(HydraCharacter component) : base(component) { }

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

                
                var index = @event.Int == 0 ? Random.Range(4, 7) : Random.Range(7, 10);
                Component.ParticleSystemHandler.Emit(index);
                
                var target = Component.GetPlayerCharacterPosition();
                Component._action.Prepare(0, 0, @event.Int, target).Fire(0);
            }
        }
        
        private new class DieState : StateBase<HydraCharacter>
        {
            public DieState(HydraCharacter component) : base(component) { }

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
                if (Component.SkeletonAnimationHandler.GetEventData(1) != @event.Data)
                {
                    return;
                }
                
                Component.StartCoroutine(Component.FadeOut());
            }
        }
        
        private class MoveState : StateBase<HydraCharacter>
        {
            public MoveState(HydraCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();

                Component.MoveToDestination();
                
                Component.SkeletonAnimationHandler.Play(2, 0, true);
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

        private class UseSkill : StateBase<HydraCharacter>
        {
            public UseSkill(HydraCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();

                Component._coolDownTime = 0f;
                
                Component.SkeletonAnimationHandler.AddListener(AnimationEventType.Complete, Completed);
                Component.SkeletonAnimationHandler.AddEventListener(Shoot);
                
                Component.SkeletonAnimationHandler.Play(3);
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
                
                Component.FiniteStateMachine.ChangeTo(Component.States[0]);
            }
            
            private void Shoot(TrackEntry trackEntry, Spine.Event @event)
            {
                LogManager.LogProgress();
                
                if (Component.SkeletonAnimationHandler.GetEventData(0) != @event.Data)
                {
                    return;
                }

                var index = Random.Range(1, 4);
                Component.ParticleSystemHandler.Emit(index);
                
                for (var i = 0; i < 5; i++)
                {
                    Component._action.Prepare(1, 1, i).Fire(0);
                }
            }
        }
        
        private new class WaitState : StateBase<HydraCharacter>
        {
            public WaitState(HydraCharacter component) : base(component) { }

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