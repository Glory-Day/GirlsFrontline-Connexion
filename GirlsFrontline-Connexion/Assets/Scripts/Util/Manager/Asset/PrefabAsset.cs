using System.Collections.Generic;
using UnityEngine;

namespace Util.Manager.Asset
{
    public class PrefabAsset
    {
        public PrefabAsset()
        {
            UI = new Dictionary<string, GameObject>();
        }
        
        public Dictionary<string, GameObject> UI { get; set; }
    }
}
