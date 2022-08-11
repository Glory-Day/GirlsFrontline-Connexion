#region NAMESPACE API

using UnityEngine;
using Manager;

#endregion

namespace Scene
{
    public class ManagerUtility : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
            AssetManager.OnInitialize();
            SoundManager.OnInitialize();
            ObjectManager.OnInitialize();
            UIManager.OnInitialize();
        }
    }
}
