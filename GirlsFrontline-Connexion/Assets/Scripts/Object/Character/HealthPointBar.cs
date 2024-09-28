using GloryDay.Log;
using GloryDay.Utility;
using UnityEngine;

namespace Object.Character
{
    public class HealthPointBar : MonoBehaviour
    {
        #region COMPONENT FIELD API

        private readonly DamageNumberRenderer[] _damageNumberRenderers = new DamageNumberRenderer[4];
        
        private ShieldPointBar _shieldPointBar;
        private SpriteRenderer _backgroundImageRenderer;

        #endregion
        
        private GameObject _healthPointBarObject;
        private GameObject _shieldPointBarObject;
        
        private float _healthPoint;
        private float _healthPointPercentage;
        
#if UNITY_EDITOR

        private readonly LabelBuilder _labelBuilder = new LabelBuilder();
        
        private void OnDrawGizmos()
        {
            if (Application.isPlaying == false || IsEnabled == false)
            {
                return;
            }

            var position = new Vector3(transform.position.x, transform.position.y + 3.5f, transform.position.z);
            
            _labelBuilder.SetStyle("red", 8);
            _labelBuilder.Append("Health Point", $"{_healthPoint}");

            var text = _labelBuilder.ToString();
            var style = new GUIStyle { richText = true };
            UnityEditor.Handles.Label(position, text, style);
            
            _labelBuilder.Clear();
        }

#endif
        
        public void Initialize()
        {
            LogManager.LogProgress();
            
            // Initialize box collider.
            Collider = transform.GetComponent<BoxCollider>();
            
            // Initialize damage number particle renderer components in child game objects.
            _damageNumberRenderers[0] = transform.GetChild(3).GetComponent<DamageNumberRenderer>();
            _damageNumberRenderers[1] = transform.GetChild(4).GetComponent<DamageNumberRenderer>();
            _damageNumberRenderers[2] = transform.GetChild(5).GetComponent<DamageNumberRenderer>();
            _damageNumberRenderers[3] = transform.GetChild(6).GetComponent<DamageNumberRenderer>();
            
            // Initialize child game objects.
            _healthPointBarObject = transform.GetChild(0).gameObject;
            _shieldPointBarObject = transform.GetChild(1).gameObject;
            
            // Initialize components in child game objects.
            _shieldPointBar = _shieldPointBarObject.GetComponent<ShieldPointBar>();
            _shieldPointBar.Initialize();
            
            _backgroundImageRenderer = transform.GetChild(2).GetComponent<SpriteRenderer>();
        }
        
        /// <summary>
        /// Set the points of the health point bar as points for the character.
        /// </summary>
        /// <param name="healthPoint"> Health point for character. </param>
        /// <param name="shieldPoint"> Shield point for character. </param>
        /// <param name="count"> The number of shield points </param>
        public void SetPoints(float healthPoint, float shieldPoint, int count)
        {
            LogManager.LogProgress();
            
            _healthPoint = healthPoint;
            _healthPointPercentage = 5.6f;
            _shieldPointBar.SetPoints(shieldPoint, count);
            
            var scale = _healthPointBarObject.transform.localScale;
            _healthPointBarObject.transform.localScale = new Vector3(_healthPointPercentage, scale.y, scale.z);
            
            BackgroundImageColor = new Color(1f, 1f, 1f, 1f);
            
            Collider.enabled = true;
            
            IsEnabled = true;
        }

        /// <summary>
        /// Set the size of the health point bar by the given number.
        /// </summary>
        /// <param name="point"></param>
        /// <param name="index"></param>
        public void Calculate(float point, int index)
        {
            LogManager.LogProgress();
            
            if (_shieldPointBar.IsEnabled)
            {
                // Render shield point number.
                _damageNumberRenderers[3].Render(((int)point).ToString());
                
                point = _shieldPointBar.Calculate(point);
                if (0f < point == false)
                {
                    return;
                }
            }
            
            // Render damage point number.
            _damageNumberRenderers[index].Render(((int)point).ToString());
            
            var delta = _healthPointPercentage * (point / _healthPoint);
            var scale = _healthPointBarObject.transform.localScale;
            
            delta = scale.x - delta;
            if (delta <= 0f)
            {
                delta = 0f;
                
                Collider.enabled = false;
                
                IsEnabled = false;
            }
            
            // Change size of the health point bar.
            _healthPointBarObject.transform.localScale = new Vector3(delta, scale.y, scale.z);
        }
        
        /// <summary>
        /// 
        /// </summary>
        public Color BackgroundImageColor { set => _backgroundImageRenderer.color = value; }
        
        public BoxCollider Collider { get; private set; }

        /// <summary>
        /// True if health point bar is enabled, otherwise false.
        /// </summary>
        public bool IsEnabled { get; private set; }

        /// <summary>
        /// True if shield point bar is enabled, otherwise false.
        /// </summary>
        public bool IsShieldEnabled => _shieldPointBar.IsEnabled;
    }
}