#if UNITY_EDITOR

using System;
using System.Text;
using Util.Log.Component;

namespace Util.Log
{
    public static class Builder
    {
        static Builder()
        {
            Line = new StringBuilder();
        }
        
        #region STATIC FIELD API

        /// <summary>
        /// 
        /// </summary>
        private static readonly StringBuilder Line;

        #endregion

        #region STATIC METHOD API

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        private static string GetName(this Label label)
        {
            return Enum.GetName(typeof(Label), label)?.ToUpper();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="label"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private static void SetColor(this StringBuilder builder, Label label)
        {
            switch (label)
            {
                case Label.Administrator:
                    builder.Append(Tag.Color.Opener.Administrator);
                    break;
                case Label.Called:
                case Label.Message:
                    builder.Append(Tag.Color.Opener.Default);
                    break;
                case Label.Error:
                    builder.Append(Tag.Color.Opener.Error);
                    break;
                case Label.Success:
                    builder.Append(Tag.Color.Opener.Success);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(label), label, null);
            }
            
            builder.Append(Tag.Bold.Opener);
            builder.Append(Text.Bracket.Left);
            builder.Append(label.GetName());
            builder.Append(Text.Bracket.Right);
            builder.Append(Tag.Bold.Closer);
            builder.Append(Tag.Color.Closer);
            builder.Append(Text.NextLine);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="header"></param>
        /// <param name="content"></param>
        private static void SetBold(this StringBuilder builder, string header, string content)
        {
            builder.Append(Tag.Color.Opener.Default);
            builder.Append(Tag.Bold.Opener);
            builder.Append(header);
            builder.Append(Tag.Bold.Closer);
            builder.Append(Tag.Color.Closer);
            builder.Append(content);
            builder.Append(Text.NextLine);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="className"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public static string Build(string className, string methodName)
        {
            Line.SetColor(Label.Called);
            Line.SetBold(Text.Header.Class, className);
            Line.SetBold(Text.Header.Method, methodName + Text.Parentheses);
            Line.Append(Text.NextLine);

            var log = Line.ToString();
            Line.Clear();

            return log;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="message"></param>
        /// <param name="className"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public static string Build(Label label, string message, string className, string methodName)
        {
            Line.SetColor(label);
            Line.SetBold(Text.Header.Class, className);
            Line.SetBold(Text.Header.Method, methodName + Text.Parentheses);
            Line.SetBold(Text.Header.Message, message);

            var log = Line.ToString();
            Line.Clear();

            return log;
        }
        
        #endregion
    }
}

#elif DEVELOPMENT_BUILD

using System;
using System.Text;
using Util.Log.Component;

namespace Util.Log
{
    public static class Builder
    {
        static Builder()
        {
            Line = new StringBuilder();
        }
        
        #region STATIC FIELD API

        /// <summary>
        /// 
        /// </summary>
        private static readonly StringBuilder Line;

        #endregion

        #region STATIC METHOD API

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
        private static string GetName(this Label label)
        {
            return Enum.GetName(typeof(Label), label)?.ToUpper();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="className"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public static string Build(string className, string methodName)
        {
            Line.Append(Label.Called.GetName());
            Line.Append(Text.Separator);
            Line.Append(className);
            Line.Append(Text.Separator);
            Line.Append(methodName + Text.Parentheses);

            var log = Line.ToString();
            Line.Clear();

            return log;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="message"></param>
        /// <param name="className"></param>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public static string Build(Label label, string message, string className, string methodName)
        {
            Line.Append(label.GetName());
            Line.Append(Text.Separator);
            Line.Append(className);
            Line.Append(Text.Separator);
            Line.Append(methodName + Text.Parentheses);
            Line.Append(Text.Separator);
            Line.Append(message);

            var log = Line.ToString();
            Line.Clear();

            return log;
        }
        
        #endregion
    }
}

#endif


