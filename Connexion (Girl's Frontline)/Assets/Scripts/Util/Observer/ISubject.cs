namespace Util.Observer
{
    public interface ISubject
    {
        void Register();
        void Remove();
        void Notify();
    }
}
