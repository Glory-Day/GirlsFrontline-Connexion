using System;
using System.Collections;
using GloryDay.Log;
using UnityEngine;

namespace Object.Character
{
    public class LaserRenderer : MonoBehaviour
    {
        #region SERIALIZABLE FIELD API

        [SerializeField] private float maximumDistance;

        #endregion

        #region COMPONENT FIELD API

        private LineRenderer _renderer;

        #endregion
        
        private void Awake()
        {
            LogManager.LogProgress();
            
            _renderer = GetComponent<LineRenderer>();
        }

        public void Draw()
        {
            LogManager.LogProgress();

            StartCoroutine(Drawing());
        }

        private IEnumerator Drawing()
        {
            var start = Vector3.zero;
            var end = Vector3.right * maximumDistance;
            _renderer.SetPosition(0, start);
            _renderer.SetPosition(1, end);

            yield return new WaitForSeconds(1f);
            
            for (var i = 0f; i < 0.335f; i += Time.deltaTime)
            {
                var percentage = i / 0.335f;
                var width = Mathf.Lerp(10f, 0f, percentage);
                _renderer.startWidth = width;
                _renderer.endWidth = width;
                
                yield return null;
            }
            
            _renderer.SetPosition(0, start);
            _renderer.SetPosition(1, start);
            _renderer.startWidth = 10f;
            _renderer.endWidth = 10f;
        }
    }
}