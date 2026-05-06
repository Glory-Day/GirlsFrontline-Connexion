using GloryDay.Debug;
using TMPro;
using UnityEngine;

<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/ChapterInformationDisplay.cs
namespace Core.UI
========
namespace Backend.Object.UI
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/ChapterInformationDisplay.cs
{
    public class ChapterInformationDisplay : MonoBehaviour
    {
        #region COMPONENT FIELD API

        private TMP_Text _text;

        #endregion

        private void Awake()
        {
<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/ChapterInformationDisplay.cs
            Console.LogProgress();
            
========
            LogManager.LogProgress();

>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/ChapterInformationDisplay.cs
            _text = transform.GetChild(1).GetChild(1).GetComponent<TMP_Text>();
        }

        public void SetText(string text)
        {
            _text.text = text;
        }
    }
}
