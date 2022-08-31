#region NAMESPACE API

using System;
using Label = Manager.Log.LogLabel.Label;

#endregion

namespace Manager.Log.UnityEditor
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
            return $"<color={Color.Administrator}><b>[{Tag.Administrator.UnityEditor}]</b> {contents}</color>";
        }

        /// <summary>
        /// Build string of default log
        /// </summary>
        /// <param name="type"> <see cref="Type"/> of class where the log was called </param>
        /// <param name="contents"> Contents of output log </param>
        /// <returns> String of default log </returns>
        public static string Build(Type type, string contents)
        {
            return $"<color={Color.Default}><b>[{type.Name}] </b>Called <b><i>{contents}</i></b></color>";
        }

        /// <summary>
        /// Build string of spacial log
        /// </summary>
        /// <param name="label"> <see cref="Manager.Log.LogLabel.Label"/> of log </param>
        /// <param name="type"> <see cref="Type"/> of class where the log was called </param>
        /// <param name="contents"> Contents of output log </param>
        /// <returns> String of spacial log </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Out of range exception in <see cref="Manager.Log.LogLabel.Label"/>
        /// </exception>
        public static string Build(Label label, Type type, string contents)
        {
            string log;

            switch (label)
            {
                case Label.Event:
                    log = $"<color={Color.Event}><b>[{Label.Event}][{type.Name}]</b> {contents}</color>";
                    break;
                case Label.Error:
                    log = $"<color={Color.Error}><b>[{Label.Error}][{type.Name}]</b> {contents}</color>";
                    break;
                case Label.Success:
                    log = $"<color={Color.Success}><b>[{Label.Success}][{type.Name}]</b> {contents}</color>";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(label), label, null);
            }

            return log;
        }
    }
}
