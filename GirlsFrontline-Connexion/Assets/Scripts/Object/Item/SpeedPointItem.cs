using UnityEngine;

namespace Object.Item
{
    public class SpeedPointItem : ItemBase
    {
        #region SERIALIZABLE FIELD API

        [SerializeField] private float speedPoint;

        #endregion

        public float SpeedPoint => speedPoint;
    }
}