using System.Text;
using GloryDay;

namespace Object.Character
{
    public class DamageNumberRenderer : BitmapTextParticleSystem
    {
        #region SERIALIZABLE FIELD API

        public bool hasIcon;

        #endregion

        private readonly StringBuilder _builder = new StringBuilder();
        
        public void Render(string message)
        {
            if (hasIcon)
            {
                _builder.Append('#');
            }

            _builder.Append(message);
            
            Spawn(_builder.ToString(), 1.5f);

            _builder.Clear();
        }
    }
}