using System;
using System.Collections.Generic;
using GloryDay.Log;
using GloryDay.SpineServices;
using Object.Map;
using Spine;
using UnityEngine;
using Utility.Manager;
using Event = Spine.Event;
using Utility.State;

namespace Object.Character.Enemy
{
    public partial class TyphonCharacter
    {
        private class AttackState : StateBase<TyphonCharacter>
        {
            private bool _isShot;
            
            public AttackState(TyphonCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();

                var instanceID = Component.InstanceID;
                Component.TileMap.WarningStateTiles.Add(instanceID, new Queue<Tile>());
                Component.TileMap.CriticalStateTiles.Add(instanceID, new Queue<Tile>());
                
                var length = Component._tiles.Length;
                for (var i = 0; i < length; i++)
                {
                    Component._tiles[i].StartWarningState(instanceID);
                }

                _isShot = false;
                
                Component.SkeletonAnimationHandler.AddListener(AnimationEventType.Complete, Completed);
                Component.SkeletonAnimationHandler.AddEventListener(Shoot);
                
                Component.SkeletonAnimationHandler.Play(0);
                
                SoundManager.OnPlayEffectAudioSource(Component._chargeLaserSound);
                
                Component.ParticleSystemHandler.Emit(1);
            }

            public override void Update() { }

            public override void End()
            {
                LogManager.LogProgress();
                
                var instanceID = Component.InstanceID;
                Component.TileMap.WarningStateTiles.Remove(instanceID);
                Component.TileMap.CriticalStateTiles.Remove(instanceID);
                
                Component.SkeletonAnimationHandler.RemoveListener(AnimationEventType.Complete, Completed);
                Component.SkeletonAnimationHandler.RemoveEventListener(Shoot);
            }

            private void Completed(TrackEntry trackEntry)
            {
                LogManager.LogProgress();
                
                var length = Component._tiles.Length;
                for (var i = 0; i < length; i++)
                {
                    var id = Component.InstanceID;
                    Component._tiles[i].StopWarningState(id);
                    Component._tiles[i].StopCriticalState(id, _isShot ? Component.DamagePoint : 0f);
                }
                
                Component.FiniteStateMachine.ChangeTo(Component.States[2]);
            }

            private void Shoot(TrackEntry trackEntry, Event @event)
            {
                LogManager.LogProgress();
                
                if (Component.SkeletonAnimationHandler.GetEventData(0) != @event.Data)
                {
                    return;
                }
                
                var length = Component._tiles.Length;
                for (var i = 0; i < length; i++)
                {
                    var id = Component.InstanceID;
                    Component._tiles[i].StopWarningState(id);
                    Component._tiles[i].StartCriticalState(id, Component.DamagePoint);
                }

                SoundManager.OnPlayEffectAudioSource(Component._launchLaserSound);
                
                Component.ParticleSystemHandler.Emit(2, 4);
                Component._laserRenderer.Draw();
                
                _isShot = true;
            }
        }
        
        private new class DieState : StateBase<TyphonCharacter>
        {
            public DieState(TyphonCharacter component) : base(component) { }

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
        
        private class MoveState : StateBase<TyphonCharacter>
        {
            public MoveState(TyphonCharacter component) : base(component) { }

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
                
                Component.FiniteStateMachine.ChangeTo(Component.States[2]);
            }

            public override void End()
            {
                LogManager.LogProgress();
            }
        }
        
        private class CoolDownState : StateBase<TyphonCharacter>
        {
            private float _coolDownTime;
            
            public CoolDownState(TyphonCharacter component) : base(component) { }

            public override void Start()
            {
                LogManager.LogProgress();

                _coolDownTime = 0f;
                
                Component.SkeletonAnimationHandler.Play(4, 0, true);
            }

            public override void Update()
            {
                _coolDownTime += Component.DeltaTime;
                if (_coolDownTime < MaximumCoolDownTime)
                {
                    return;
                }
                
                Component.FiniteStateMachine.ChangeTo(Component.States[0]);
            }

            public override void End()
            {
                LogManager.LogProgress();
                
                Component._tiles = Component.TileMap.GetRow(GetTileIndex());
            }
            
            private int GetTileIndex()
            {
                var position = Component.Rigidbody.position;
                var transform = Component.transform;
                var center = new Vector3(position.x, position.y - 2f, position.z);
                var extents = new Vector3(0f, 4f, 0f);
                var direction = -transform.right;
                var orientation = transform.rotation;
            
                Physics.BoxCast(center, extents, direction, out var hit, orientation, MaximumDistance, TileLayerMask);
                var component = hit.collider.GetComponent<Tile>();
                
                return component.Index;
            }
        }
        
        private new class WaitState : StateBase<TyphonCharacter>
        {
            public WaitState(TyphonCharacter component) : base(component) { }

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