using GloryDay.Debug;
using TMPro;
using UnityEngine;

<<<<<<<< HEAD:GirlsFrontline-Connexion/Assets/Scripts/Core/UI/CharacterStatPointDisplay.cs
namespace Core.UI
========
namespace Backend.Object.UI
>>>>>>>> develop:GirlsFrontline-Connexion/Assets/Scripts/Core/Object/UI/CharacterStatPointDisplay.cs
{
    public class CharacterStatPointDisplay : MonoBehaviour
    {
        #region COMPONENT FIELD API

        private TMP_Text _text;

        #endregion

        private void Awake()
        {
            Console.LogProgress();

            var index = transform.childCount - 1;
            _text = transform.GetChild(index).GetComponent<TMP_Text>();
        }

        public void SetText(string text)
        {
            _text.text = text;
        }
    }
}
