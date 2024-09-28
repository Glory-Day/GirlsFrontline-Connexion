using UnityEngine;

namespace Object.Item
{
    public class HealthPointItem : ItemBase
    {
        #region SERIALIZABLE FIELD API

        [SerializeField] private float healthPoint;

        #endregion

        public float HealthPoint => healthPoint;
    }
}