using Newtonsoft.Json;
using Utility.Manager.Data.Json;

namespace Utility.Manager.Data.Stream
{
    public class AudioSourceDataStream : IDataStream<AudioSourceData>
    {
        public AudioSourceData Load()
        {
            LogManager.LogProgress();
            
            var json = AssetManager.TextReference.Data[nameof(AudioSourceData)].text;
            var data = JsonConvert.DeserializeObject<AudioSourceData>(json);

            return data;
        }
    }
}
