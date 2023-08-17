using Newtonsoft.Json;
using Util.Manager.Data.Json;

namespace Util.Manager.Data.Stream
{
    public class AudioSourceDataStream : IDataStream<AudioSourceData>
    {
        public AudioSourceData Load()
        {
            LogManager.LogProgress();
            
            var json = AssetManager.TextAsset.Data[nameof(AudioSourceData)].text;
            var data = JsonConvert.DeserializeObject<AudioSourceData>(json);

            return data;
        }
    }
}
