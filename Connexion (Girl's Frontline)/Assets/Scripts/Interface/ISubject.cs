namespace Interface
{
    public interface ISubject
    {
        void OnRegister(IObserver observer);
        void OnRemove(IObserver observer);
        void OnNotify();
    }
}
