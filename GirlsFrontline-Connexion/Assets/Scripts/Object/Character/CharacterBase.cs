using System.Collections;
using GloryDay.Log;
using GloryDay.SpineServices;
using GloryDay.Utility;
using Object.Map;
using UnityEngine;
using Utility;
using Utility.Data;
using Utility.Extension;
using Utility.Manager;
using Random = UnityEngine.Random;

namespace Object.Character
{
    [RequireComponent(typeof(SkeletonAnimationHandler))]
    public abstract class CharacterBase : MonoBehaviour, IHorizontalComparable
    {
        #region SERIALIZABLE FIELD API

        [SerializeField]
        protected CharacterData characterData;

        #endregion
        
        #region COMPONENT FIELD API

        protected Rigidbody Rigidbody;
        
        protected HealthPointBar HealthPointBar;
        protected ParticleSystemHandler ParticleSystemHandler;
        
        protected SkeletonAnimationHandler SkeletonAnimationHandler;
        
        #endregion

        #region CONSTANT FIELD API

        private const int GroundLayerMask = 1 << 14;
        
        private const float MaximumRayDistance = 8f;

        #endregion
        
        // For checking if the ground is slope or flat.
        private bool _isGround;
        private RaycastHit _groundHit;
        
        // Character default stat points.
        protected float HealthPoint;
        protected float DamagePoint;
        protected float DefensePenetrationPoint;
        protected float DefensePoint;
        protected float SpeedPoint;
        
        protected PlaneMeshVertexExtractor Extractor;
        protected TileMap TileMap;
        
        protected Vector3? Destination;
        
        protected AudioClip HitSound;
        
        protected float DeltaTime;
        protected float FixedDeltaTime;

        private readonly WaitUntil _instruction = new WaitUntil(() => GameManager.IsApplicationPaused == false);

#if UNITY_EDITOR

        protected readonly LabelBuilder LabelBuilder = new LabelBuilder();
        
#endif
        
        protected virtual void Awake()
        {
            LogManager.LogProgress();
            
            // Set default stat points of character.
            HealthPoint = characterData.HealthPoint;
            DamagePoint = characterData.DamagePoint;
            DefensePenetrationPoint = characterData.DefensePenetrationPoint;
            DefensePoint = characterData.DefensePoint;
            SpeedPoint = characterData.SpeedPoint;
            
            Rigidbody = GetComponent<Rigidbody>();
            
            // Initialize health point bar component.
            var child = transform.GetChild(0);
            HealthPointBar = child.GetComponent<HealthPointBar>();
            HealthPointBar.Initialize();
            
            // Initialize particle system handler.
            child = transform.GetChild(1);
            ParticleSystemHandler = child.GetComponent<ParticleSystemHandler>();
            
            // Initialize skeleton animation handler component.
            SkeletonAnimationHandler = GetComponent<SkeletonAnimationHandler>();
            SkeletonAnimationHandler.Initialize();

            var sibling = transform.GetSibling(5);
            child = sibling.GetChild(0);
            Extractor = sibling.GetComponent<PlaneMeshVertexExtractor>();
            TileMap = child.GetComponent<TileMap>();
            
            DeltaTime = Time.deltaTime;
            FixedDeltaTime = Time.fixedDeltaTime;
            
            InstanceID = GetInstanceID();
            InstanceName = characterData.CharacterName;
        }

        protected virtual void OnEnable()
        {
            LogManager.LogProgress();
            
            // Set health point and shield point in the health point bar.
            var shieldPoint = characterData.ShieldPoint;
            var count = characterData.ShieldPointCount;
            HealthPointBar.SetPoints(HealthPoint, shieldPoint, count);
            
            // Reset alpha value of skeleton in skeleton animation handler.
            SkeletonAnimationHandler.ResetSkeletonAlpha();
        }

        protected virtual void OnDestroy()
        {
            LogManager.LogProgress();
            
            SkeletonAnimationHandler.RemoveAllEventListener();
            SkeletonAnimationHandler = null;
            
            Rigidbody = null;
            
            HealthPointBar = null;
            
            Extractor = null;
            TileMap = null;
        }

#if UNITY_EDITOR

        protected virtual void OnDrawGizmos()
        {
            if (Application.isPlaying == false)
            {
                return;
            }
            
            // Draw a label to display the character's position.
            LabelBuilder.Append("Position");
            var position = Rigidbody.position;
            var text = LabelBuilder.ToString();
            var style = new GUIStyle { richText = true };
            UnityEditor.Handles.Label(position, text, style);
            LabelBuilder.Clear();
            
            // Draw a cube that display the range to check if the character is standing on the ground.
            var center = new Vector3(position.x, position.y - 2f, position.z);
            var size = new Vector3(HealthPointBar.Collider.size.x, 4f, HealthPointBar.Collider.size.z);
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireCube(center, size);

            position = new Vector3(position.x, position.y + 4f, position.z);
            Gizmos.DrawRay(position, Vector3.down * MaximumRayDistance);

            if (Destination is null)
            {
                return;
            }
            
            // Draw a line to display the difference between the character's position and destination.
            var destination = Destination.Value;
            position = Rigidbody.position;
            Gizmos.color = Color.red;
            Gizmos.DrawLine(position, destination);
            
            // Draw a label to display the destination.
            LabelBuilder.SetStyle("red", 8);
            LabelBuilder.Append("Destination");
            text = LabelBuilder.ToString();
            destination = new Vector3(destination.x, destination.y + 3f, destination.z);
            UnityEditor.Handles.Label(destination, text, style);
            LabelBuilder.Clear();
        }

#endif
        
