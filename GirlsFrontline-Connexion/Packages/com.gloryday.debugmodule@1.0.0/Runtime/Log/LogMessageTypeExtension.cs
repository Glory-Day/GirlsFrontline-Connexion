using System;

namespace GloryDay.Debug.Log
{
    public static class LogMessageTypeExtension
    {
        /// <summary>
        /// Get the name of <see cref="LogMessageType"/> in all upper case
        /// </summary>
        public static string GetName(this LogMessageType type)
        {
            return Enum.GetName(typeof(LogMessageType), type)?.ToUpper();
        }
    }
}