#region NAMESPACE API

using System;

#endregion

namespace Manager.Log.DevelopmentBuild
{
    public static class LogBuilder
    {
        /// <summary>
        /// Build string of administrator permission log
        /// </summary>
        /// <param name="contents"> Contents of output log </param>
        /// <returns> String of administrator permission log </returns>
        public static string Build(string contents)
        {
            return $"{Tag.Administrator.DevelopmentBuild}|{contents}";
        }

        /// <summary>
        /// Build string of spacial log
        /// </summary>
        /// <param name="label"> <see cref="Manager.Log.Label"/> of log </param>
        /// <param name="type"> <see cref="Type"/> of class where the log was called </param>
        /// <param name="contents"> Contents of output log </param>
        /// <returns> String of spacial log </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Out of range exception in <see cref="Manager.Log.Label"/>
        /// </exception>
        public static string Build(Label label, Type type, string contents)
        {
            string log;

            switch (label)
            {
                case Label.Called:
                    log = $"{Tag.Called}|{type.Name}|<b><i>{contents}</i></b>";
                    break;
                case Label.Event:
                    log = $"{Tag.Event}|{type.Name}|{contents}";
                    break;
                case Label.Error:
                    log = $"{Tag.Error}|{type.Name}|{contents}";
                    break;
                case Label.Success:
                    log = $"{Tag.Success}|{type.Name}|{contents}";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(label), label, null);
            }

            return log;
        }
    }
}
