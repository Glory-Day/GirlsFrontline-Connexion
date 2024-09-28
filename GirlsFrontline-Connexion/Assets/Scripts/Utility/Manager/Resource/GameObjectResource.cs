using System.Collections.Generic;
using Object.Weapon;
using UnityEngine;

namespace Utility.Manager.Resource
{
    public class GameObjectResource
    {
        public GameObject PlayerCharacter { get; set; }
        
        public Dictionary<string, GameObject> EnemyCharacter { get; } = new Dictionary<string, GameObject>();
        
        public List<GameObject> Item { get; } = new List<GameObject>();
        
        public Dictionary<string, WeaponBase> Weapon { get; } = new Dictionary<string, WeaponBase>();
        
        public Dictionary<string, Bullet> Bullet { get; } = new Dictionary<string, Bullet>();
        
        public Dictionary<string, Grenade> Grenade { get; } = new Dictionary<string, Grenade>();
    }
}
