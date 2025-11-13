using System;

namespace Library.UI.CommandConsole
{
    public class UnsupportedCommandLineException : Exception
    {
        public UnsupportedCommandLineException()
        {
            Message = "Not supported command line is input";
        }

        public UnsupportedCommandLineException(string message) : base(message)
        {
            Message = message;
        }
        
        public override string Message { get; }
    }
}