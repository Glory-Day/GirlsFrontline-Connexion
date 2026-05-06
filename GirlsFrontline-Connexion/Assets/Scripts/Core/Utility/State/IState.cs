namespace Core.Utility.State
{
    public interface IState
    {
        void Start();
        
        void Update();
        
        void End();
    }
}
