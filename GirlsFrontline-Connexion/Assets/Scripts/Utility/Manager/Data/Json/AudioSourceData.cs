namespace Utility.Manager.Data.Json
{
    public class Background
    {
        public string Main { get; set; }
    }

    public class Effect
    {
        
    }

    public class Voice
    {
        
    }
    
    public class AudioSourceData
    {
        public Background Background { get; set; } = new Background();
        public Effect Effect { get; set; } = new Effect();
        public Voice Voice { get; set; } = new Voice();
    }
}
