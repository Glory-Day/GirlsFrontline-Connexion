using System;

namespace Manager.Log.Console
{
    /// <summary>
    /// Output log string builder by purpose in <b>Unity Editor Console</b>
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
            return $"<color={Label.DefaultLogColor}><b>[{classType.Name}]</b> Called <i>{contents}</i></color>";
        }
        
        /// <summary>
        /// Build the string of special log
        /// </summary>
        /// <param name="type"> Type of Log </param>
        /// <param name="classType"> The type of the class where the log was called </param>
        /// <param name="contents"> Contents of the log </param>
        /// <returns> The string of special log </returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static string OnBuild(Label.LabelType type, Type classType, string contents)
        {
            string log;

            switch (type)
            {
                case Label.LabelType.Event:
                    log = $"<color={Label.EventLogColor}><b>[{Label.EventLogLabel}][{classType.Name}]</b> " +
                          $"{contents}</color>";
                    break;
                case Label.LabelType.Error:
                    log = $"<color={Label.ErrorLogColor}><b>[{Label.ErrorLogLabel}][{classType.Name}]</b> " +
                          $"{contents}</color>";
                    break;
                case Label.LabelType.Warning:
                    log = $"<color={Label.WarningLogColor}><b>[{Label.WarningLogLabel}][{classType.Name}]</b> " +
                          $"{contents}</color>";
                    break;
                case Label.LabelType.Success:
                    log = $"<color={Label.SuccessLogColor}><b>[{Label.SuccessLogLabel}][{classType.Name}]</b> " +
                          $"{contents}</color>";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return log;
        }
    }
}
