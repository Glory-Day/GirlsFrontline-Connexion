#region NAMESPACE API

using UnityEngine;
using Manager;

#endregion

namespace Object
{
    public class ManagerInitializer : MonoBehaviour
    {
        private const string AudioMixerGroupsName = "Audio Mixer Groups";
        
        // Start is called before the first frame update
        private void Start()
        {
            LogManager.OnDebugLog(
                typeof(ManagerInitializer),
                "Start()");

            var audioMixerGroupData = GameObject.Find(AudioMixerGroupsName).GetComponent<AudioMixerGroups>();
            AssetManager.OnInitialize();
            SoundManager.OnInitialize(audioMixerGroupData);
            ObjectManager.OnInitialize();
            UIManager.OnInitialize();
        }
    }
}
