using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.UI.CommandConsole.Utils;

namespace Library.UI.CommandConsole
{
    public class ParameterDataBuilder
    {
        private readonly StringBuilder _stringBuilder   = new StringBuilder();
        private readonly List<string>  _argumentBuilder = new List<string>();
        
        private readonly List<string>   _names = new List<string>();
        private readonly List<string[]> _data  = new List<string[]>();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="argumentLine"></param>
        public void Build(string argumentLine)
        {
            var flag = false;
            var length = argumentLine.Length;
            for (var i = 0; i < length; i++)
            {
                switch (argumentLine[i])
                {
                    case SpecialCharacter.DoubleQuote:
                        flag = !flag;
                        break;
                    case SpecialCharacter.WhiteSpace:
                        if (flag)
                        {
                            _stringBuilder.Append(argumentLine[i]);
                        }
                        else
                        {
                            _argumentBuilder.Add(_stringBuilder.ToString());
                            _stringBuilder.Clear();
                        }
                        break;
                    default:
                        _stringBuilder.Append(argumentLine[i]);
                        break;
                }
            }
            _argumentBuilder.Add(_stringBuilder.ToString());
            _stringBuilder.Clear();
                
            // Split part of argument to name and data
            _names.Add(_argumentBuilder[0]);
            _data.Add(_argumentBuilder.Count > 1 ? _argumentBuilder.Skip(1).ToArray() : null);
            _argumentBuilder.Clear();
        }
        
        /// <returns>
        /// The built argument packet
        /// </returns>
        public ParameterData GetData()
        {
            ParameterData data;
            if (_names.Count == 0 && _data.Count == 0)
            {
                data = null;
            }
            else
            {
                data = new ParameterData(_names, _data);
                _names.Clear();
                _data.Clear();
            }

            return data;
        }
    }
}