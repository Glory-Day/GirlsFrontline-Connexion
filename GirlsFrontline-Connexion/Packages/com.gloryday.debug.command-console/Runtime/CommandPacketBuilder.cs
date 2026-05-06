using System;
using System.Collections.Generic;

namespace GloryDay.Debug
{
    public class CommandPacketBuilder
    {
        private readonly Queue<CommandPacket> _queue = new Queue<CommandPacket>();
        
        private readonly ParameterDataBuilder _parameterDataBuilder = new ParameterDataBuilder();
        
        /// <summary>
        /// Build administrator input command line as packet
        /// </summary>
        /// <param name="commandLine"> Administrator input command line </param>
        public void Build(string commandLine)
        {
            var commandLines = Split(commandLine);

            var length = commandLines.Length;
            for (var i = 0; i < length; i++)
            {
                _queue.Enqueue(Pack(commandLines[i]));
            }
        }
        
        /// <returns>
        /// The built command packet
        /// </returns>
        public CommandPacket GetPacket()
        {
            return _queue.Dequeue();
        }
        
        /// <summary>
        /// Split an administrator input command line by the pipeline
        /// </summary>
        /// <param name="commandLine"> Administrator input command line </param>
        /// <returns> Split command lines </returns>
        private static string[] Split(string commandLine)
        {
            var commandLines = commandLine.Split(Separator.Pipeline, StringSplitOptions.RemoveEmptyEntries);

            var length = commandLines.Length;
            for (var i = 0; i < length; i++)
            {
                commandLines[i] = commandLines[i].Trim();
            }

            return commandLines;
        }

        /// <summary>
        /// Convert the command line to the command name and argument data, and then turn it into a packet
        /// </summary>
        /// <param name="commandLine"> Split command line </param>
        /// <returns>
        /// Packet in which information and data from the administrator input command line are stored
        /// </returns>
        private CommandPacket Pack(string commandLine)
        {
            // Split command line to command name and parts of argument
            var commandLines = commandLine.Split(Separator.Hyphen, StringSplitOptions.RemoveEmptyEntries);
            
            var length = commandLines.Length;
            for (var i = 1; i < length; i++)
            {
                _parameterDataBuilder.Build(commandLines[i].Trim());
            }

            var commandName = commandLines[0].Trim();
            var argumentPacket = _parameterDataBuilder.GetData();

            return new CommandPacket(commandName, argumentPacket);
        }
        
        /// <returns>
        /// Check the built command packets are empty
        /// </returns>
        public bool IsEmpty => _queue.Count == 0;
    }
}