using System.Text;

namespace GloryDay.Debug.Gizmos
{
    public class LabelBuilder
    {
        #region CONSTANT FIELD API

        private const string DefaultTextColor = "white";

        #endregion
        
        private readonly StringBuilder _builder = new StringBuilder();
        
        public LabelBuilder()
        {
            Color = DefaultTextColor;
            FontSize = 14;
        }

        public LabelBuilder(string color, int fontSize)
        {
            Color = color;
            FontSize = fontSize;
        }

        public void Append(string text)
        {
            _builder.Append(GetPrefixLabel());
            _builder.Append(GetDefaultLabel(text));
            _builder.Append('\n');
        }

        public void Append(string text01, string text02)
        {
            _builder.Append(GetPrefixLabel());
            _builder.Append(GetDefaultLabel(text01));
            _builder.Append(GetLabel(text02));
            _builder.Append('\n');
        }

        public void Clear()
        {
            _builder.Clear();
        }

        public override string ToString()
        {
            return _builder.ToString();
        }

        private string GetPrefixLabel() => $"<size={FontSize}><color={Color}><b>\u25a3 </b></color></size>";

        private string GetDefaultLabel(string text) => $"<size={FontSize - 2}><color={DefaultTextColor}>{text}</color></size>";

        private string GetLabel(string text) => $"<size={FontSize - 2}><color={Color}><b>{text}</b></color></size>";

        public string Color { get; set; }

        public int FontSize { get; set; }
    }
}