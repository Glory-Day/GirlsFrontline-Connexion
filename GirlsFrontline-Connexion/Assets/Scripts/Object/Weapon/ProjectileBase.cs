using UnityEngine;

namespace Object.Weapon
{
    public class ProjectileBase : WeaponBase
    {
        public void SetData(float damagePoint, float defensePenetrationPoint, float speedPoint)
        {
            base.SetData(damagePoint, defensePenetrationPoint);

            SpeedPoint = speedPoint;
        }
        
        /// <summary>
        /// Set after calculating the angle when moving in a curve.
        /// </summary>
        /// <param name="direction"> The direction of movement. </param>
        protected static Quaternion Rotate(Vector3 direction)
        {
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
            return Quaternion.Euler(0f, 0f, angle);
        }
        
        /// <summary>
        /// The speed point for projectile movement.
        /// </summary>
        protected float SpeedPoint { get; private set; }
    }
}