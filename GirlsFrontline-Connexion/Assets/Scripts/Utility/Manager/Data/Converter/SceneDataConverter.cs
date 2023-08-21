using Newtonsoft.Json;

namespace Utility.Manager.Data.Converter
{
    public class SceneDataConverter : IDataConverter<SceneData[]>
    {
        public SceneData[] ToObject()
        {
            LogManager.LogProgress();
            
            var json = AssetManager.TextAssets.Data[nameof(SceneData)].text;
            var data = JsonConvert.DeserializeObject<SceneData[]>(json);

            return data;
        }
    }
}
