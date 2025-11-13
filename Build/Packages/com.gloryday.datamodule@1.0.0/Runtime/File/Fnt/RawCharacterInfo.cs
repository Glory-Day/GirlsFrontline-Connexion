namespace GloryDay.Data.File.Fnt
{
    public class RawCharacterInfo
    {
        public int ID { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        
        public int XOffset { get; set; }
        public int YOffset { get; set; }

        public int Advance { get; set; }
        
        public int Page { get; set; }
    }
}