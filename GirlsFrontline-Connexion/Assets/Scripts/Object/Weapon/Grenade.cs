using System.Collections;
using System.Collections.Generic;
using GloryDay.Debug.Log;
using GloryDay.Math;
using GloryDay.Debug;
using Object.Map;
using UnityEngine;
using Utility.Manager;

namespace Object.Weapon
{
    public class Grenade : ProjectileBase
    {
        private TileMap _tileMap;
        
        private readonly Vector3[] _points = new Vector3[4];
        private float _factor;

        private AudioClip _launchGrenadeSound;
        
        private readonly WaitUntil _instruction = new WaitUntil(() => GameManager.IsApplicationPaused == false);
        
#if UNITY_EDITOR

        private readonly LabelBuilder _labelBuilder = new LabelBuilder();
        
#endif
        
        private void Awake()
        {
            LogManager.LogProgress();
            
            InstanceID = GetInstanceID();
            
            _tileMap = FindObjectOfType<TileMap>();
            _tileMap.WarningStateTiles.Add(InstanceID, new Queue<Tile>());

            var key = DataManager.AudioData.Effect[11];
            _launchGrenadeSound = ResourceManager.AudioClipResource.Effect[key];
            
            DefensePenetrationPoint = 1f;
        }

        private void OnDestroy()
        {
            LogManager.LogProgress();

            _tileMap.WarningStateTiles.Remove(InstanceID);
            _tileMap = null;
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

        public void Launch(bool hasSound = true)
        {
            LogManager.LogProgress();

            if (hasSound)
            {
                SoundManager.OnPlayEffectAudioSource(_launchGrenadeSound);
            }
            
            gameObject.SetActive(true);
            
            StartCoroutine(Moving());
        }

        private IEnumerator Moving()
        {
            var distance = Vector3.Distance(transform.position, _points[3]);
            var totalTime = distance / SpeedPoint;
            var fixedDeltaTime = Time.fixedDeltaTime;
            for (var deltaTime = 0f; deltaTime <= totalTime; deltaTime += fixedDeltaTime)
            {
                var time = deltaTime / totalTime;
                
                var position = transform.position;
                var movedPosition = BezierCurve.GetPosition(time, _points);
                var direction = movedPosition - position;

                transform.position = movedPosition;
                transform.rotation = Rotate(direction);

                yield return _instruction;
            }
        }
        
        /// <summary>
        /// Set the destination point and height of the bézier curve.
        /// </summary>
        /// <param name="destination"> The point of destination. </param>
        public void SetBezierCurvePoints(Vector3 destination)
        {
            // Set the height of the parabola.
            var position = transform.position;
            var distance = Vector3.Distance(position, destination);
            var height = distance / _factor;
            
            _points[0] = _points[1] = position;
            _points[2] = _points[3] = destination;
            
            // Set bézier curve point positions.
            var delta = (_points[2].x - _points[1].x) / 4;
            _points[1].x += delta;
            _points[2].x -= delta;
            
            delta = _points[1].y - _points[2].y;
            _points[1].y += height;
            _points[2].y += height + delta;
        }
        
        public void SetData(float damagePoint, float defensePenetrationPoint, float speedPoint, float height)
        {
            base.SetData(damagePoint, defensePenetrationPoint, speedPoint);

            _factor = height;
        }
        
        public int InstanceID { get; private set; }
    }
}