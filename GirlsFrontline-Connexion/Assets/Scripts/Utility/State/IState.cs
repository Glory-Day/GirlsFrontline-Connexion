namespace Utility.State
{
    public interface IState
    {
        void Enter();
        void Update();
        void Exit();
    }
}
