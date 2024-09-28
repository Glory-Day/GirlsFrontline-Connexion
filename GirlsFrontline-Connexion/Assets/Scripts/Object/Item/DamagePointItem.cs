using UnityEngine;

namespace Object.Item
{
    public class DamagePointItem : ItemBase
    {
        #region SERIALIZABLE FIELD API

        [SerializeField] private float damagePoint;
        [SerializeField] private float defensivePenetrationPoint;

        #endregion

        public float DamagePoint => damagePoint;

        public float DefensivePenetrationPoint => defensivePenetrationPoint;
    }
}