using System;
using GloryDay.Debug;
using UnityEngine;

using Console = GloryDay.Debug.Console;

namespace Core.Object.Character
{
    public class AttackAction : MonoBehaviour
    {
        protected float DefaultDamagePoint;
        protected float DefaultDefensePenetrationPoint;
        
        protected string Tag;

        private void Awake()
        {
            Console.LogProgress();
            
            var child = transform.GetChild(0);
            Tag = child.tag;
        }

        /// <param name="damagePoint"> Default damage point in character stat. </param>
        /// <param name="defensePenetrationPoint"> Default defense penetration point in character stat. </param>
        public void SetCharacterDamagePoint(float damagePoint, float defensePenetrationPoint)
        {
            DefaultDamagePoint = damagePoint;
            DefaultDefensePenetrationPoint = defensePenetrationPoint;
        }
    }
}