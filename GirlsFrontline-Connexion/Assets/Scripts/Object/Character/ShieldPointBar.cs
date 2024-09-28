using System;
using System.Collections.Generic;
using System.Linq;
using GloryDay.Log;
using GloryDay.Utility;
using UnityEngine;

namespace Object.Character
{
    public class ShieldPointBar : MonoBehaviour
    {
        private readonly ShieldPoint[] _shieldPoints = new ShieldPoint[10];
        private readonly Stack<ShieldPoint> _stack = new Stack<ShieldPoint>();
        
        private GameObject _logoImageObject;

#if UNITY_EDITOR

        private readonly LabelBuilder _labelBuilder = new LabelBuilder();

#endif

        private void OnDisable()
        {
            LogManager.LogProgress();
            
            _stack.Clear();
        }

#if UNITY_EDITOR
        
        private void OnDrawGizmos()
        {
            if (Application.isPlaying == false || IsEnabled == false)
            {
                return;
            }

            var totalPoint = _stack.Sum(element => element.Value);

            var position = new Vector3(transform.position.x, transform.position.y - 1f, transform.position.z);
            
            _labelBuilder.SetStyle("blue", 16);
            _labelBuilder.Append("Shield Point", $"{totalPoint}");

            var text = _labelBuilder.ToString();
            var style = new GUIStyle { richText = true };
            UnityEditor.Handles.Label(position, text, style);
            
            _labelBuilder.Clear();
        }

#endif

        public void Initialize()
        {
            LogManager.LogProgress();
            
            var child = transform.GetChild(0);
            _logoImageObject = child.gameObject;
            
            child = transform.GetChild(1);
            for (var i = 0; i < 10; i++)
            {
                _shieldPoints[i] = child.GetChild(i).GetComponent<ShieldPoint>();
                _shieldPoints[i].Initialize();
            }
        }
        
        /// <summary>
        /// Initialize the shield points by a given number.
        /// </summary>
        /// <param name="point"> Number of shield point, default is 1200 number of shield point per one. </param>
        /// <param name="count"> Number of the shield point to produce. </param>
        public void SetPoints(float point, int count)
        {
            LogManager.LogProgress();
            
            if (count == 0)
            {
                _logoImageObject.SetActive(false);
                
                return;
            }
            
            _stack.Clear();
            for (var i = 0; i < count; i++)
            {
                _shieldPoints[i].SetPoint(point);
                _stack.Push(_shieldPoints[i]);
            }
            
            _logoImageObject.SetActive(true);
        }

        /// <summary>
        /// Calculate the damage point the character's shield received.
        /// </summary>
        /// <param name="point"> The damage point the character's shield received. </param>
        /// <returns> The remaining damage point. </returns>
        public float Calculate(float point)
        {
            var cache = _stack.Peek();
            while (true)
            {
                point = cache.Subtract(point);
                if (cache.IsEnabled)
                {
                    break;
                }
                
                _stack.Pop();
                if (IsEnabled == false)
                {
                    _logoImageObject.SetActive(false);
                    
                    break;
                }
                
                cache = _stack.Peek();
            }

            // Return remaining damage.
            return point;
        }

        /// <summary>
        /// True if shield point bar is enabled, otherwise false.
        /// </summary>
        public bool IsEnabled => _stack.Count != 0;
    }
}