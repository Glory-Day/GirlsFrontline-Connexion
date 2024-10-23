using System;
using System.Collections;
using System.Collections.Generic;
using GloryDay.Debug.Log;
using UnityEngine;

namespace Object.Character
{
    [RequireComponent(typeof(ParticleSystem))]
    public class BitmapTextParticleSystem : MonoBehaviour
    {
        #region SERIALIZABLE CLASS API

        [Serializable]
        public class BitmapFontInformation
        {
            [Header("Font Texture")]
            public Texture texture;

            [Header("Bitmap Tile Information")] 
            public int columnCount;
            public int rowCount;

            [Header("Available Character List")] 
            public char[] characters;

            public void Initialize()
            {
                var length = characters.Length;
                for (var i = 0; i < length; i++)
                {
                    var key = char.ToLowerInvariant(characters[i]);
                    if (Coordinates.ContainsKey(key))
                    {
                        continue;
                    }
                    
                    var x = i % columnCount;
                    var y = rowCount - 1 - i / rowCount;
                    Coordinates.Add(key, new Vector2(x, y));
                }
            }

            public Vector2 GetTextureCoordinates(char character)
            {
                var key = char.ToLowerInvariant(character);
                
                return Coordinates.TryGetValue(key, out var coordinates) ? coordinates : Vector2.zero;
            }

            public Dictionary<char, Vector2> Coordinates { get; } = new Dictionary<char, Vector2>();
        }

        #endregion

        #region SERIALIZABLE FIELD API
        
        public BitmapFontInformation bitmapFontInformation;

        #endregion
        
        #region COMPONENT FIELD API

        private ParticleSystem _particleSystem;
        private ParticleSystemRenderer _particleSystemRenderer;

        #endregion
        
        #region CONSTANT FIELD API

        private const int MaximumMessageLength = 24;

        #endregion
        
        private void Awake()
        {
            LogManager.LogProgress();

            _particleSystem = GetComponent<ParticleSystem>();
            _particleSystemRenderer = _particleSystem.GetComponent<ParticleSystemRenderer>();
            
            var streams = new List<ParticleSystemVertexStream>();
            _particleSystemRenderer.GetActiveVertexStreams(streams);
            if (streams.Contains(ParticleSystemVertexStream.UV2) == false)
            {
                streams.Add(ParticleSystemVertexStream.UV2);
            }
            if (streams.Contains(ParticleSystemVertexStream.Custom1XYZW) == false)
            {
                streams.Add(ParticleSystemVertexStream.Custom1XYZW);
            }
            if (streams.Contains(ParticleSystemVertexStream.Custom2XYZW) == false)
            {
                streams.Add(ParticleSystemVertexStream.Custom2XYZW);
            }
            _particleSystemRenderer.SetActiveVertexStreams(streams);
            
            bitmapFontInformation.Initialize();
        }

        protected void Spawn(string message, float? startSize = null)
        {
            try
            {
                if (message.Length > MaximumMessageLength)
                {
                    throw new IndexOutOfRangeException("");
                }

                var coordinates = new Vector2[MaximumMessageLength];
                coordinates[coordinates.Length - 1] = new Vector2(0f, message.Length);
                for (var i = 0; i < MaximumMessageLength - 1; i++)
                {
                    if (i >= message.Length)
                    {
                        break;
                    }

                    coordinates[i] = bitmapFontInformation.GetTextureCoordinates(message[i]);
                }

                var customData01 = CreateCustomData(coordinates);
                var customData02 = CreateCustomData(coordinates, 12);
                
                var emitParams = new ParticleSystem.EmitParams
                                 {
                                     startSize3D = new Vector3(message.Length, 1f, 1f)
                                 };

                if (startSize.HasValue)
                {
                    emitParams.startSize3D *= startSize.Value * _particleSystem.main.startSizeMultiplier;
                }
                
                _particleSystem.Emit(emitParams, 1);
                
                var customData = new List<Vector4>();
                _particleSystem.GetCustomParticleData(customData, ParticleSystemCustomData.Custom1);
                if (customData.Count != 0)
                {
                    customData[customData.Count - 1] = customData01;
                }
                _particleSystem.SetCustomParticleData(customData, ParticleSystemCustomData.Custom1);
                
                _particleSystem.GetCustomParticleData(customData, ParticleSystemCustomData.Custom2);
                if (customData.Count != 0)
                {
                    customData[customData.Count - 1] = customData02;
                }
                _particleSystem.SetCustomParticleData(customData, ParticleSystemCustomData.Custom2);
            }
            catch (IndexOutOfRangeException exception)
            {
                LogManager.LogError(exception.Message);
            }
        }

        private Vector4 CreateCustomData(Vector2[] coordinates, int offset = 0)
        {
            var data = Vector4.zero;
            for (var i = 0; i < 4; i++)
            {
                var uvs = new Vector2[3];
                for (var j = 0; j < 3; j++)
                {
                    var index = i * 3 + j + offset;
                    if (index < coordinates.Length)
                    {
                        uvs[j] = coordinates[index];
                    }
                    else
                    {
                        data[i] = ToFloat(uvs);
                        i = 5;

                        break;
                    }
                }

                if (i < 4)
                {
                    data[i] = ToFloat(uvs);
                }
            }

            return data;
        }

        private float ToFloat(Vector2[] uvs)
        {
            if (uvs is null || uvs.Length == 0)
            {
                return 0f;
            }
            
            var result = uvs[0].y * 10000f + uvs[0].x * 100000f;
            if (uvs.Length > 1)
            {
                result += uvs[1].y * 100f + uvs[1].x * 1000f;
            }
            if (uvs.Length > 2)
            {
                result += uvs[2].y + uvs[2].x * 10f;
            }
            
            return result;
        }

#if UNITY_EDITOR
        
        #region COMPONENT TEST API

        private IEnumerator _coroutine;
        
        [ContextMenu("Start component test")]
        public void StartTest()
        {
            Awake();
            
            _coroutine = Testing();
            StartCoroutine(_coroutine);
        }
        
        [ContextMenu("Stop component test")]
        public void StopTest()
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        private IEnumerator Testing()
        {
            for (var i = 0; i < 1000000; i++)
            {
                Spawn($"{i}");

                yield return new WaitForSeconds(0.2f);
            }
        }

        #endregion
        
#endif
    }
}