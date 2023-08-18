namespace Utility.Manager.Data
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
    
    public class AudioClipData
    {
        public Background Background { get; set; } = new Background();
        public Effect Effect { get; set; } = new Effect();
        public Voice Voice { get; set; } = new Voice();
    }
}
