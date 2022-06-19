using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager.Resource
{
    public class ResourceManager : Singleton<ResourceManager>
    {
        protected ResourceManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }
    }
}
