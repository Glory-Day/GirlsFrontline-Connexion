#region NAMESPACE API

using System;

#endregion

namespace Manager.Log.DevelopmentBuild
{
    /// <summary>
    /// Output log string builder by purpose in <b>Game Application</b> after build
    /// </summary>
    public class LogBuilder
    {
        /// <summary>
        /// Build the string of the administrator permission log
        /// </summary>
        /// <param name="contents"> Contents of the log </param>
        /// <returns> The string of the administrator permission log </returns>
        public string Build(string contents)
        {
            return $"{Label.AdministratorInDevelopmentBuildLogLabel}|{contents.Replace('_', ' ')}";
        }

        /// <summary>
        /// Build the string of the default log
        /// </summary>
        /// <param name="classType"> The type of the class where the log was called </param>
        /// <param name="contents"> Contents of the log </param>
        /// <returns> The string of the default log </returns>
        public string Build(Type classType, string contents)
        {
            return $"{Label.DefaultLogLabel}|{classType.Name}|" +
                   $"Called <b><i>{contents.Replace('_', ' ')}</i></b>";
        }

        /// <summary>
        /// Build the string of special log
        /// </summary>
        /// <param name="type"> Type of Log </param>
        /// <param name="classType"> The type of the class where the log was called </param>
        /// <param name="contents"> Contents of the log </param>
        /// <returns> The string of special log </returns>
        /// <exception cref="ArgumentOutOfRangeException"> Out of range in <b>LabelType</b> </exception>
        public string Build(Label.LabelType type, Type classType, string contents)
        {
            string log;

            switch (type)
            {
                case Label.LabelType.Event:
                    log = $"{Label.EventLogLabel}|{classType.Name}|{contents.Replace('_', ' ')}";
                    break;
                case Label.LabelType.Error:
                    log = $"{Label.ErrorLogLabel}|{classType.Name}|{contents.Replace('_', ' ')}";
                    break;
                case Label.LabelType.Success:
                    log = $"{Label.SuccessLogLabel}|{classType.Name}|{contents.Replace('_', ' ')}";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return log;
        }
    }
}
