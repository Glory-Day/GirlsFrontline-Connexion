namespace GloryDay.Font.Bitmap
{
    public class RawCharacterInformation
    {
        public int ID { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Offset Offset { get; set; }

        public int Advance { get; set; }

        public int Page { get; set; }
    }
}