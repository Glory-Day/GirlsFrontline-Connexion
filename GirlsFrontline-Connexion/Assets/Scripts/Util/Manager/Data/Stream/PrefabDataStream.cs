using Newtonsoft.Json;
using Util.Manager.Data.Json;

namespace Util.Manager.Data.Stream
{
    public class PrefabDataStream : IDataStream<PrefabData>
    {
        public PrefabData Load()
        {
            LogManager.LogProgress();
            
            var json = AssetManager.TextAsset.Data[nameof(PrefabData)].text;
            var data = JsonConvert.DeserializeObject<PrefabData>(json);

            return data;
        }
    }
}
