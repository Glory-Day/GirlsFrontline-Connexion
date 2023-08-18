using System.Collections.Generic;
using UnityEngine;

namespace Utility.Manager.Asset.Reference
{
    public class TextReference
    {
        public Dictionary<string, TextAsset> Data { get; } 
            = new Dictionary<string, TextAsset>();
    }
}
