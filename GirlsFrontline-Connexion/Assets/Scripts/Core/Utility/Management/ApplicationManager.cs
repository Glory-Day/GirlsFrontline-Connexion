using GloryDay.Debug;
using GloryDay.Utility;
using UnityEngine;

<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/GameManager.cs
namespace Core.Utility.Manager
========
namespace Backend.Utility.Management
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/ApplicationManager.cs
{
    public class ApplicationManager : Singleton<ApplicationManager>
    {
        private bool _isPaused;

        private ApplicationManager()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/GameManager.cs
            Console.LogProgress();

            _isApplicationPaused = false;
        }

        #region STATIC METHOD API

        /// <summary>
        /// Pause the running application.
        /// </summary>
        public static void OnApplicationPause()
========
            LogManager.LogProgress();

            _isPaused = false;
        }

        private void Pause_Internal()
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/ApplicationManager.cs
        {
            Console.LogProgress();

            if (_isPaused)
            {
                Console.LogError("<b>Application</b> has already been paused");

                return;
            }

            Time.timeScale = 0f;

<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/GameManager.cs
            Instance._isApplicationPaused = true;
========
            _isPaused = true;
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/ApplicationManager.cs

            Console.LogSuccess("<b>Application</b> is paused");
        }

        private void Play_Internal()
        {
            Console.LogProgress();

            if (_isPaused == false)
            {
                Console.LogError("<b>Application</b> is currently running");

                return;
            }

            Time.timeScale = 1f;

<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Manager/GameManager.cs
            Instance._isApplicationPaused = false;
========
            _isPaused = false;
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Utility/Management/ApplicationManager.cs

            Console.LogSuccess("<b>Application</b> is played");
        }

        private void Quit_Internal()
        {
            Console.LogProgress();

            Console.LogSuccess("<b>Game Application</b> is quited");

#if UNITY_EDITOR

            UnityEditor.EditorApplication.isPlaying = false;

#else

            UnityEngine.Application.Quit();

#endif
        }

        #region STATIC METHOD API

        /// <summary>
        /// Pause the running application.
        /// </summary>
        public static void Pause()
        {
            Instance.Pause_Internal();
        }

        /// <summary>
        /// Play the quiting application.
        /// </summary>
        public static void Play()
        {
            Instance.Play_Internal();
        }

        /// <summary>
        /// Quits the player application.
        /// </summary>
        public static void Quit()
        {
            Instance.Quit_Internal();
        }

        #endregion

        #region STATIC PROPERTIES API

        public static bool IsPaused => Instance._isPaused;

        #endregion
    }
}
