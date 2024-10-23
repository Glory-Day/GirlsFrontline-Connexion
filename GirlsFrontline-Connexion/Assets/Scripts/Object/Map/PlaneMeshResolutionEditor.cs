using GloryDay.Debug.Log;
using UnityEngine;

namespace Object.Map
{
    public class PlaneMeshResolutionEditor : MonoBehaviour
    {
        #region SERIALIZABLE FIELD API

        [Header("Materials")]
        [SerializeField] private Material material;
        
        [Header("Resolution Setting")]
        [SerializeField] [Range(2, 256)] private int count;
        [SerializeField] [Range(1f, 100f)] private float width;
        [SerializeField] [Range(1f, 100f)] private float height;
        
        #endregion

        #region COMPONENT FIELD API
        
        private MeshFilter _filter;
        private MeshRenderer _renderer;

        #endregion

        private Mesh _mesh;

        private Vector3[] _vertices;
        private int[] _triangles;
        private Vector2[] _uvs;

        private void Awake()
        {
            LogManager.LogProgress();

            Initialize();
        }

        private void Initialize()
        {
            LogManager.LogProgress();

            _filter = GetComponent<MeshFilter>();
            _renderer = GetComponent<MeshRenderer>();

            _mesh = new Mesh();
            _filter.mesh = _mesh;
            _renderer.material = material;
            
            Generate();
        }

        private void Generate()
        {
            LogManager.LogProgress();
            
            var resolution = (int)(count * height / width);

            var quad = new Vector3(width, 0f, height);
            var start = -quad * 0.5f;
            var unit = new Vector2(width / count, height / resolution);

            var x = count + 1;
            var y = resolution + 1;
            
            _vertices = new Vector3[x * y];
            _triangles = new int[count * resolution * 6];
            _uvs = new Vector2[x * y];
            
            for (var i = 0; i < y; i++)
            {
                for (var j = 0; j < x; j++)
                {
                    var index = j + i * x;
                    _vertices[index] = start + new Vector3(unit.x * j, 0f, unit.y * i);

                    _uvs[index] = new Vector2((float)j / (x - 1), (float)i / (y - 1));
                }
            }
            
            var index01 = 0;
            for (var i = 0; i < y - 1; i++)
            {
                for (var j = 0; j < x - 1; j++)
                {
                    var index02 = j + i * x;
                    _triangles[index01 + 0] = index02;
                    _triangles[index01 + 1] = index02 + x;
                    _triangles[index01 + 2] = index02 + 1;
                    _triangles[index01 + 3] = index02 + x;
                    _triangles[index01 + 4] = index02 + x + 1;
                    _triangles[index01 + 5] = index02 + 1;

                    index01 += 6;
                }
            }
        }

        [ContextMenu("Edit Plane Mesh Resolution")]
        public void Edit()
        {
            LogManager.LogProgress();
            
            Initialize();
            
            _mesh.vertices = _vertices;
            _mesh.triangles = _triangles;
            _mesh.uv = _uvs;
            
            _mesh.RecalculateNormals();
        }
    }
}