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
            return $"{Label.AdministratorInDevelopmentBuildLogLabel}|{contents}";
        }

        /// <summary>
        /// Build string of default log
        /// </summary>
        /// <param name="classType"> <see cref="Type"/> of class where the log was called </param>
        /// <param name="contents"> Contents of output log </param>
        /// <returns> String of default log </returns>
        public static string Build(Type classType, string contents)
        {
            return $"{Label.DefaultLogLabel}|{classType.Name}|Called <b><i>{contents}</i></b>";
        }

        /// <summary>
        /// Build string of spacial log
        /// </summary>
        /// <param name="type"> <see cref="Label.LabelType"/> of log </param>
        /// <param name="classType"> <see cref="Type"/> of class where the log was called </param>
        /// <param name="contents"> Contents of output log </param>
        /// <returns> String of spacial log </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Out of range exception in <see cref="Label.LabelType"/>
        /// </exception>
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
