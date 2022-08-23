namespace Interface
{
    public interface IObserver
    {
        void OnUpdate<T>(T param) where T : class;
    }
}
