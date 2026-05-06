namespace GloryDay.Font.Bitmap
{
    public struct Field
    {
        public struct Information
        {
            public const string Header = "info";
            public const string Face = "face";
            public const string Size = "size";
        }

        public struct Common
        {
            public const string Header = "common";
            public const string LineHeight = "lineHeight";
            public const string LineBaseHeight = "base";
            public const string TextureWidth = "scaleW";
            public const string TextureHeight = "scaleH";
            public const string TextureNames = "pages";
        }

        public struct Count
        {
            public const string Header = "count";
        }

        public struct Page
        {
            public const string File = "file";
            public const string ID = "id";
        }

        public struct Kerning
        {
            public const string Header = "kerning";
            public const string First = "first";
            public const string Second = "second";
            public const string Amount = "amount";
        }

        public struct Character
        {
            public const string Header = "char";
            public const string ID = "id";
            public const string X = "x";
            public const string Y = "y";
            public const string Width = "width";
            public const string Height = "height";
            public const string XOffset = "xoffset";
            public const string YOffset = "yoffset";
            public const string Advance = "xadvance";
        }
    }
}