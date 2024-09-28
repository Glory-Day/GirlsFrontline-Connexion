using UnityEngine;

namespace Object.Item
{
    public class DefensivePointItem : ItemBase
    {
        #region SERIALIZABLE FIELD API

        [SerializeField] private float defensivePoint;

        #endregion

        public float DefensivePoint => defensivePoint;
    }
}