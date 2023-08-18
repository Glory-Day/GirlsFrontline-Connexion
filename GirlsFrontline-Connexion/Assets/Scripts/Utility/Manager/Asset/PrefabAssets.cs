using System.Collections.Generic;
using UnityEngine;

namespace Utility.Manager.Asset
{
    public class PrefabAssets
    {
        public Dictionary<string, GameObject> UI { get; } 
            = new Dictionary<string, GameObject>();
    }
}
