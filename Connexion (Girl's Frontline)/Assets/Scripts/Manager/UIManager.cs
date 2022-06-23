using UnityEngine;

namespace Manager
{
    public class UIManager : Singleton<UIManager>
    {
        private Canvas sceneTransitionCanvas;
        
        protected UIManager()
        {
            // Guarantee this object will be always a singleton only - Can not use the constructor
        }
    }
}
