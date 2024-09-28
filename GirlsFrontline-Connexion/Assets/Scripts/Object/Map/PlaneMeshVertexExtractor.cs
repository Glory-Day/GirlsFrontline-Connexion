using System.Collections.Generic;
using GloryDay.Log;
using GloryDay.Utility;
using UnityEngine;

namespace Object.Map
{
    public class PlaneMeshVertexExtractor : MonoBehaviour
    {
        private Vector3[] _vertices;
        
        private readonly Vector3[][] _destinations = new Vector3[21][];
        private readonly Vector3[] _corners = new Vector3[4];

        private readonly Vector3[] _spawns = new Vector3[21];

        private readonly Direction[] _directions = new Direction[8]; 
        private readonly List<Direction> _caches = new List<Direction>();
        
#if UNITY_EDITOR
        
        private readonly LabelBuilder _labelBuilder = new LabelBuilder();
        
#endif

        private void Awake()
        {
            LogManager.LogProgress();
            
            // Initialize the vertices of the mesh in the plane.
            var matrix = transform.localToWorldMatrix;
            _vertices = GetComponent<MeshFilter>().sharedMesh.vertices;

            var length = _vertices.Length;
            for (var i = 0; i < length; i++)
            {
                _vertices[i] = matrix.MultiplyPoint3x4(_vertices[i]);
            }
            
            var index = 60;
            for (var i = 0; i < 21; i++)
            {
                _destinations[i] = new Vector3[6];
                for (var j = 0; j < 6; j++)
                {
                    _destinations[i][j] = _vertices[index + j];
                }

                _spawns[i] = _vertices[index + 11];
                
                index += 25;
            }

            // Initialize the vertices in the corner.
            _corners[0] = matrix.MultiplyPoint3x4(_vertices[35]);
            _corners[1] = matrix.MultiplyPoint3x4(_vertices[40]);
            _corners[2] = matrix.MultiplyPoint3x4(_vertices[585]);
            _corners[3] = matrix.MultiplyPoint3x4(_vertices[590]);
        }

#if UNITY_EDITOR
        
        private void OnDrawGizmos()
        {
            if (Application.isPlaying == false)
            {
                _labelBuilder.SetStyle("yellow", 8);
            
                var matrix = transform.localToWorldMatrix;
                var vertices = GetComponent<MeshFilter>().sharedMesh.vertices;
                for (var i = 0; i < vertices.Length; i++)
                {
                    _labelBuilder.Append("Index", $"{i}");
                    var label = _labelBuilder.ToString();
                    var position = matrix.MultiplyPoint3x4(vertices[i]);
                    _labelBuilder.Clear();
                
                    UnityEditor.Handles.Label(position, label, new GUIStyle { richText = true });
                
                    Gizmos.color = Color.yellow;
                    Gizmos.DrawSphere(position, 2f);
                }
                
                return;
            }

            _labelBuilder.SetStyle("cyan", 8);

            var text = string.Empty;
            var style = new GUIStyle { richText = true };
            for (var i = 0; i < 21; i++)
            {
                for (var j = 0; j < 6; j++)
                {
                    _labelBuilder.Append("Index", $"{i * 6 + j}");
                    text = _labelBuilder.ToString();
                    _labelBuilder.Clear();
                    
                    UnityEditor.Handles.Label(_destinations[i][j], text, style);
                    
                    Gizmos.color = Color.cyan;
                    Gizmos.DrawSphere(_destinations[i][j], 1f);
                }
            }
            
            _labelBuilder.SetStyle("red", 8);
            
            for (var i = 0; i < 21; i++)
            {
                _labelBuilder.Append("Index", $"{i}");
                text = _labelBuilder.ToString();
                _labelBuilder.Clear();
                
                UnityEditor.Handles.Label(_spawns[i], text, style);
                
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(_spawns[i], 1.6f);
            }
        }

#endif
        
        /// <param name="index"> The index number in the list of plane mesh vertex positions.  </param>
        /// <returns>
        /// The vertex position of the plane mesh corresponding to the index number.
        /// </returns>
        public Vector3 GetPosition(int index)
        {
            LogManager.LogProgress();
            
            return _vertices[index];
        }
        
        /// <param name="index"> The index number in the list of positions where the enemy character arrives. </param>
        /// <returns>
        /// The position where the enemy character arrives corresponding to the index number.
        /// </returns>
        public Vector3? GetDestination(int? index)
        {
            LogManager.LogProgress();

            if (index.HasValue)
            {
                return _destinations[index.Value / 6][index.Value % 6];
            }

            return null;
        }
        
        /// <param name="index"> The index number in the list of positions where the enemy character spawns. </param>
        /// <returns>
        /// The position where the enemy character spawns corresponding to the index number.
        /// </returns>
        public Vector3 GetSpawnPosition(int index)
        {
            LogManager.LogProgress();

            return _spawns[index];
        }
        
        /// <returns>
        /// The coordinates of random position on the plane.
        /// </returns>
        public Vector3 GetRandom()
        {
            LogManager.LogProgress();
            
            // Two triangles in a plane,
            // which triangle contains the random point is chosen corner point is chosen for triangles as the variable.
            var index = Random.Range(0, 2) == 0 ? 0 : 2;

            var a = _corners[3] - _corners[index];
            var b = _corners[1] - _corners[index];

            var u = Random.Range(0.0f, 1.0f);
            var v = Random.Range(0.0f, 1.0f);

            // Sum of coordinates should be smaller than 1 for the point be inside the triangle.
            if (u + v > 1f)
            {
                return _corners[index] + (1f - u) * a + (1f - v) * b;
            }

            return _corners[index] + u * a + v * b;
        }

        public int GetRandomIndex(int index, int range)
        {
            var y = index / 6;
            var x = index % 6;

            for (var i = 1; i <= range; i++)
            {
                _directions[0].SetValue(y - i, x);
                _directions[1].SetValue(y + i, x);
                _directions[2].SetValue(y, x - i);
                _directions[3].SetValue(y, x + i);
                _directions[4].SetValue(y - i, x - i);
                _directions[5].SetValue(y - i, x + i);
                _directions[6].SetValue(y + i, x - i);
                _directions[7].SetValue(y + i, x + i);

                for (var j = 0; j < 8; j++)
                {
                    var a = _directions[j].Y;
                    var b = _directions[j].X;
                    if (0 <= a && a < 21 && 0 <= b && b < 6)
                    {
                        _caches.Add(_directions[j]);
                    }
                }
            }
            
            var count = _caches.Count;
            var cache = _caches[Random.Range(0, count)];
            _caches.Clear();
            
            return cache.Y * 6 + cache.X;
        }

        #region PRIVATE CLASS & STRUCT API

        private struct Direction
        {
            public void SetValue(int y, int x)
            {
                Y = y; 
                X = x;
            }
            
            public int Y { get; private set; }
            public int X { get; private set; }
        }

        #endregion
    }
}