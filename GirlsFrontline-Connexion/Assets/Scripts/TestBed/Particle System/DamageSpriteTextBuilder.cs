using System;
using System.Text;

namespace DefaultNamespace
{
    public static class DamageSpriteTextBuilder
    {
        private const int IconIndex = 10;

        [ThreadStatic] private static StringBuilder _builder;

        public static string Build(int value, bool hasIcon)
        {
            if (_builder == null)
            {
                _builder = new StringBuilder(64);
            }
            _builder.Clear();

            if (hasIcon)
            {
                Append(IconIndex);
            }

            var text = value.ToString();
            for (var i = 0; i < text.Length; i++)
            {
                var digit = text[i] - '0';
                Append(digit);
            }

            return _builder.ToString();

            void Append(int index) => _builder.Append("<sprite=").Append(index).Append(">");
        }
    }
}
