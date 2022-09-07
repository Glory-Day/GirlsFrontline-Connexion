#region NAMESPACE API

using UnityEngine;
using Manager;

#endregion

namespace Object
{
    public class ManagerInitializer : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
            LogManager.OnDebugLog(
                typeof(ManagerInitializer),
                "Start()");

            
            AssetManager.OnInitialize();
            SoundManager.OnInitialize();
            ObjectManager.OnInitialize();
            UIManager.OnInitialize();
        }
    }
}
