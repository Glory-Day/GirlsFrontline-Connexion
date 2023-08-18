using System.Collections.Generic;
using UnityEngine;

namespace Utility.Manager.Asset.Reference
{
    public class PrefabReference
    {
        public Dictionary<string, GameObject> UI { get; } 
            = new Dictionary<string, GameObject>();
    }
}
