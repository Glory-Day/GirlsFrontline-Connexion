#region NAMESPACE API

using UnityEngine;
using UnityEngine.UI;
using Manager;
using LabelType = Manager.Log.Label.LabelType;

#endregion

namespace Scene
{
    /// <summary>
    /// Events in the <b>Main Scene</b>
    /// </summary>
    public class MainUtility : MonoBehaviour
    {
        #region SERIALIZABLE FIELD

        [Header("# Game Start Button")]
        [SerializeField]
        public Button gameStartButton;

        #endregion

        #region BUTTON EVENT API

        /// <summary>
        /// <see cref="Button"/> event to click <see cref="gameStartButton"/> in <b>Main Scene</b>
        /// </summary>
        public void OnClickedGameStartButton()
        {
            LogManager.OnDebugLog(LabelType.Event, typeof(MainUtility),
                "<b>Game Start Button</b> is clicked");

            gameStartButton.interactable = false;

            UIManager.SetScreenTransitionDirectionToLeft();
            UIManager.OnPlayScreenTransitionAnimation();
        }

        #endregion
    }
}
