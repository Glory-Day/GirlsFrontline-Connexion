using System;

namespace Util.Log.UnityEditor
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
        /// Build string of log by <see cref="Log.Label"/>
        /// </summary>
        /// <param name="label"> <see cref="Log.Label"/> of log </param>
        /// <param name="type"> <see cref="Type"/> of class where the log was called </param>
        /// <param name="contents"> Contents of output log </param>
        /// <returns> String of spacial log </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Out of range exception in <see cref="Log.Label"/>
        /// </exception>
        public static string Build(Label label, Type type, string contents)
        {
            string log;

            switch (label)
            {
                case Label.Called:
                    log = $"<color={Color.Default}><b>[{Tag.Called}][{type.Name}]</b> <i>{contents}</i></color>";
                    break;
                case Label.Event:
                    log = $"<color={Color.Bold}><b>[{Tag.Event}][{type.Name}]</b> {contents}</color>";
                    break;
                case Label.Error:
                    log = $"<color={Color.Error}><b>[{Tag.Error}][{type.Name}]</b> {contents}</color>";
                    break;
                case Label.Success:
                    log = $"<color={Color.Success}><b>[{Tag.Success}][{type.Name}]</b> {contents}</color>";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(label), label, null);
            }

            return log;
        }
    }
}
