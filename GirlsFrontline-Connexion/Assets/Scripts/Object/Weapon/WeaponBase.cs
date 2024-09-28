using UnityEngine;

namespace Object.Weapon
{
    public class WeaponBase : MonoBehaviour
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="characterTag"> Tag of the character that called. </param>
        public void SetCalledCharacterInfo(string characterTag)
        {
            CalledCharacterTag = characterTag;
        }

        public void SetData(float damagePoint, float defensePenetrationPoint)
        {
            DamagePoint = damagePoint;
            DefensePenetrationPoint = defensePenetrationPoint;
        }
        
        /// <summary>
        /// The damage point for weapon.
        /// </summary>
        public float DamagePoint { get; private set; }
        
        /// <summary>
        /// The defense penetration point for weapon. A point is a value between 0 and 1.
        /// </summary>
        public float DefensePenetrationPoint { get; protected set; }
        
        /// <summary>
        /// Tag of the character that called.
        /// </summary>
        protected string CalledCharacterTag { get; private set; }
    }
}