#region NAMESPACE API

using UnityEngine;
using Util.Manager;
using Util.Manager.Log;

#endregion

namespace Object.UI.Option.Controller
{
    public class ExitButton : MonoBehaviour
    {
        #region BUTTON EVENT API

        public void OnClicked()
        {
            LogManager.OnDebugLog(
                Label.Event, 
                typeof(ExitButton), 
                "<b>Exit Button</b> is clicked");
            
            GameManager.OnQuit();
        }

        #endregion
    }
}
