using GloryDay.Debug;
using GloryDay.SpineServices;
using Core.Object.Map;
using Core.Object.Weapon;
using Spine;
using UnityEngine;
using Core.Utility.Management;
using Core.Utility.State;

namespace Core.Object.Character.Enemy
{
    public partial class ArcherCharacter
    {
        private class AttackState : StateBase<ArcherCharacter>
        {
            private int _count;

            public AttackState(ArcherCharacter component) : base(component) { }

            public override void Start()
            {
                Console.LogProgress();
                
                _count = Random.Range(1, 6);
                
                Component.SkeletonAnimationHandler.AddListener(AnimationEventType.Complete, Completed);
                Component.SkeletonAnimationHandler.AddEventListener(Shoot);
                
                Component.SkeletonAnimationHandler.Play(0, 0, true);
            }

            public override void Update() { }

            public override void End()
            {
                Console.LogProgress();
                
                Component.SkeletonAnimationHandler.RemoveListener(AnimationEventType.Complete, Completed);
                Component.SkeletonAnimationHandler.RemoveEventListener(Shoot);
            }

            private void Completed(TrackEntry trackEntry)
            {
                Console.LogProgress();
                
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
                Console.LogProgress();
                
                if (Component.SkeletonAnimationHandler.GetEventData(0) != @event.Data)
                {
                    return;
                }
                
                Component._action.Prepare(0, 0, 0).Fire();
            }
        }
        
        private new class DieState : StateBase<ArcherCharacter>
        {
            public DieState(ArcherCharacter component) : base(component) { }

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
                        throw new System.ArgumentOutOfRangeException();
                }
            }

            public override void Update() { }

            public override void End()
            {
                Console.LogProgress();
                
                Component.SkeletonAnimationHandler.RemoveEventListener(FadeOut);
            }
            
            private void FadeOut(TrackEntry trackEntry, Spine.Event @event)
            {
                Console.LogProgress();
                
                if (Component.SkeletonAnimationHandler.GetEventData(1) != @event.Data)
                {
                    return;
                }
                
                Component.StartCoroutine(Component.FadeOut());
            }
        }
        
        private class MoveState : StateBase<ArcherCharacter>
        {
            public MoveState(ArcherCharacter component) : base(component) { }

            public override void Start()
            {
                Console.LogProgress();
                
                Component.MoveToDestination();
                
                Component.SkeletonAnimationHandler.Play(4, 0, true);
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
                Console.LogProgress();
                
                Component.SetRandomDestinationInRange(3);
            }
        }

        private class UseSkill : StateBase<ArcherCharacter>
        {
            private readonly Tile[] _tiles = new Tile[5];
            
            private bool _isShot;
            private Grenade _grenade;
            
            public UseSkill(ArcherCharacter component) : base(component) { }
            
            public override void Start()
            {
                Console.LogProgress();
                
                Component._coolDownTime = 0f;
                
                _tiles[0] = Component.TileMap.PlayerCharacter;
                _tiles[1] = Component.TileMap.GetTile(_tiles[0].ColumnNumber + 1, _tiles[0].RowNumber);
                _tiles[2] = Component.TileMap.GetTile(_tiles[0].ColumnNumber - 1, _tiles[0].RowNumber);
                _tiles[3] = Component.TileMap.GetTile(_tiles[0].ColumnNumber, _tiles[0].RowNumber + 1);
                _tiles[4] = Component.TileMap.GetTile(_tiles[0].ColumnNumber, _tiles[0].RowNumber - 1);

                var destination = _tiles[0].Position;
                _grenade = Component._action.Prepare(0, destination, 1, 0);
                _isShot = false;
                
                for (var i = 0; i < 5; i++)
                {
                    _tiles[i]?.StartWarningState(_grenade.InstanceID);
                }
                
                Component.SkeletonAnimationHandler.AddListener(AnimationEventType.Complete, Completed);
                Component.SkeletonAnimationHandler.AddEventListener(Shoot);
                
                Component.SkeletonAnimationHandler.Play(5);
            }

            public override void Update() { }

            public override void End()
            {
                Console.LogProgress();
                
                Component.SkeletonAnimationHandler.RemoveListener(AnimationEventType.Complete, Completed);
                Component.SkeletonAnimationHandler.RemoveEventListener(Shoot);
            }

            private void Completed(TrackEntry trackEntry)
            {
                Console.LogProgress();

                if (_isShot == false)
                {
                    for (var i = 0; i < 5; i++)
                    {
                        _tiles[i]?.StopWarningState(_grenade.InstanceID);
                    }
                    
                    ObjectPoolManager.Release(_grenade.gameObject);
                    _grenade = null;
                }
                
                Component.FiniteStateMachine.ChangeTo(Component.States[1]);
            }
            
            private void Shoot(TrackEntry trackEntry, Spine.Event @event)
            {
                Console.LogProgress();
                
                if (Component.SkeletonAnimationHandler.GetEventData(0) != @event.Data)
                {
                    return;
                }
                
                _isShot = true;
                _grenade.Launch(false);
            }
        }
        
        private new class WaitState : StateBase<ArcherCharacter>
        {
            public WaitState(ArcherCharacter component) : base(component) { }

            public override void Start()
            {
                Console.LogProgress();

                Component.SkeletonAnimationHandler.Play(6, 0, true);
            }

            public override void Update() { }

            public override void End()
            {
                Console.LogProgress();
            }
        }
    }
}
