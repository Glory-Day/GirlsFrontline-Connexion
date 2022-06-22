using Manager.Log;

namespace Manager.Data
{
    /// <summary>
    /// Class to manage the data needed for the game
    /// </summary>
    public class DataManager : Singleton<DataManager>
    {
        protected DataManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }
        
        /// <summary>
        /// Initialize audio-related labels
        /// </summary>
        public static void OnInitializeAudioLabelData()
        {
#if UNITY_EDITOR

            LogManager.OnDebugLog(
                typeof(DataManager), 
                $"Called OnInitializeAudioLabelData()");

#endif
            
            Audio = DataLoader<Category.Label>.OnLoadData(JsonAddresses.Audio);
            
            SoundManager.OnInitializeAudios();
        }

        #region STATIC API

        public static Category.Label Audio { get; private set; }

        #endregion

    }
}
