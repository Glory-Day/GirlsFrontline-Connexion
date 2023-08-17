namespace Util.Manager.Data.Json
{
    public class UI
    {
        public string TransitionScreen { get; set; }
        public string PauseScreen { get; set; }
        public string OptionScreen { get; set; }
        public string CommandConsole { get; set; }
    }
    
    public class PrefabData
    {
        public UI UI { get; set; } = new UI();
    }
}
