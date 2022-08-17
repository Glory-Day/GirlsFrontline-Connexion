#region NAMESPACE API

using UnityEngine;
using Manager;

#endregion

namespace Scene
{
    /// <summary>
    /// 
    /// </summary>
    public class ManagerUtility : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
            LogManager.OnDebugLog(typeof(ManagerUtility),
                "Start()");
            
            AssetManager.OnInitialize();
            SoundManager.OnInitialize();
            ObjectManager.OnInitialize();
            UIManager.OnInitialize();
        }
    }
}
