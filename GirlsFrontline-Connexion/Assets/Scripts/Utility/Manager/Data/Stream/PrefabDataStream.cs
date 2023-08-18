using Newtonsoft.Json;
using Utility.Manager.Data.Json;

namespace Utility.Manager.Data.Stream
{
    public class PrefabDataStream : IDataStream<PrefabData>
    {
        public PrefabData Load()
        {
            LogManager.LogProgress();
            
            var json = AssetManager.TextReference.Data[nameof(PrefabData)].text;
            var data = JsonConvert.DeserializeObject<PrefabData>(json);

            return data;
        }
    }
}
