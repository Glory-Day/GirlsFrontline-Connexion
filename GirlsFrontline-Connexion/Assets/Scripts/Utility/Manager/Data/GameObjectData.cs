namespace Utility.Manager.Data
{
    public class UI
    {
        public string SceneTransitionScreen { get; set; }
        
        public string PauseScreen { get; set; }
        
        public string OptionScreen { get; set; }
        
        public string CommandConsole { get; set; }
        
        public string LoadingMessageScreen { get; set; }
        
        public string CommandButton { get; set; }
    }
    
    public class GameObjectData
    {
        public UI UI { get; set; } = new UI();
    }
}
