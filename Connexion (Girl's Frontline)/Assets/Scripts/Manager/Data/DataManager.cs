using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager.Data
{
    public class DataManager : Singleton<DataManager>
    {
        protected DataManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }
    }
}
