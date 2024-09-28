using GloryDay.Log;
using Object.Map;
using UnityEngine;
using Utility.Manager;

namespace Object.Character.Enemy
{
    public partial class TyphonCharacter : EnemyCharacter
    {
        #region COMPONENT FIELD API

        private LaserRenderer _laserRenderer;

        #endregion
        
        #region CONSTANT FIELD API
        
        private const int TileLayerMask = 1 << 13;
        
        private const float MaximumCoolDownTime = 30f;
        private const float MaximumDistance = 100f;

        #endregion
        
        private Tile[] _tiles;
        
        private AudioClip _chargeLaserSound;
        private AudioClip _launchLaserSound;
        
        protected override void Awake()
        {
            LogManager.LogProgress();
            
            base.Awake();
            
            // Initialize laser renderer
            _laserRenderer = GetComponentInChildren<LaserRenderer>();
            
            // Set character states in state machine.
            States.Add(new AttackState(this));
            States.Add(new MoveState(this));
            States.Add(new CoolDownState(this));
            
            base.DieState = new DieState(this);
            base.WaitState = new WaitState(this);

            var key = DataManager.AudioData.Effect[13];
            _chargeLaserSound = ResourceManager.AudioClipResource.Effect[key];
            
            key = DataManager.AudioData.Effect[14];
            _launchLaserSound = ResourceManager.AudioClipResource.Effect[key];
        }
        
        protected override void OnEnable()
        {
            LogManager.LogProgress();
            
            base.OnEnable();
            
            FiniteStateMachine.Run(States[1]);
        }

#if UNITY_EDITOR

        protected override void OnDrawGizmos()
        {
            if (Application.isPlaying == false)
            {
                return;
            }
            
            base.OnDrawGizmos();

            var position = Rigidbody.position;
            var center = new Vector3(position.x, position.y - 2f, position.z);
            var extents = new Vector3(0f, 4f, 0f);
            var direction = -transform.right;
            var orientation = transform.rotation;

            Gizmos.color = Color.magenta;
            
            if (Physics.BoxCast(center, extents, direction, out var hit, orientation, MaximumDistance, TileLayerMask))
            {
                Gizmos.DrawRay(position, direction * hit.distance);
                Gizmos.DrawWireCube(position + direction * hit.distance, extents);
            }
            else
            {
                Gizmos.DrawRay(position, direction * hit.distance);
            }
        }

#endif
    }
}