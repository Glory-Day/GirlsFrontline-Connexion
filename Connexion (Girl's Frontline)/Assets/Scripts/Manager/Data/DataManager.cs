using Manager.Log;

namespace Manager.Data
{
    public class DataManager : Singleton<DataManager>
    {
        

        protected DataManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }
        
        public static void OnInitializeAudioLabelData()
        {
#if UNITY_EDITOR

            LogManager.OnDebugLog(
                typeof(DataManager), 
                $"Called OnInitializeAudioData()");

#endif
            
            Audio = DataLoader<Category.Label>.OnLoadData(JsonAddresses.Audio);
            
            SoundManager.OnInitializeAudioData();
        }

        #region STATIC API

        public static Category.Label Audio { get; private set; }

        #endregion

    }
}
