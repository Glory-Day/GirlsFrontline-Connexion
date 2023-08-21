using Newtonsoft.Json;

namespace Utility.Manager.Data.Converter
{
    public class PrefabDataConverter : IDataConverter<PrefabData>
    {
        public PrefabData ToObject()
        {
            LogManager.LogProgress();
            
            var json = AssetManager.TextAssets.Data[nameof(PrefabData)].text;
            var data = JsonConvert.DeserializeObject<PrefabData>(json);

            return data;
        }
    }
}
