using GloryDay.Log;
using GloryDay.Utility;
using Object.Character;
using Object.Weapon;
using UnityEngine;
using Utility;
using Utility.Manager;

namespace Object.Map
{
    public class Tile : MonoBehaviour
    {
        #region COMPONENT FIELD API

        private TileMap _map;
        
        private ParticleSystemHandler _particleSystemHandler;
        
        #endregion
        
        #region CONSTANT FIELD API

        private const string PlayerCharacterTag = "Player";
        private const string ExplosiveWeaponTag = "Explosive";

        #endregion

        private IDisplayable _warningState;
        private IDisplayable _criticalState;
        
        private PlayerCharacter _playerCharacterCache;
        
        private float _time;
        private float _deltaTime;
        private float _damage;

        private AudioClip _explosionSound;
        
#if UNITY_EDITOR

        private readonly LabelBuilder _labelBuilder = new LabelBuilder();

#endif
        
        private void Awake()
        {
            LogManager.LogProgress();
            
            _map = transform.parent.GetComponent<TileMap>();
            
            // Get child components.
            _warningState = new WarningState(transform.GetChild(0).GetComponent<SpriteRenderer>());
            _criticalState = new CriticalState(transform.GetChild(1).GetComponent<SpriteRenderer>());

            _particleSystemHandler = transform.GetChild(2).GetComponent<ParticleSystemHandler>();

            var key = DataManager.AudioData.Effect[12];
            _explosionSound = ResourceManager.AudioClipResource.Effect[key];
            
            _deltaTime = Time.deltaTime;
        }

        private void LateUpdate()
        {
            if (_playerCharacterCache is null)
            {
                return;
            }
            
            // Set the tile closest to the player character.
            var position = _playerCharacterCache.Position;
            var a = Vector3.Distance(position, _map.PlayerCharacter.Position);
            var b = Vector3.Distance(position, transform.position);
            
            if (a > b)
            {
                _map.PlayerCharacter = this;
            }
            
            _time += _deltaTime;
            if (_time <= 1.5f)
            {
                return;
            }
            
            _time %= 1.5f;
            
            if (_criticalState is null == false && _criticalState.IsDisplaying)
            {
                _playerCharacterCache?.TakeDamage(_damage, 1f, DamageType.Critical);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<PlayerCharacter>(out var character))
            {
                _playerCharacterCache = character;

                return;
            }

            if (other.TryGetComponent<Grenade>(out var grenade) == false)
            {
                return;
            }
            
            var instance = grenade.gameObject;
            var instanceID = grenade.InstanceID;
            StopWarningState(instanceID, grenade.DamagePoint, grenade.DefensePenetrationPoint);
            
            SoundManager.OnPlayEffectAudioSource(_explosionSound);
            
            ObjectManager.OnRelease(instance);
        }

        private void OnTriggerExit(Collider other)
        {
            var count = other.transform.childCount;
            if (count == 0)
            {
                return;
            }
            
            var child = other.transform.GetChild(0);
            if (child.CompareTag(PlayerCharacterTag) == false)
            {
                return;
            }

            _playerCharacterCache = null;
        }

#if UNITY_EDITOR

        public void OnDrawGizmos()
        {
            if (Application.isPlaying == false)
            {
                return;
            }
            
            var style = new GUIStyle { richText = true };
            
            _labelBuilder.SetStyle("lime", 8);
            _labelBuilder.Append("Position", $"[{RowNumber}, {ColumnNumber}]");
            _labelBuilder.Append("Index", $"{Index}");

            if (_playerCharacterCache is null == false)
            {
                var color = "blue";
                if (Index == _map.PlayerCharacter.Index)
                {
                    color = "red";
                    
                }
                
                _labelBuilder.SetStyle(color, 8);
                _labelBuilder.Append("Player Character");
            }
            
            var text = _labelBuilder.ToString();
            UnityEditor.Handles.Label(Position, text, style);
            
            _labelBuilder.Clear();
        }

#endif

        /// <summary>
        /// Start displaying the warning state.
        /// </summary>
        /// <param name="instanceID">  </param>
        public void StartWarningState(int instanceID)
        {
            _map.WarningStateTiles[instanceID].Enqueue(this);
            
            _warningState.StartDisplaying();
        }
        
        /// <summary>
        /// State displaying the critical state.
        /// </summary>
        /// <param name="instanceID">  </param>
        /// <param name="damage"> Character's damage value. </param>
        public void StartCriticalState(int instanceID, float damage)
        {
            _map.CriticalStateTiles[instanceID].Enqueue(this);
            _damage += damage;
            
            _criticalState.StartDisplaying();
        }

        private void StopWarningState(int instanceID, float damage, float percentage)
        {
            PlayerCharacter playerCharacter = null;
            while (_map.WarningStateTiles[instanceID].Count != 0)
            {
                var tile = _map.WarningStateTiles[instanceID].Dequeue();
                tile._warningState.StopDisplaying();
                tile._particleSystemHandler.Emit(0);
                
                if (tile._playerCharacterCache is null == false)
                {
                    playerCharacter = tile._playerCharacterCache;
                }
            }
            
            playerCharacter?.TakeDamage(damage, percentage, DamageType.Explosive);
        }

        /// <summary>
        /// Stop displaying the warning state.
        /// </summary>
        /// <param name="instanceID">  </param>
        public void StopWarningState(int instanceID)
        {
            while (_map.WarningStateTiles[instanceID].Count != 0)
            {
                var tile = _map.WarningStateTiles[instanceID].Dequeue();
                tile._warningState.StopDisplaying();
            }
        }

        /// <summary>
        /// Stop displaying the critical state.
        /// </summary>
        /// <param name="instanceID">  </param>
        /// <param name="damage"> Character's damage value. </param>
        public void StopCriticalState(int instanceID, float damage)
        {
            while (_map.CriticalStateTiles[instanceID].Count != 0)
            {
                var tile = _map.CriticalStateTiles[instanceID].Dequeue();
                tile._criticalState.StopDisplaying();
                tile._damage -= damage;
            }
        }
        
        /// <summary>
        /// Index number of the tile.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// The column number of the tile.
        /// </summary>
        public int ColumnNumber => Index % _map.ColumnLength;

        /// <summary>
        /// The row number of the tile.
        /// </summary>
        public int RowNumber => Index / _map.ColumnLength;

        public Vector3 Position => transform.position;
    }
}