        /// <summary>
        /// Fade out images of the character and disables the components that the character has.
        /// </summary>
        protected IEnumerator FadeOut()
        {
            // Fade out the background image of the health bar and the spine skeleton image.
            for (var i = 5f; i >= 0f; i -= DeltaTime)
            {
                var alpha = i / 5f;
                HealthPointBar.BackgroundImageColor = new Color(1f, 1f, 1f, alpha);
                SkeletonAnimationHandler.Skeleton.A = alpha;
                
                yield return null;
            }
            
            SkeletonAnimationHandler.ResetPose();

            // Wait for the pose to reset.
            for (var i = 0f; i < 1f; i += DeltaTime)
            {
                yield return null;
            }
            
            OnReleaseCharacter(this);
        }
        
        /// <summary>
        /// Move to the destination in a given amount of time.
        /// </summary>
        /// <param name="time"> The value of the time it takes to get the destination. </param>
        protected void MoveToDestinationInTime(float time)
        {
            StartCoroutine(MovingToDestinationInTime(time));
        }
        
        protected virtual IEnumerator MovingToDestinationInTime(float time)
        {
            if (Destination.HasValue == false)
            {
                yield break;
            }
            
            var position = Rigidbody.position;
            for (var deltaTime = 0f; deltaTime <= time; deltaTime += FixedDeltaTime)
            {
                var delta = deltaTime / time;
                Rigidbody.MovePosition(Vector3.Lerp(position, Destination.Value, delta));

                yield return _instruction;
            }
        }
        
        /// <summary>
        /// It is calculated by applying the variable for the slope to the direction vector being moved.
        /// </summary>
        /// <param name="direction"> Direction vector to calculate. </param>
        /// <returns> Direction vector with slope variable applied. </returns>
        protected Vector3 AdjustDirectionToSlope(Vector3 direction)
        {
            if (IsGrounded() && IsSlope())
            {
                direction = Vector3.ProjectOnPlane(direction, _groundHit.normal).normalized;
                
                Rigidbody.useGravity = false;
            }
            else
            {
                Rigidbody.useGravity = true;
            }

            return direction;
        }
        
        /// <returns>
        /// True if the character is standing on the ground, otherwise false.
        /// </returns>
        private bool IsGrounded()
        {
            var position = Rigidbody.position;
            var center = new Vector3(position.x, position.y - 2f, position.z);
            var size = new Vector3(HealthPointBar.Collider.size.x, 4f, HealthPointBar.Collider.size.z);

            var check = Physics.CheckBox(center, size, Quaternion.identity, GroundLayerMask);
            return check;
        }
        
        /// <returns>
        /// True if the ground is slope, otherwise false.
        /// </returns>
        private bool IsSlope()
        {
            var position = transform.position;
            var origin = new Vector3(position.x, position.y + 4f, position.z);
            var direction = Vector3.down;
            if (Physics.Raycast(origin, direction, out _groundHit, MaximumRayDistance, GroundLayerMask))
            {
                return _groundHit.normal != Vector3.up;
            }

            return false;
        }

        /// <summary>
        /// Take damage point to the character calculated as a percentage of defense penetration.
        /// </summary>
        /// <param name="damagePoint"> The point of damage to the character. </param>
        /// <param name="defensePenetratePoint">
        /// The percentage of defensive penetration in damage to the character. A value between 0 and 1.
        /// </param>
        /// <param name="type"> The type of damage to the character.  </param>
        public virtual void TakeDamage(float damagePoint, float defensePenetratePoint, DamageType type)
        {
            LogManager.LogProgress();

            if (HealthPointBar.IsEnabled == false)
            {
                return;
            }
            
            SoundManager.OnPlayEffectAudioSource(HitSound);
            
            // Generate random number factor.
            damagePoint *= Random.Range(85f, 115f) / 100f;

            var index = 1;
            if (0f >= DefensePoint)
            {
                HealthPointBar.Calculate(damagePoint, index);

                return;
            }
            
            var defensePoint = DefensePoint - DefensePoint * defensePenetratePoint;
            damagePoint = damagePoint < defensePoint ? 1f : damagePoint - defensePoint;
            
            index = 0 < defensePoint ? 0 : 2;
            HealthPointBar.Calculate(damagePoint, index);

            // Set the way the character received the damage.
            DeadCause = type;
        }

        public void EmitHitEffect()
        {
            LogManager.LogProgress();
            
            ParticleSystemHandler.Emit(0);
        }

        #region DELEGATE CALLBACK API
        
        public ValueChangedCallback<int> OnScoreChanged;

        public CharacterSpawner.ReleaseCharacterCallback OnReleaseCharacter;

        #endregion
        
        public Vector3 Position => Rigidbody.position;
        
        public float HorizontalPosition => Rigidbody.position.x;
        
        public bool IsAlive => HealthPointBar.IsEnabled;
        
        protected DamageType DeadCause { get; private set; }
        
        public int InstanceID { get; private set; }
        
        public string InstanceName { get; private set; }
    }
}