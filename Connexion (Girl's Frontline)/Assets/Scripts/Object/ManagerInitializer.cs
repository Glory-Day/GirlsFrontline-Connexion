#region NAMESPACE API

using UnityEngine;
using Manager;
using Label = Manager.Log.Label;

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

            AssetManager.OnInitialize();
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
