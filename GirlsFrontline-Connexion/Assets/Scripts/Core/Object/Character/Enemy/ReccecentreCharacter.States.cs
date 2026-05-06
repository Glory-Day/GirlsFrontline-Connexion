using GloryDay.Debug;
using GloryDay.SpineServices;
using Spine;
using UnityEngine;
using Core.Utility.Manager;
using Core.Utility.State;
using Event = Spine.Event;

namespace Core.Object.Character.Enemy
{
    public partial class ReccecentreCharacter
    {
        private class AttackState : StateBase<ReccecentreCharacter>
        {
            private readonly string _data;

            public AttackState(ReccecentreCharacter component) : base(component)
            {
                _data = Component.characterData.WeaponData[0].Name;
            }

            public override void Start()
            {
                Console.LogProgress();
                
                Component.SkeletonAnimationHandler.AddListener(AnimationEventType.Complete, Completed);
                Component.SkeletonAnimationHandler.AddEventListener(Spawn);
                
                Component.SkeletonAnimationHandler.Play(0);
            }

            public override void Update() { }

            public override void End()
            {
                Console.LogProgress();
                
                Component.SkeletonAnimationHandler.RemoveListener(AnimationEventType.Complete, Completed);
                Component.SkeletonAnimationHandler.RemoveEventListener(Spawn);
            }

            private void Completed(TrackEntry trackEntry)
            {
                Console.LogProgress();
                
                Component.FiniteStateMachine.ChangeTo(Component.States[2]);
            }

            private void Spawn(TrackEntry trackEntry, Event @event)
            {
                Console.LogProgress();
                
                if (Component.SkeletonAnimationHandler.GetEventData(0) != @event.Data)
                {
                    return;
                }
                
                Component._action.Spawn(_data, 0, 0);
            }
        }
        
        private new class DieState : StateBase<ReccecentreCharacter>
        {
            public DieState(ReccecentreCharacter component) : base(component) { }

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
                        throw new System.ArgumentOutOfRangeException();
                }
            }

            public override void Update() { }

            public override void End()
            {
                Console.LogProgress();
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
        
        private class MoveState : StateBase<ReccecentreCharacter>
        {
            public MoveState(ReccecentreCharacter component) : base(component) { }

            public override void Start()
            {
                Console.LogProgress();
                
                Component.MoveToDestination();
                
                Component.SkeletonAnimationHandler.Play(2, 0, true);
            }

            public override void Update()
            {
                if (Component.IsArrivedAtDestination)
                {
                    Component.FiniteStateMachine.ChangeTo(Component.States[2]);
                }
            }

            public override void End()
            {
                Console.LogProgress();
            }
        }
        
        private class CoolDownState : StateBase<ReccecentreCharacter>
        {
            private float _coolDownTime;
            
            public CoolDownState(ReccecentreCharacter component) : base(component) { }

            public override void Start()
            {
                Console.LogProgress();

                _coolDownTime = 0f;
                
                Component.SkeletonAnimationHandler.Play(2, 0, true);
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
                Console.LogProgress();
            }
        }
        
        private new class WaitState : StateBase<ReccecentreCharacter>
        {
            public WaitState(ReccecentreCharacter component) : base(component) { }

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