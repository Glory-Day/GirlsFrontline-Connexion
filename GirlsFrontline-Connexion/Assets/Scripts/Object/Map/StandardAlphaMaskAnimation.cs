using System.Collections;
using GloryDay.Debug.Log;
using UnityEngine;

namespace Object.Map
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class StandardAlphaMaskAnimation : MonoBehaviour, IUVAnimation
    {
        #region SERIALIZABLE FIELD API
        
        [Header("UV Speed Properties")]
        [SerializeField] [Range(0, 1)] private float horizontalSpeed;
        [SerializeField] [Range(0, 1)] private float verticalSpeed;

        #endregion

        #region CONSTANT FIELD API

        private const string MainTexturePropertyName = "_MainTex";
        private const string MaskTexturePropertyName = "_MaskTex";

        #endregion
        
        #region COMPONENT FIELD API

        private Material _material;

        #endregion

        private IEnumerator _routine;
        
        private static readonly int MainTexturePropertyID = Shader.PropertyToID(MainTexturePropertyName);
        private static readonly int MaskTexturePropertyID = Shader.PropertyToID(MaskTexturePropertyName);

        private void Awake()
        {
            LogManager.LogProgress();

            var meshRenderer = GetComponent<MeshRenderer>();
            _material = meshRenderer.sharedMaterials[0];
        }

        public void Play()
        {
            LogManager.LogProgress();

            _routine = Moving();
            StartCoroutine(_routine);
        }
        
        public void Pause()
        {
            LogManager.LogProgress();
            
            StopCoroutine(_routine);
            _routine = null;
        }

        public void Stop()
        {
            LogManager.LogProgress();
            
            StopCoroutine(_routine);
            _routine = null;

            var position = new Vector2(0f, 0f);
            _material.SetTextureOffset(MainTexturePropertyID, position);
            _material.SetTextureOffset(MaskTexturePropertyID, position);
        }

        private IEnumerator Moving()
        {
            var fixedDeltaTime = Time.fixedDeltaTime;
            while (true)
            {
                var position = _material.GetTextureOffset(MainTexturePropertyID);
                position.x += horizontalSpeed * fixedDeltaTime;
                position.y += verticalSpeed * fixedDeltaTime;
                position.x %= 1f;
                position.y %= 1f;
                
                _material.SetTextureOffset(MainTexturePropertyID, position);
                _material.SetTextureOffset(MaskTexturePropertyID, position);
                
                yield return null;
            }
        }

#if UNITY_EDITOR

        [ContextMenu("Play Animation")]
        private void PlayAnimationForTesting()
        {
            LogManager.LogProgress();
            
            Awake();
            Play();
        }

        [ContextMenu("Pause Animation")]
        private void PauseAnimationForTesting()
        {
            LogManager.LogProgress();
            
            Pause();
        }

        [ContextMenu("Stop Animation")]
        private void StopAnimationForTesting()
        {
            LogManager.LogProgress();
            
            Stop();
        }
        
#endif
    }
}