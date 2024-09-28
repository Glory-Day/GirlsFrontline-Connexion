using System;
using System.Collections;
using GloryDay.Log;
using GloryDay.Math;
using GloryDay.Utility;
using Object.Character;
using UnityEngine;
using Utility.Manager;

namespace Object.Item
{
    [RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
    public class ItemBase : MonoBehaviour
    {
        private IEnumerator _routine;

        private readonly Vector3[] _points = new Vector3[4];
        private Vector3 _destination;
        
        private readonly WaitForSeconds _delay = new WaitForSeconds(3f);
        
        private PlayerCharacter _playerCharacterCache;
        
        private AudioClip _gainItemSound;
        
#if UNITY_EDITOR
        
        private readonly LabelBuilder _labelBuilder = new LabelBuilder();
        
#endif

        private void Awake()
        {
            LogManager.LogProgress();

            var key = DataManager.AudioData.Effect[17];
            _gainItemSound = ResourceManager.AudioClipResource.Effect[key];
        }
        
        private void OnEnable()
        {
            LogManager.LogProgress();
            
            _playerCharacterCache = FindObjectOfType<PlayerCharacter>();
        }

        private void OnDisable()
        {
            LogManager.LogProgress();
            
            _playerCharacterCache = null;
        }

        private void OnDestroy()
        {
            LogManager.LogProgress();
            
            _playerCharacterCache = null;
        }

        protected void OnTriggerEnter(Collider other)
        {
            LogManager.LogProgress();

            if (other.TryGetComponent<PlayerCharacter>(out var character) == false)
            {
                return;
            }
            
            SoundManager.OnPlayEffectAudioSource(_gainItemSound);
            
            character.ApplyItem(this);
            
            StopCoroutine(_routine);
            _routine = null;
            
            ObjectManager.OnRelease(gameObject);
        }

#if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            var style = new GUIStyle { richText = true };
            
            _labelBuilder.SetStyle("magenta", 8);
            _labelBuilder.Append("Point 01");
            var label = _labelBuilder.ToString();
            UnityEditor.Handles.Label(_points[0], label, style);
            _labelBuilder.Clear();
            
            _labelBuilder.Append("Point 02");
            label = _labelBuilder.ToString();
            UnityEditor.Handles.Label(_points[1], label, style);
            _labelBuilder.Clear();
            
            _labelBuilder.Append("Point 03");
            label = _labelBuilder.ToString();
            UnityEditor.Handles.Label(_points[2], label, style);
            _labelBuilder.Clear();
            
            _labelBuilder.Append("Point 04");
            label = _labelBuilder.ToString();
            UnityEditor.Handles.Label(_points[3], label, style);
            _labelBuilder.Clear();
            
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(_points[0], _points[1]);
            Gizmos.DrawLine(_points[2], _points[3]);
            
            Gizmos.color = Color.red;
            for (var i = 0f; i < 100f; i++)
            {
                var time = i / 100f;
                var before = BezierCurve.GetPosition(time, _points);

                time = (i + 1f) / 100f;
                var after = BezierCurve.GetPosition(time, _points);
                
                Gizmos.DrawLine(before, after);
            }
        }

#endif

        public void Drop(Vector3 destination)
        {
            LogManager.LogProgress();
            
            try
            {
                _destination = destination;

                _routine = Dropping();
                StartCoroutine(_routine);
            }
            catch (Exception exception)
            {
                LogManager.LogError(exception.Message);
            }
        }

        private IEnumerator Dropping()
        {
            var position = transform.position;
            
            // Calculate and set the points.
            var delta = (position.x - _destination.x) / 4f;
            _points[0] = position;
            _points[1] = new Vector3(position.x - delta, position.y + 6f, position.z);
            _points[2] = new Vector3(_destination.x + delta, _destination.y + 6f, _destination.z);
            _points[3] = _destination;
            
            // Move along the path of the Bézier curve.
            var deltaTime = Time.deltaTime;
            for (var time = 0f; time <= 1f; time += deltaTime)
            {
                transform.position = BezierCurve.GetPosition(time, _points);

                yield return null;
            }

            yield return _delay;

            yield return StartCoroutine(MovingToPlayerCharacter());
        }

        private IEnumerator MovingToPlayerCharacter()
        {
            while (_playerCharacterCache.IsAlive)
            {
                var position = transform.position;
                var destination = _playerCharacterCache.Position;
                transform.position = Vector3.MoveTowards(position, destination, 10f);

                yield return null;
            }
        }
    }
}