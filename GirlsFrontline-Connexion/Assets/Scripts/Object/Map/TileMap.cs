using System.Collections.Generic;
using GloryDay.Log;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Object.Map
{
    public class TileMap : MonoBehaviour
    {
        #region CONSTANT FIELD API

        private const int MaximumColumnLength = 9;
        private const int MaximumRowLength = 5;

        #endregion
        
        private readonly Tile[,] _map = new Tile[MaximumColumnLength, MaximumRowLength];

        private void Awake()
        {
            LogManager.LogProgress();
            
            // Initialize the tiles to a grid type map.
            for (var y = 0; y < MaximumColumnLength; y++)
            {
                for (var x = 0; x < MaximumRowLength; x++)
                {
                    var index = x * MaximumColumnLength + y;
                    var tile = transform.GetChild(index).GetComponent<Tile>();
                    tile.Index = index;

                    _map[y, x] = tile;
                }
            }
            
            // Initialize a tile for distance comparison.
            PlayerCharacter = _map[0, 0];
        }
        
        /// <param name="y"> Y-axis coordinate value. </param>
        /// <param name="x"> X-axis coordinate value. </param>
        /// <returns> Tile for given coordinate values. </returns>
        public Tile GetTile(int y, int x)
        {
            if (0 <= x && x < MaximumRowLength && 0 <= y && y < MaximumColumnLength)
            {
                return _map[y, x];
            }

            return null;
        }

        public Tile[] GetColumn(int index)
        {
            var x = index % MaximumRowLength;
            
            var tiles = new Tile[MaximumRowLength];
            for (var i = 0; i < MaximumRowLength; i++)
            {
                tiles[i] = _map[i, x];
            }

            return tiles;
        }

        public Tile[] GetRow(int index)
        {
            var y = index / MaximumRowLength;

            var tiles = new Tile[MaximumRowLength];
            for (var i = 0; i < MaximumRowLength; i++)
            {
                tiles[i] = _map[y, i];
            }

            return tiles;
        }
        
        /// <returns> Tile in randomized position. </returns>
        public Tile GetRandom()
        {
            var y = Random.Range(0, MaximumColumnLength);
            var x = Random.Range(0, MaximumRowLength);

            return _map[y, x];
        }
        
        /// <param name="index"> Index number of tile. </param>
        /// <returns> Random tile in row of given index. </returns>
        public Tile GetRandomInRow(int index)
        {
            var y = index / MaximumRowLength;
            var x = Random.Range(0, MaximumRowLength);

            return _map[y, x];
        }

        /// <param name="index"> Index number of tile. </param>
        /// <returns> Random tile in column of given index. </returns>
        public Tile GetRandomInColumn(int index)
        {
            var y = Random.Range(0, MaximumColumnLength);
            var x = index % MaximumRowLength;
            
            return _map[y, x];
        }

        public int ColumnLength => _map.GetLength(0);

        public int RowLength => _map.GetLength(1);
        
        /// <summary>
        /// The tile the player character is standing on.
        /// </summary>
        public Tile PlayerCharacter { get; set; }

        public Dictionary<int, Queue<Tile>> WarningStateTiles { get; } = new Dictionary<int, Queue<Tile>>();

        public Dictionary<int, Queue<Tile>> CriticalStateTiles { get; } = new Dictionary<int, Queue<Tile>>();

        public Tile this[int y, int x] => _map[y, x];
    }
}