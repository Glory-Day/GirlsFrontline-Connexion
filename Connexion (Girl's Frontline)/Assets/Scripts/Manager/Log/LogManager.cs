using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager.Log
{
    public class LogManager : Singleton<LogManager>
    {
        protected LogManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }
    }
}
