namespace Library.UI.CommandConsole
{
    /// <summary>
    /// Data unit for storing command information in the input command line
    /// </summary>
    public class CommandPacket
    {
        /// <param name="header"> Name of the command </param>
        /// <param name="data">  </param>
        public CommandPacket(string header, ParameterData data)
        {
            Header = header;
            Data = data;
        }
        
        /// <returns>
        /// Name of the administrator command
        /// </returns>
        public string Header { get; private set; }
        
        /// <returns>
        /// Arguments packet in <see cref="CommandPacket"/>
        /// </returns>
        public ParameterData Data { get; }
    }
}