using GloryDay.Debug.Log;
using GloryDay.SpineServices;
using Object.Map;
using Object.Weapon;
using Spine;
using UnityEngine;
using Utility.Manager;
using Utility.State;

namespace Object.Character.Enemy
{
    public partial class CyclopsCharacter
    {
        private class AttackState : StateBase<CyclopsCharacter>
        {
            private int _count;
            
            public AttackState(CyclopsCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();
                
                _count = Random.Range(1, 6);
                
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
                
                Component.ParticleSystemHandler.Emit(@event.Int);
                Component._action.Prepare(0, 0, 0).Fire(0);
            }
        }
        
        private new class DieState : StateBase<CyclopsCharacter>
        {
            public DieState(CyclopsCharacter component) : base(component) { }

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
        
        private class MoveState : StateBase<CyclopsCharacter>
        {
            public MoveState(CyclopsCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();

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
                LogManager.LogProgress();
                
                Component.SetRandomDestinationInRange(3);
            }
        }

        private class UseSkill : StateBase<CyclopsCharacter>
        {
            private readonly Tile[] _tiles = new Tile[9];
            
            private bool _isShot;
            private Grenade _grenade;
            
            public UseSkill(CyclopsCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();
                
                Component._coolDownTime = 0f;
                
                _tiles[0] = Component.TileMap.PlayerCharacter;
                _tiles[1] = Component.TileMap.GetTile(_tiles[0].ColumnNumber + 1, _tiles[0].RowNumber);
                _tiles[2] = Component.TileMap.GetTile(_tiles[0].ColumnNumber - 1, _tiles[0].RowNumber);
                _tiles[3] = Component.TileMap.GetTile(_tiles[0].ColumnNumber, _tiles[0].RowNumber + 1);
                _tiles[4] = Component.TileMap.GetTile(_tiles[0].ColumnNumber, _tiles[0].RowNumber - 1);
                _tiles[5] = Component.TileMap.GetTile(_tiles[0].ColumnNumber + 1, _tiles[0].RowNumber + 1);
                _tiles[6] = Component.TileMap.GetTile(_tiles[0].ColumnNumber + 1, _tiles[0].RowNumber - 1);
                _tiles[7] = Component.TileMap.GetTile(_tiles[0].ColumnNumber - 1, _tiles[0].RowNumber + 1);
                _tiles[8] = Component.TileMap.GetTile(_tiles[0].ColumnNumber - 1, _tiles[0].RowNumber - 1);
                
                var destination = _tiles[0].Position;
                _grenade = Component._action.Prepare(0, destination, 1, 0);
                _isShot = false;
                
                for (var i = 0; i < 9; i++)
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
                LogManager.LogProgress();
                
                Component.SkeletonAnimationHandler.RemoveListener(AnimationEventType.Complete, Completed);
                Component.SkeletonAnimationHandler.RemoveEventListener(Shoot);
            }

            private void Completed(TrackEntry trackEntry)
            {
                LogManager.LogProgress();

                if (_isShot == false)
                {
                    for (var i = 0; i < 9; i++)
                    {
                        _tiles[i]?.StopWarningState(_grenade.InstanceID);
                    }
                    
                    ObjectManager.OnRelease(_grenade.gameObject);
                    _grenade = null;
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
                
                Component.ParticleSystemHandler.Emit(4);
                
                _isShot = true;
                _grenade.Launch();
            }
        }
        
        private new class WaitState : StateBase<CyclopsCharacter>
        {
            public WaitState(CyclopsCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();
                
                Component.SkeletonAnimationHandler.Play(6, 0, true);
            }

            public override void Update() { }

            public override void End()
            {
                LogManager.LogProgress();
            }
        }
    }
}