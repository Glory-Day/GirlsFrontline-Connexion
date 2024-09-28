using System.Collections;
using System.Collections.Generic;
using GloryDay.Log;
using Object.Map;
using UnityEngine;
using Utility.Data;
using Utility.Manager;
using Utility.State;

namespace Object.Character
{
    public class EnemyCharacter : CharacterBase
    {
        #region CONSTANT FIELD API

        private const int WallForPlayerCharacterLayer = 16;
        private const int WallForEnemyCharacterLayer = 17;
        private const int EnemyCharacterColliderLayer = 20;

        #endregion

        #region COMPONENT FIELD API
        
        protected ItemSpawner ItemSpawner;
        
        #endregion
        
        protected IState DieState;
        protected IState WaitState;
        protected List<IState> States;
        protected FiniteStateMachine FiniteStateMachine;

        private int _destinationIndex;
        
        private PlayerCharacter _playerCharacterCache;
        
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();

            // Initialize item spawner.
            ItemSpawner = GetComponent<ItemSpawner>();
            
            // Initialize finite state machine and the list of states it needs.
            States = new List<IState>();
            FiniteStateMachine = new FiniteStateMachine();

            var key = DataManager.AudioData.Effect[20];
            HitSound = ResourceManager.AudioClipResource.Effect[key];
            
            var layer = gameObject.layer;
            Physics.IgnoreLayerCollision(layer, WallForPlayerCharacterLayer);
            Physics.IgnoreLayerCollision(layer, WallForEnemyCharacterLayer);
            Physics.IgnoreLayerCollision(layer, EnemyCharacterColliderLayer);
        }

        protected override void OnEnable()
        {
            LogManager.LogProgress();
            
            base.OnEnable();
            
            // Initialize cache of player character.
            _playerCharacterCache = FindObjectOfType<PlayerCharacter>();
            
            if (SpawnData is null || SpawnData.DestinationIndex.HasValue == false)
            {
                return;
            }
            
            _destinationIndex = SpawnData.DestinationIndex.Value;
            Destination = Extractor?.GetDestination(_destinationIndex);
        }

        protected virtual void Update()
        {
            // Update finite state machine.
            FiniteStateMachine.Update();
        }

        protected virtual void OnDisable()
        {
            LogManager.LogProgress();

            _playerCharacterCache = null;
            
            FiniteStateMachine.ShutDown();
        }

        protected override void OnDestroy()
        {
            LogManager.LogProgress();

            base.OnDestroy();
            
            ItemSpawner = null;
            
            _playerCharacterCache = null;
            
            DieState = null;
            WaitState = null;
            States = null;
            FiniteStateMachine = null;

            OnScoreChanged = null;
            OnRemoveRecord = null;
            OnReleaseCharacter = null;
        }

        /// <summary>
        /// Move to the left direction.
        /// </summary>
        protected void MoveToLeftDirection()
        {
            LogManager.LogProgress();
            
            Rigidbody.velocity = AdjustDirectionToSlope(Vector3.left) * SpeedPoint;
        }
        
        /// <summary>
        /// Move to the destination.
        /// </summary>
        protected void MoveToDestination()
        {
            LogManager.LogProgress();

            if (Destination.HasValue == false)
            {
                return;
            }
            
            // Calculate the total time it takes to move.
            var distance = Vector3.Distance(Rigidbody.position, Destination.Value);
            var time = distance / SpeedPoint;
            
            StartCoroutine(MovingToDestinationInTime(time));
        }

        protected override IEnumerator MovingToDestinationInTime(float time)
        {
            IsArrivedAtDestination = false;
            
            yield return StartCoroutine(base.MovingToDestinationInTime(time));

            IsArrivedAtDestination = true;
        }

        /// <summary>
        /// Stop an enemy character's movement.
        /// </summary>
        protected void StopMoving()
        {
            LogManager.LogProgress();
            
            Rigidbody.velocity = Vector3.zero;
        }

        /// <summary>
        /// Set a random destination within a given range.
        /// </summary>
        /// <param name="range"> Maximum range for setting a destination centered on a character. </param>
        protected void SetRandomDestinationInRange(int range)
        {
            LogManager.LogProgress();
            
            // Set destination.
            _destinationIndex = Extractor.GetRandomIndex(_destinationIndex, range);
            Destination = Extractor.GetDestination(_destinationIndex);
        }
        
        /// <returns>
        /// Position of the player character.
        /// </returns>
        protected Vector3 GetPlayerCharacterPosition()
        {
            return _playerCharacterCache.Position;
        }
        
        public override void TakeDamage(float damagePoint, float defensePenetratePoint, DamageType type)
        {
            LogManager.LogProgress();
            
            base.TakeDamage(damagePoint, defensePenetratePoint, type);
            
            if (IsAlive)
            {
                return;
            }
            
            StopAllCoroutines();
            
            FiniteStateMachine.ChangeTo(DieState);
        }

        public void SetWaitState()
        {
            LogManager.LogProgress();
            
            FiniteStateMachine.ChangeTo(WaitState);
        }

        public void SetLatestState()
        {
            LogManager.LogProgress();

            var state = FiniteStateMachine.Previous;
            FiniteStateMachine.ChangeTo(state);
        }

        /// <returns>
        /// True if it arrives and false if it doesn't arrive.
        /// </returns>
        protected bool IsArrivedAtDestination { get; private set; }
        
        public SpawnData SpawnData { get; set; }

        #region DELEGATE CALLBACK API

        public CharacterSpawner.RemoveRecordCallback OnRemoveRecord;

        #endregion
    }
}