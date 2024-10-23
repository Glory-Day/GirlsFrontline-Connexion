using GloryDay.Debug.Log;
using GloryDay.SpineServices;
using Spine;
using UnityEngine;
using Utility.State;

namespace Object.Character.Enemy
{
    public partial class PyxisCharacter
    {
        private class AttackState : StateBase<PyxisCharacter>
        {
            private int _count;
            private int _index;

            public AttackState(PyxisCharacter component) : base(component) { }
            
            public override void Start()
            {
                LogManager.LogProgress();
                
                _count = Random.Range(40, 100);
                
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
                
                Component.FiniteStateMachine.ChangeTo(Component.States[3]);
            }

            private void Shoot(TrackEntry trackEntry, Spine.Event @event)
            {
                LogManager.LogProgress();
                
                if (Component.SkeletonAnimationHandler.GetEventData(0) != @event.Data)
                {
                    return;
                }

                _index %= 4;
                var index = Random.Range(1 + _index * 3, 4 + _index * 3);
                Component.ParticleSystemHandler.Emit(index);
                Component._action.Prepare(0, 0, _index++).Fire(0);
            }
        }
        
        private new class DieState : StateBase<PyxisCharacter>
        {
            public DieState(PyxisCharacter component) : base(component) { }
            
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
                LogManager.LogProgress();
                
                if (Component.SkeletonAnimationHandler.GetEventData(1) != @event.Data)
                {
                    return;
                }
                
                Component.StartCoroutine(Component.FadeOut());
            }
        }
        
        private class MoveState : StateBase<PyxisCharacter>
        {
            public MoveState(PyxisCharacter component) : base(component) { }
            
            public override void Start()
            {
                LogManager.LogProgress();

                Component.MoveToDestination();
                
                Component.SkeletonAnimationHandler.Play(3);
            }

            public override void Update()
            {
                if (Component.IsArrivedAtDestination)
                {
                    Component.FiniteStateMachine.ChangeTo(Component.States[3]);
                }
            }

            public override void End()
            {
                LogManager.LogProgress();
            }
        }

        private class MoveUpState : StateBase<PyxisCharacter>
        {
            public MoveUpState(PyxisCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();

                Component.HealthPointBar.Collider.enabled = true;
                
                Component.SkeletonAnimationHandler.AddListener(AnimationEventType.Complete, Completed);
                
                Component.SkeletonAnimationHandler.Play(2);
            }

            public override void Update() { }

            public override void End()
            {
                LogManager.LogProgress();
                
                Component.SkeletonAnimationHandler.RemoveListener(AnimationEventType.Complete, Completed);
            }

            private void Completed(TrackEntry trackEntry)
            {
                LogManager.LogProgress();
                
                Component.FiniteStateMachine.ChangeTo(Component.States[0]);
            }
        }
        
        private class CoolDownState : StateBase<PyxisCharacter>
        {
            private float _coolDownTime;
            
            public CoolDownState(PyxisCharacter component) : base(component) { }
            
            public override void Start()
            {
                LogManager.LogProgress();
                
                _coolDownTime = 0f;
                
                Component.HealthPointBar.Collider.enabled = false;
                
                Component.SkeletonAnimationHandler.Play(3);
            }

            public override void Update()
            {
                _coolDownTime += Time.deltaTime;
                if (_coolDownTime < MaximumCoolDownTime)
                {
                    return;
                }
                
                Component.FiniteStateMachine.ChangeTo(Component.States[2]);
            }

            public override void End()
            {
                LogManager.LogProgress();
            }
        }
        
        private new class WaitState : StateBase<PyxisCharacter>
        {
            public WaitState(PyxisCharacter component) : base(component) { }

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