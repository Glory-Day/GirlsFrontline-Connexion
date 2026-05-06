namespace Core.UI
{
    public interface ITransitionable
    {
        void Transition(int index, TransitionType type);
    }
}