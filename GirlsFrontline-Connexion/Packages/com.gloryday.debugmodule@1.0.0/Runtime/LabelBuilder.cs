using System.Text;

namespace GloryDay.Debug
{
    public class LabelBuilder
    {
        #region CONSTANT FIELD API

        private const string DefaultTextColor = "white";

        #endregion

        private string _color;
        private int _fontSize;
        
        private readonly StringBuilder _builder = new StringBuilder();
        
        public LabelBuilder() {}
        
        public LabelBuilder(string color, int fontSize)
        {
            _color = color;
            _fontSize = fontSize;
        }

        public void SetStyle(string color, int fontSize)
        {
            _color = color;
            _fontSize = fontSize;
        }

        public void Append(string text)
        {
            var prefix = $"<size={_fontSize}><color={_color}><b>\u25a3 </b></color></size>";
            var line = $"<size={_fontSize - 2}><color={DefaultTextColor}>{text}</color></size>";

            _builder.Append(prefix);
            _builder.Append(line);
            _builder.Append("\n");
        }

        public void Append(string text, string value)
        {
            var prefix = $"<size={_fontSize}><color={_color}><b>\u25a3 </b></color></size>";
            var line01 = $"<size={_fontSize - 2}><color={DefaultTextColor}>{text}: </color></size>";
            var line02 = $"<size={_fontSize - 2}><color={_color}><b>{value}</b></color></size>";
            
            _builder.Append(prefix);
            _builder.Append(line01);
            _builder.Append(line02);
            _builder.Append("\n");
        }

        public void Clear()
        {
            _builder.Clear();
        }

        public override string ToString()
        {
            return _builder.ToString();
        }
    }
}