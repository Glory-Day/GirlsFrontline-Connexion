using System;

namespace Manager.Log.Build
{
    /// <summary>
    /// Output log string builder by purpose in <b>Unity Application</b> after build
    /// </summary>
    public static class LogBuilder
    {
        /// <summary>
        /// Build the string of the default log
        /// </summary>
        /// <param name="classType"> The type of the class where the log was called </param>
        /// <param name="contents"> Contents of the log </param>
        /// <returns> The string of the default log </returns>
        public static string OnBuild(Type classType, string contents)
        {
            return $"{Label.DefaultLogLabel}|{classType.Name}|Called <i>{contents.Replace('_', ' ')}</i>";
        }
        
        /// <summary>
        /// Build the string of special log
        /// </summary>
        /// <param name="type"> Type of Log </param>
        /// <param name="classType"> The type of the class where the log was called </param>
        /// <param name="contents"> Contents of the log </param>
        /// <returns> The string of special log </returns>
        /// <exception cref="ArgumentOutOfRangeException"> Out of range in <b>LabelType</b> </exception>
        public static string OnBuild(Label.LabelType type, Type classType, string contents)
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
                case Label.LabelType.Warning:
                    log = $"{Label.WarningLogLabel}|{classType.Name}|{contents.Replace('_', ' ')}";
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
