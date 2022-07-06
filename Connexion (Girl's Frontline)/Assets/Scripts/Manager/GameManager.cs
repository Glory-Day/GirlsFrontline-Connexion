namespace Manager
{
    public class GameManager : Singleton<GameManager>
    {
        protected GameManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }
    }
}
