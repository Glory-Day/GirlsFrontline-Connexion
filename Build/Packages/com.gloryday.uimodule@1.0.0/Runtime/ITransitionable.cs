namespace GloryDay.UI
{
    public interface ITransitionable
    {
        void Open();
        
        void Close();
        
        bool IsOpening { get; }
    }
}