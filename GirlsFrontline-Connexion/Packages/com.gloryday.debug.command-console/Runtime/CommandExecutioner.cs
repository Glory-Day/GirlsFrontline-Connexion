namespace GloryDay.Debug
{
    public class CommandExecutioner
    {
        private readonly CommandPacketBuilder _commandPacketBuilder = new CommandPacketBuilder();

        /// <summary>
        /// Set command line to execute
        /// </summary>
        /// <param name="commandLine"> Administrator input command line </param>
        public void Receive(string commandLine)
        {
            _commandPacketBuilder.Build(commandLine);
        }

        /// <summary>
        /// Execute built command
        /// </summary>
        public void Execute()
        {
            while (_commandPacketBuilder.IsEmpty == false)
            {
                var packet = _commandPacketBuilder.GetPacket();

                var key = packet.Header;
                if (CommandList.TryGetValue(key, out var command))
                {
                    command?.Execute(packet.Data);
                }
            }
        }
    }
}