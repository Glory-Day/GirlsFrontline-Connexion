using System;

namespace GloryDay.Debug
{
    public static class LogLevel_Extension
    {
        /// <return>
        /// Text of <see cref="LogLevel"/> in all upper case.
        /// </return>
        public static string GetText(this LogLevel level)
        {
            return level switch
            {
                LogLevel.Administrator => "ADMINISTRATOR",
                LogLevel.Error => "ERROR",
                LogLevel.Warning => "WARNING",
                LogLevel.Success => "SUCCESS",
                LogLevel.Event => "EVENT",
                LogLevel.Message => "MESSAGE",
                LogLevel.Progress => "PROGRESS",
                _ => throw new ArgumentOutOfRangeException(nameof(level), level, null)
            };
        }

        /// <return>
        /// Color of <see cref="LogLevel"/> to hex code.
        /// </return>
        public static string GetColor(this LogLevel level)
        {
            return level switch
            {
                LogLevel.Administrator => "#F7E600",
                LogLevel.Error => "#DC143C",
                LogLevel.Warning => "#F7E600",
                LogLevel.Success => "#39FF14",
                LogLevel.Event => "#F8F8FF",
                LogLevel.Message => "#F8F8FF",
                LogLevel.Progress => "#F8F8FF",
                _ => throw new ArgumentOutOfRangeException(nameof(level), level, null)
            };
        }
    }
}
