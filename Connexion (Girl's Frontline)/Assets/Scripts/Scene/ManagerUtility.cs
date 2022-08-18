#region NAMESPACE API

using UnityEngine;
using Manager;
using Manager.Sound;

#endregion

namespace Scene
{
    /// <summary>
    /// 
    /// </summary>
    public class ManagerUtility : MonoBehaviour
    {
        private const string AudioMixerGroupsName = "Audio Mixer Groups";
        
        // Start is called before the first frame update
        private void Start()
        {
            LogManager.OnDebugLog(typeof(ManagerUtility),
                "Start()");
            
            AssetManager.OnInitialize();
            SoundManager.OnInitialize(
                GameObject.Find(AudioMixerGroupsName).GetComponent<AudioMixerGroupData>());
            ObjectManager.OnInitialize();
            UIManager.OnInitialize();
        }
    }
}
