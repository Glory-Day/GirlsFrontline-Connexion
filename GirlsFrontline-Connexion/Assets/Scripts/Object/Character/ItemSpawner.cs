using System;
using System.Collections.Generic;
using GloryDay.Debug.Log;
using Object.Item;
using UnityEngine;
using Utility.Manager;
using Random = UnityEngine.Random;

namespace Object.Character
{
    public class ItemSpawner : MonoBehaviour
    {
        #region SERIALIZABLE FIELD API

        [SerializeField]
        private int count;

        #endregion
        
        private readonly List<GameObject> _items = new List<GameObject>();
        private readonly List<float[]> _distances = new List<float[]>
                                                    {
                                                        new[] { 0f },
                                                        new[] { -4f, 4f },
                                                        new[] { -7f, 0f, 7f },
                                                        new[] { -11f, -4f, 4f, 11f }
                                                    };

        public void Spawn()
        {
            LogManager.LogProgress();
            
            var position = transform.position;
            
            _items.AddRange(ResourceManager.GameObjectResource.Item);
            for (var i = 0; i < count; i++)
            {
                var index = Random.Range(0, _items.Count);
                var original = _items[index].gameObject;
                _items.RemoveAt(index);
                
                var destination = new Vector3(position.x + _distances[count - 1][i], position.y, position.z);
                var clone = ObjectManager.OnSpawn<ItemBase>(original, position);
                clone.gameObject.SetActive(true);
                clone.Drop(destination);
            }
            
            _items.Clear();
        }
    }
}