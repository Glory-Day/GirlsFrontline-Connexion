using Newtonsoft.Json;

namespace Utility.Manager.Data.Converter
{
    public class AudioSourceDataStream : IDataConverter<AudioClipData>
    {
        public AudioClipData ToObject()
        {
            LogManager.LogProgress();
            
            var json = AssetManager.TextAssets.Data[nameof(AudioClipData)].text;
            var data = JsonConvert.DeserializeObject<AudioClipData>(json);

            return data;
        }
    }
}
