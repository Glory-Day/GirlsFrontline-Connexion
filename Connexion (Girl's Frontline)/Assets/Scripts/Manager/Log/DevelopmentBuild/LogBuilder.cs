#region NAMESPACE API

using System;

#endregion

namespace Manager.Log.DevelopmentBuild
{
    /// <summary>
    /// <b>Output Log</b> builder by purpose in <b>Game Application</b> after build
    /// </summary>
    public static class LogBuilder
    {
        /// <summary>
        /// Build the string of <b>Administrator Permission Log</b>
        /// </summary>
        /// <param name="contents"> Contents of the log </param>
        /// <returns> The string of <b>Administrator Permission Log</b> </returns>
        public static string Build(string contents)
        {
            return $"{Label.AdministratorInDevelopmentBuildLogLabel}|{contents}";
        }

        /// <summary>
        /// Build the string of <b>Default Log</b>
        /// </summary>
        /// <param name="classType"> The type of the class where the log was called </param>
        /// <param name="contents"> Contents of the log </param>
        /// <returns> The string of <b>Default Log</b> </returns>
        public static string Build(Type classType, string contents)
        {
            return $"{Label.DefaultLogLabel}|{classType.Name}|Called <b><i>{contents}</i></b>";
        }

        /// <summary>
        /// Build the string of <b>Spacial Log</b>
        /// </summary>
        /// <param name="type"> Type of Log </param>
        /// <param name="classType"> The type of the class where the log was called </param>
        /// <param name="contents"> Contents of the log </param>
        /// <returns> The string of <b>Spacial Log</b> </returns>
        /// <exception cref="ArgumentOutOfRangeException"> Out of range in <b>LabelType</b> </exception>
        public static string Build(Label.LabelType type, Type classType, string contents)
        {
            string log;

            switch (type)
            {
                case Label.LabelType.Event:
                    log = $"{Label.EventLogLabel}|{classType.Name}|{contents}";
                    break;
                case Label.LabelType.Error:
                    log = $"{Label.ErrorLogLabel}|{classType.Name}|{contents}";
                    break;
                case Label.LabelType.Success:
                    log = $"{Label.SuccessLogLabel}|{classType.Name}|{contents}";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return log;
        }
    }
}
