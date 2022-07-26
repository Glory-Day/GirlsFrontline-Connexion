namespace UI.Console.Command
{
    public interface ICommand
    {
        /// <summary>
        /// Execute command with administrator permission
        /// </summary>
        void Execute();
    }
}
