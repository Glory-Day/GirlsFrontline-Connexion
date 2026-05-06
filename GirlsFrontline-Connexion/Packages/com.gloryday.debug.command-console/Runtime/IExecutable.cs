namespace GloryDay.Debug
{
    public interface IExecutable
    {
        /// <summary>
        /// Execute command as administrator
        /// </summary>
        /// <param name="data"> Packet of argument </param>
        void Execute(ParameterData data);
    }
}