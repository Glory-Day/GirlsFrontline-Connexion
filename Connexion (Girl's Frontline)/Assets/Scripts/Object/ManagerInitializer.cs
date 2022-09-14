#region NAMESPACE API

using UnityEngine;
using Object.Manager;
using Util.Manager;
using Util.Manager.Log;

#endregion

namespace Object
{
    public class ManagerInitializer : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
            LogManager.OnDebugLog(
                Label.Called,
                typeof(ManagerInitializer),
                "Start()");
            
            SoundManager.OnInitialize();
            ObjectManager.OnInitialize();
            UIManager.OnInitialize();
            
            LogManager.OnDebugLog(
                Label.Success,
                typeof(ManagerInitializer), 
                "Initialized Managers");
        }
    }
}
