using GloryDay.Debug;
using UnityEngine;

<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/ChapterStateDisplay.cs
namespace Core.UI
========
namespace Backend.Object.UI
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/ChapterStateDisplay.cs
{
    public class ChapterStateDisplay : MonoBehaviour
    {
        #region COMPONENT FIELD API

        private GameObject _playStateImageObject;
        private GameObject _pauseStateImageObject;

        #endregion

        private void Awake()
        {
            Console.LogProgress();

            _playStateImageObject = transform.GetChild(0).gameObject;
            _pauseStateImageObject = transform.GetChild(1).gameObject;

            _pauseStateImageObject.SetActive(false);
        }

        public void DisableState()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/ChapterStateDisplay.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/ChapterStateDisplay.cs
            _playStateImageObject.SetActive(true);
            _pauseStateImageObject.SetActive(false);
        }

        public void EnableState()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/ChapterStateDisplay.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/ChapterStateDisplay.cs
            _playStateImageObject.SetActive(false);
            _pauseStateImageObject.SetActive(true);
        }
    }
}
